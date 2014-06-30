using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Franken_
{
    /// <summary>
    /// Factory for creating the correct page xml file object based on the URI of 
    /// the default xml namespace xmlns.
    /// </summary>
    class PageXmlFactory
    {
        /*
         * The page xml created by aletheia v2 and v3 have different xmlns namespaces. Other differences, 
         * which are relevant for the glyph parsing, could not be observed. 
         */
        protected const string V2_NAMESPACE = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2010-03-19";
        protected const string V3_NAMESPACE = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2013-07-15";

        /// <summary>
        /// Returns a page xml object for the page xml in <paramref name="path"/>
        /// </summary>
        /// <param name="path">Path to the page xml file.</param>
        /// <returns>page xml object</returns>
        public static PageXml GetPageXml(string path)
        {

            string pageXmlNamespace = PageXml.GetNamespace(path);

            switch (pageXmlNamespace)
            {
                case V2_NAMESPACE:
                    return new PageXmlV2(path);
                case V3_NAMESPACE:
                    return new PageXmlV3(path);
                default:
                    return new PageXmlV2(path);
            }
        }
    }
}
