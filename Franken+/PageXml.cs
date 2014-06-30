using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Franken_.App_Code;

namespace Franken_
{
    /// <summary>
    /// Class for handling page xml file specific behavior.
    /// </summary>
    abstract class PageXml
    {
        private XDocument aletheiaDoc;
        private XmlReader reader;
        private XNamespace pageXmlNamespace;

        /// <summary>
        /// Creates a new page xml file object for the specified page xml file in <paramref name="xmlFile"/>
        /// </summary>
        /// <param name="xmlFile">the location of the page xml file</param>
        public PageXml(string xmlFile)
        {
            aletheiaDoc = XDocument.Load(xmlFile);
            reader = aletheiaDoc.CreateReader();
            pageXmlNamespace = GetNamespace(xmlFile);
        }

        /// <summary>
        /// Parses all glyphs from the page xml file.
        /// </summary>
        /// <returns>List of glyph objects with ID and Unicode propagated.</returns>
        public virtual List<Glyph> GetGlyphs()
        {
            /*
             * For some odd reason we have to specify our own xml prefix for the namespace,
             * because .NET didn't accept a URI for the default namespace xmlns. 
             * 
             */
            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(reader.NameTable);
            namespaceManager.AddNamespace("aletheia", pageXmlNamespace.NamespaceName);

            var Extracts = from REC in aletheiaDoc.Descendants(pageXmlNamespace + "Glyph")
                           select new Glyph
                           {
                               ID = (string)(REC.Attribute("id") ?? new XAttribute("id", string.Empty)),
                               Unicode = REC.XPathSelectElement("./aletheia:TextEquiv/aletheia:Unicode", namespaceManager) != null
                                       ? REC.XPathSelectElement("./aletheia:TextEquiv/aletheia:Unicode", namespaceManager).Value
                                       : string.Empty
                           };

            return Extracts.ToList();
        }

        /// <summary>
        /// Returns the path of the ImageExtractor utility relativ to the "GlyphExtraction" folder:
        /// e.g: ImageExtractor 1.1\ImageExtractor-1-1-26.exe
        /// </summary>
        public abstract string ImageExtratorRelPath { get; }

        /// <summary>
        /// Creates the commandline parameter string for the image extractor.
        /// </summary>
        /// <param name="inputImagePath">The path to the image which is described by the page xml file specified in <paramref name="xmlInputPath"/></param>
        /// <param name="xmlInputPath">The page xml files, which describes the image specified in <paramref name="inputImagePath"/></param>
        /// <param name="outputFolderPath">The folder which should contain the glyph images</param>
        /// <returns></returns>
        public abstract string CreateImageExtractorCommandLine(string inputImagePath, string xmlInputPath,
            string outputFolderPath);

        /// <summary>
        /// Returns the URI of the xmlns Namespace from the xml file in <paramref name="path"/>
        /// </summary>
        /// <param name="path">The path to the xml file.</param>
        /// <returns>The URI of the default Namespace</returns>
        internal static string GetNamespace(string path)
        {
            XDocument AletheiaDoc = XDocument.Load(path);
            XmlReader reader = AletheiaDoc.CreateReader();

            /*
             * snippet by Scott Hanselman:
             * http://www.hanselman.com/blog/GetNamespacesFromAnXMLDocumentWithXPathDocumentAndLINQToXML.aspx
             */
            var namespaces = AletheiaDoc.Root.Attributes().
                                Where(a => a.IsNamespaceDeclaration).
                                GroupBy(a => a.Name.Namespace == XNamespace.None ? String.Empty : a.Name.LocalName,
                                        a => XNamespace.Get(a.Value)).
                                ToDictionary(g => g.Key,
                                             g => g.First());


            if (namespaces[""] == null)
            {
                //ToDo: Exception/Error Message (xml file is not a valid page.xml)
            }

            return namespaces[""].NamespaceName;
        }
    }
}
