using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Franken_.App_Code;

namespace Franken_
{
    public partial class TrainTesseract : Form
    {
        Language myLang = null;
        DataPipe db = new DataPipe();
        string TiffBoxPairsDir = "";
        string TrainingDir = "";
        string Job = "";

        Progress progressWindow = null;
        string ProcessStatus = "Starting...";
        List<App_Code.Font> SelectedFonts = new List<App_Code.Font>();

        public TrainTesseract(string LangID)
        {
            InitializeComponent();
            myLang = new Language(LangID);
            TiffBoxPairsDir = db.DataDirectory + "\\TiffBoxPairs";
            TrainingDir = db.DataDirectory + "\\TrainingLibraries\\" + myLang.Name;

            if (!Directory.Exists(db.DataDirectory + "\\TrainingLibraries")) { Directory.CreateDirectory(db.DataDirectory + "\\TrainingLibraries"); }

            if (db.GetRows("select font_id from fonts order by font_name asc"))
            {
                foreach (DataRow Fid in db.Bucket.Rows)
                {
                    App_Code.Font F = new App_Code.Font(Fid[0].ToString(), false, false);

                    if (Directory.Exists(TiffBoxPairsDir + "\\" + F.ID))
                    {
                        string[] BoxFiles = Directory.GetFiles(TiffBoxPairsDir + "\\" + F.ID, "*.box", SearchOption.AllDirectories);

                        if (BoxFiles.Length > 0)
                        {
                            fontList.Items.Add(F);
                        }
                    }
                }
            }

            langNameLabel.Text = "Language: " + myLang.Name;
        }

        private void TrainTesseract_Load(object sender, EventArgs e)
        {

        }

        private void unicharUnambigsBrowseButton_Click(object sender, EventArgs e)
        {
            DialogResult res = fileBrowser.ShowDialog();

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                unicharUnambigsPathBox.Text = fileBrowser.FileName;
            }
        }

        private void wordFreqBrowseButton_Click(object sender, EventArgs e)
        {
            DialogResult res = fileBrowser.ShowDialog();

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                wordFreqPathBox.Text = fileBrowser.FileName;
            }
        }

        private void wordDictBrowseButton_Click(object sender, EventArgs e)
        {
            DialogResult res = fileBrowser.ShowDialog();

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                wordDictPathBox.Text = fileBrowser.FileName;
            }
        }

        private void makeLibraryButton_Click(object sender, EventArgs e)
        {
            if (fontList.CheckedItems.Count > 0)
            {
                foreach(App_Code.Font F in fontList.CheckedItems)
                {
                    SelectedFonts.Add(F);
                }

                if (backgroundWorker.IsBusy != true)
                {
                    Job = "makeLibrary";
                    progressWindow = new Progress();
                    progressWindow.Canceled += progressWindow_Canceled;
                    progressWindow.Show();
                    backgroundWorker.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("Please select one or more fonts.");
            }
        }

        void progressWindow_Canceled(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
            progressWindow.Close();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker slave = sender as BackgroundWorker;

            if (Job == "makeLibrary")
            {
                if (Directory.Exists(TrainingDir) && doClearTrainingBox.Checked)
                {
                    try
                    {
                        Directory.Delete(TrainingDir, true);
                        System.Threading.Thread.Sleep(5000);
                    }
                    catch (Exception E) { }
                }

                if (!Directory.Exists(TrainingDir)) { Directory.CreateDirectory(TrainingDir); }

                if (SelectedFonts.Count > 0)
                {
                    if (doFontPropertiesFile.Checked)
                        MakeFontProperties(ref slave, ref ProcessStatus, SelectedFonts);

                    if (doTiffBoxBox.Checked)
                        CopyTiffBoxPairs(ref slave, ref ProcessStatus, SelectedFonts);

                    if (doCreateTRFilesBox.Checked)
                        TrainFont(ref slave, ref ProcessStatus);

                    if (doTrainingBox.Checked)
                        MakeUnicharset(ref slave, ref ProcessStatus);

                    if (doProcessWordListsBox.Checked)
                        ProcessWordLists(ref slave, ref ProcessStatus);

                    if (doCombineBox.Checked)
                        CombineTessData(ref slave, ref ProcessStatus);
                }
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressWindow.Message = ProcessStatus;
            progressWindow.ProgressValue = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressWindow.Close();

            if (File.Exists(TrainingDir + "\\" + myLang.Name + ".traineddata") && doCombineBox.Checked)
            {
                MessageBox.Show(myLang.Name + ".traineddata created successfully!  Before running Tesseract on this computer using this library, be sure to copy " + myLang.Name + ".traineddata to " + db.TessPath + "\\tessdata");
                Process.Start(TrainingDir);
            }
            else if(doCombineBox.Checked)
            {
                MessageBox.Show("Library creation failed!  Check output.txt and error.txt for details.");
                Process.Start(TrainingDir);
            }
        }

        private void MakeFontProperties(ref BackgroundWorker Slave, ref string ProcessStatus, List<App_Code.Font> SelectedFonts)
        {
            var utf8SansBOM = new System.Text.UTF8Encoding(false);

            int Progress = 10;
            ProcessStatus = "Writing font_properties file...";
            Slave.ReportProgress(Progress);
            StreamWriter FP = new StreamWriter(TrainingDir + "\\font_properties", false, utf8SansBOM);
            foreach (App_Code.Font F in SelectedFonts)
            {
                FP.WriteLine(F.Name + " " + F.Italic + " " + F.Bold + " " + F.Fixed + " " + F.Fixed + " " + F.Serif + " " + F.Fraktur);
                Progress++;
                Slave.ReportProgress(Progress);
            }
            FP.Close();

            File.Copy(TrainingDir + "\\font_properties", TrainingDir + "\\" + myLang.Name + ".font_properties", true);
        }

        private void CopyTiffBoxPairs(ref BackgroundWorker Slave, ref string ProcessStatus, List<App_Code.Font> SelectedFonts)
        {
            int expNum = 0;

            int Progress = 0;
            ProcessStatus = "Copying box/tif pairs...";
            Slave.ReportProgress(Progress);

            foreach (App_Code.Font F in SelectedFonts)
            {
                if (Slave.CancellationPending)
                {
                    break;
                }

                ProcessStatus = "Copying box/tif pairs for " + F.Name + "...";
                Progress++; if (Progress > 100) { Progress = 100; }
                Slave.ReportProgress(Progress);

                if (Directory.Exists(TiffBoxPairsDir + "\\" + F.ID))
                {
                    string[] BoxFiles = Directory.GetFiles(TiffBoxPairsDir + "\\" + F.ID, "*.box", SearchOption.AllDirectories);

                    foreach (string BoxFile in BoxFiles)
                    {
                        if (File.Exists(BoxFile.Replace(".box", ".tif")))
                        {
                            string[] FileParts = BoxFile.Split(new char[] { '\\' });
                            string JustFileName = "";

                            if (FileParts.Length > 0)
                            {
                                JustFileName = FileParts[FileParts.Length - 1];    
                            }

                            if (JustFileName != "")
                            {
                                string FixedFileName = "";
                                string[] fileNameParts = JustFileName.Split(new char[] { '.' });
                                if (fileNameParts.Length == 4)
                                {
                                    FixedFileName = fileNameParts[0] + "." + fileNameParts[1] + ".exp" + expNum + "." + fileNameParts[3];
                                    expNum++;
                                }

                                if (FixedFileName != "")
                                {
                                    File.Copy(BoxFile, TrainingDir + "\\" + FixedFileName, true);
                                    File.Copy(BoxFile.Replace(".box", ".tif"), TrainingDir + "\\" + FixedFileName.Replace(".box", ".tif"), true);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ProcessWordLists(ref BackgroundWorker Slave, ref string ProcessStatus)
        {
            int Progress = 0;
            ProcessStatus = "Checking for word lists...";
            Slave.ReportProgress(Progress);

            if (wordFreqPathBox.Text != "" && !Slave.CancellationPending)
            {
                Progress = 10;
                ProcessStatus = "Making frequent words DAWG file...";
                Slave.ReportProgress(Progress);
                File.Copy(wordFreqPathBox.Text, TrainingDir + "\\freq-dawg", true);
                ExecuteCommand("wordlist2dawg.exe", " freq-dawg " + myLang.Name + ".freq-dawg " + myLang.Name + ".unicharset ", TrainingDir);
            }

            if (wordDictPathBox.Text != "" && !Slave.CancellationPending)
            {
                Progress = 75;
                ProcessStatus = "Making dictionary words DAWG file...";
                Slave.ReportProgress(Progress);
                File.Copy(wordDictPathBox.Text, TrainingDir + "\\word-dawg", true);
                ExecuteCommand("wordlist2dawg.exe", " word-dawg " + myLang.Name + ".word-dawg " + myLang.Name + ".unicharset ", TrainingDir);
            }
        }

        private void TrainFont(ref BackgroundWorker Slave, ref string ProcessStatus)
        {
            int Progress = 0;
            double Interval = 10;
            ProcessStatus = "Training fonts...";
            Slave.ReportProgress(Progress);

            string[] TiffFiles = Directory.GetFiles(TrainingDir, "*.tif");

            for (int x = 0; x < TiffFiles.Length; x++)
            {
                TiffFiles[x] = TiffFiles[x].Replace(TrainingDir + "\\", "");
            }

            if (TiffFiles.Length > 0)
            {
                Interval = System.Convert.ToDouble(100) / System.Convert.ToDouble(TiffFiles.Length);

                for(int x = 0; x < TiffFiles.Length; x++)
                {
                    if (Slave.CancellationPending)
                    {
                        break;
                    }

                    Progress = (int)(x * Interval); if (Progress > 100) { Progress = 100; }
                    ProcessStatus = "Training with " + TiffFiles[x] + "...";
                    Slave.ReportProgress(Progress);

                    ExecuteCommand("tesseract.exe", " " + TiffFiles[x] + " " + TiffFiles[x].Replace(".tif", "") + " nobatch box.train", TrainingDir);  
                }  
            }
            else
            {
                MessageBox.Show("There were no valid .tif files with which to train.");
            }
        }

        private void MakeUnicharset(ref BackgroundWorker Slave, ref string ProcessStatus)
        {
            int Progress = 0;

            string[] TRFiles = Directory.GetFiles(TrainingDir, "*.tr");

            for (int x = 0; x < TRFiles.Length; x++)
            {
                TRFiles[x] = TRFiles[x].Replace(TrainingDir + "\\", "");
            }

            if (!Slave.CancellationPending && TRFiles.Length > 0)
            {
                string BoxFilesLine = "";
                string TrFilesLine = "";
                foreach (string TRFile in TRFiles)
                {
                    if (File.Exists(TrainingDir + "\\" + TRFile.Replace(".tr", ".box")))
                    {
                        BoxFilesLine += " " + TRFile.Replace(".tr", ".box");
                        TrFilesLine += " " + TRFile;
                    }
                }

                if (!Slave.CancellationPending)
                {
                    Progress = 0;
                    ProcessStatus = "Making unicharset...";
                    Slave.ReportProgress(Progress);
                    ExecuteCommand("unicharset_extractor.exe", BoxFilesLine, TrainingDir);

                    if (!Slave.CancellationPending)
                    {
                        Progress = 25;
                        ProcessStatus = "Shape clustering...";
                        Slave.ReportProgress(Progress);
                        ExecuteCommand("shapeclustering.exe", " -F font_properties -U unicharset" + TrFilesLine, TrainingDir);

                        if (!Slave.CancellationPending)
                        {
                            Progress = 50;
                            ProcessStatus = "Performing mftraining...";
                            Slave.ReportProgress(Progress);
                            ExecuteCommand("mftraining.exe", " -F font_properties -U unicharset -O " + myLang.Name + ".unicharset" + TrFilesLine, TrainingDir);

                            if (!Slave.CancellationPending)
                            {
                                Progress = 75;
                                ProcessStatus = "Performing cntraining...";
                                Slave.ReportProgress(Progress);
                                ExecuteCommand("cntraining.exe", TrFilesLine, TrainingDir);
                            }
                        }
                    }
                }
            }

            if (File.Exists(TrainingDir + "\\unicharset"))
            {
                File.Copy(TrainingDir + "\\unicharset", TrainingDir + "\\" + myLang.Name + ".unicharset", true);
            }
        }

        private void CombineTessData(ref BackgroundWorker Slave, ref string ProcessStatus)
        {
            int Progress = 0;
            ProcessStatus = "Checking for necessary files...";
            Slave.ReportProgress(Progress);

            if (!Slave.CancellationPending)
            {
                if (unicharUnambigsPathBox.Text != "")
                {
                    if (File.Exists(unicharUnambigsPathBox.Text))
                    {
                        File.Copy(unicharUnambigsPathBox.Text, TrainingDir + "\\" + myLang.Name + ".unicharambigs");
                    }
                }

                if (File.Exists(TrainingDir + "\\inttemp") &&
                    File.Exists(TrainingDir + "\\shapetable") &&
                    File.Exists(TrainingDir + "\\normproto") &&
                    File.Exists(TrainingDir + "\\pffmtable"))
                {
                    Progress = 25;
                    ProcessStatus = "Renaming files...";
                    Slave.ReportProgress(Progress);

                    File.Copy(TrainingDir + @"\inttemp", TrainingDir + "\\" + myLang.Name + ".inttemp", true);
                    File.Copy(TrainingDir + @"\shapetable", TrainingDir + "\\" + myLang.Name + ".shapetable", true);
                    File.Copy(TrainingDir + @"\normproto", TrainingDir + "\\" + myLang.Name + ".normproto", true);
                    File.Copy(TrainingDir + @"\pffmtable", TrainingDir + "\\" + myLang.Name + ".pffmtable", true);

                    Progress = 25;
                    ProcessStatus = "Making " + myLang.Name + ".traineddata...";
                    Slave.ReportProgress(Progress);
                    ExecuteCommand("combine_tessdata.exe", " " + myLang.Name + ".", TrainingDir);
                }
                else
                {
                    MessageBox.Show("Crucial files needed for the training process are missing.  Training failed.");
                }
            }
        }

        private void ExecuteCommand(string command, string parameter, string projectFolder)
        {
            if (myLang != null)
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.UseShellExecute = false;
                info.WorkingDirectory = projectFolder;
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Minimized;
                info.Arguments = parameter;
                info.FileName = db.TessPath + '\\' + command;
                info.RedirectStandardOutput = true;
                info.RedirectStandardError = true;
                Process p = Process.Start(info);
                p.OutputDataReceived += p_OutputDataReceived;
                p.ErrorDataReceived += p_ErrorDataReceived;
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
                p.WaitForExit();
            }
        }

        void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            using (StreamWriter Fout = new StreamWriter(TrainingDir + "\\error.txt", true, Encoding.UTF8))
            {
                Fout.Write(e.Data + "\r\n");
                Fout.Close();
            }
        }

        void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            using (StreamWriter Fout = new StreamWriter(TrainingDir + "\\output.txt", true, Encoding.UTF8))
            {
                Fout.Write(e.Data + "\r\n");
                Fout.Close();
            }
        }

        private void testFolderBrowseButton_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowser.ShowDialog();

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                testFolderBox.Text = folderBrowser.SelectedPath;
            }
        }

        private void testGoButton_Click(object sender, EventArgs e)
        {
            if (testFolderBox.Text != "")
            {
                string[] TiffImages = Directory.GetFiles(testFolderBox.Text, "*.tif");
                if (TiffImages.Length > 0)
                {
                    foreach (string TiffImage in TiffImages)
                    {
                        string JustFileName = "";
                        string[] FileParts = TiffImage.Split(new char[] { '\\' });
                        if (FileParts.Length > 0)
                        {
                            JustFileName = FileParts[FileParts.Length - 1];
                        }

                        if (JustFileName != "")
                        {
                            ExecuteCommand("tesseract.exe", " -l " + myLang.Name + " " + JustFileName + " " + JustFileName.Replace(".tif", ""), testFolderBox.Text);
                        }
                    }
                }
            }
        }
    }
}
