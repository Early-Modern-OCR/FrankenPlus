using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace TesseractTrainer.App_Code
{
    class DataPipe
    {
        MySqlConnection Conn;
        MySqlCommand SQL;
        MySqlDataAdapter Funnel;
        public DataTable Bucket;

        public string LastSQL;
        public string ErrorText;
        public string Trace;
        public string ConnString = "";
        public string ConnStringSansDB = "";
        public string Host = "localhost";
        public string Port = "3306";
        public string Database = "frankenplus";
        public string User = "root";
        public string Password = "Frank3nP1us";
        public string TessPath = @"C:\Program Files (x86)\Tesseract-OCR";

        public string DataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Franken+";

        public DataPipe()
        {
            LoadParams();

            Conn = new MySqlConnection(ConnString);
            SQL = new MySqlCommand();
            Funnel = new MySqlDataAdapter();
            Bucket = new DataTable();
            SQL.Connection = Conn;
            Funnel.SelectCommand = SQL;
        }

        public void LoadParams()
        {
            if (File.Exists(DataDirectory + "\\db.conf"))
            {
                StreamReader Fin = new StreamReader(DataDirectory + "\\db.conf");
                string Line = "";

                while ((Line = Fin.ReadLine()) != null)
                {
                    if (!Line.StartsWith("#"))
                    {
                        string[] Parts = Line.Split(new char[] { '=' });
                        if (Parts.Length == 2)
                        {
                            string Param = Parts[0].Trim();
                            string Value = Parts[1].Trim();

                            switch (Param)
                            {
                                case "Host": Host = Value;
                                    break;
                                case "Port": Port = Value;
                                    break;
                                case "Database": Database = Value;
                                    break;
                                case "User": User = Value;
                                    break;
                                case "Password": Password = Value;
                                    break;
                                case "TessPath": TessPath = Value;
                                    break;
                            }
                        }
                    }
                }
                Fin.Close();
            }
            else
            {
                SaveParams();
            }

            ConnString = "Server=" + Host + ";Port=" + Port + ";Uid=" + User + ";Pwd=" + Password + ";Database=" + Database + ";CharSet=utf8;";
            ConnStringSansDB = "Server=" + Host + ";Port=" + Port + ";Uid=" + User + ";Pwd=" + Password + ";CharSet=utf8;";
        }

        public void CreateDatabase()
        {
            Conn.ConnectionString = ConnStringSansDB;

            try
            {
                Conn.Open();
                SQL.CommandText = "create database if not exists `" + this.Database + "`";
                SQL.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception E)
            {
                ErrorText = E.Message;
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }

            Conn.ConnectionString = ConnString;
        }

        public void SaveParams()
        {
            StreamWriter Fout = new StreamWriter(DataDirectory + "\\db.conf", false);
            Fout.WriteLine("Host=" + Host);
            Fout.WriteLine("Port=" + Port);
            Fout.WriteLine("Database=" + Database);
            Fout.WriteLine("User=" + User);
            Fout.WriteLine("Password=" + Password);
            Fout.WriteLine("TessPath=" + TessPath);
            Fout.Close();
        }

        public string CheckConnection()
        {
            string Results = "";
            bool ConnGood = false;
            bool DBExists = false;

            Conn.ConnectionString = ConnStringSansDB;
            try
            {
                Conn.Open();
                if (Conn.State == ConnectionState.Open)
                {
                    ConnGood = true;
                }
                Conn.Close();
            }
            catch (Exception E)
            {
                Results = "Unable to connect to the database server.  Please verify connection settings in Menu->Settings.  Error Message: " + E.Message;
            }
            Conn.ConnectionString = ConnString;

            if (Results == "" && ConnGood)
            {
                try
                {
                    Conn.Open();
                    if (Conn.State == ConnectionState.Open)
                    {
                        DBExists = true;
                    }
                    Conn.Close();
                }
                catch (Exception E)
                {
                    Results = "Connected to the database server, but you probably need to reset the database by going to Menu->Settings->Reset Database.  Error message: " + E.Message;
                }
            }

            if (ConnGood && DBExists)
            {
                Results = "Connection successful, and database found!";
            }

            return Results;
        }

        public bool GetRows(string SelectStatement)
        {
            LastSQL = SelectStatement;
            Bucket.Reset();
            bool Got = false;
            try
            {
                Conn.Open();
                SQL.CommandText = SelectStatement;
                Funnel.Fill(Bucket);
                if (Bucket.Rows.Count > 0)
                {
                    Got = true;
                }
                Conn.Close();
            }
            catch (Exception E)
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
                ReportError(E.Message, "GetRows");
            }
            return Got;
        }

        public string GetCell(int Row, string Column)
        {
            string Cell = "";

            if (Bucket.Rows.Count >= (Row + 1))
            {
                Cell = Bucket.Rows[Row][Column].ToString();
            }

            return Cell;
        }

        public bool ExecuteCommand(string CommandStatement)
        {
            LastSQL = CommandStatement;
            bool Executed = false;
            try
            {
                Conn.Open();
                SQL.CommandText = CommandStatement;
                if (SQL.ExecuteNonQuery() > 0)
                {
                    Executed = true;
                }
                Conn.Close();
            }
            catch (Exception E)
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
                ReportError(E.Message, "ExecuteCommand");
            }

            return Executed;
        }

        //Makes a new ID (increments the highest one) based on the table name
        public string GetNewID(string TableName)
        {
            string NewID = "0";

            ExecuteCommand("update `keys` set keys_max = keys_max + 1 where keys_table = '" + TableName + "'");
            if (GetRows("select keys_max from `keys` where keys_table = '" + TableName + "'"))
            {
                NewID = Bucket.Rows[0][0].ToString();
            }

            return NewID;
        }

        private void ReportError(string Error, string Method)
        {
            System.IO.StreamWriter LogOut = new System.IO.StreamWriter(DataDirectory + "\\Error.txt", true);
            LogOut.WriteLine("Error at " + System.DateTime.Now.ToString() + ": " + Error + "<br><br>Last SQL: " + SQL.CommandText + "<br><br>Method: " + Method + "<br><br>Trace: " + Trace);
            LogOut.Close();
        }

        public string FixString(string DirtyString)
        {
            string FixedString = DirtyString.Replace("\\", "\\\\")
                .Replace("'", "''");

            return FixedString;
        }
    }
}
