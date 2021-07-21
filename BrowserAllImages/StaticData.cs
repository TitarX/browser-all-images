using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrowserAllImages
{
    public class StaticData
    {
        private static String xmlSchemaForSettings =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<schema xmlns=\"http://www.w3.org/2001/XMLSchema\">" +
            "<element name=\"settings\">" +
            "<complexType mixed=\"false\">" +
            "<sequence>" +
            "<element name=\"mainForm\" maxOccurs=\"1\" minOccurs=\"1\">" +
            "<complexType mixed=\"false\">" +
            "<sequence>" +
            "<element name=\"location\" maxOccurs=\"1\" minOccurs=\"1\">" +
            "<complexType mixed=\"false\">" +
            "<sequence>" +
            "<element name=\"x\" type=\"int\" maxOccurs=\"1\" minOccurs=\"1\" />" +
            "<element name=\"y\" type=\"int\" maxOccurs=\"1\" minOccurs=\"1\" />" +
            "</sequence>" +
            "</complexType>" +
            "</element>" +
            "<element name=\"size\" maxOccurs=\"1\" minOccurs=\"1\">" +
            "<complexType mixed=\"false\">" +
            "<sequence>" +
            "<element name=\"width\" type=\"int\" maxOccurs=\"1\" minOccurs=\"1\" />" +
            "<element name=\"height\" type=\"int\" maxOccurs=\"1\" minOccurs=\"1\" />" +
            "</sequence>" +
            "</complexType>" +
            "</element>" +
            "<element name=\"maximize\" type=\"boolean\" maxOccurs=\"1\" minOccurs=\"1\" />" +
            "</sequence>" +
            "</complexType>" +
            "</element>" +
            "</sequence>" +
            "</complexType>" +
            "</element>" +
            "</schema>";

        public static String XmlSchemaForSettings
        {
            get
            {
                return xmlSchemaForSettings;
            }
        }
    }
}
