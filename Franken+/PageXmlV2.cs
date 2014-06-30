using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franken_
{
    class PageXmlV2 : PageXml
    {
        public PageXmlV2(string xmlFile) : base(xmlFile)
        {
        }

        public override string ImageExtratorRelPath
        {
            get { return "ImageExtractor 1.1\\ImageExtractor-1-1-26.exe"; }
        }

        public override string CreateImageExtractorCommandLine(string inputImagePath, string xmlInputPath, string outputFolderPath)
        {
            string options = string.Format("type glyph \"{0}\" \"{1}\" \"{2}\"", inputImagePath, xmlInputPath, outputFolderPath);

            return options;
        }
    }
}
