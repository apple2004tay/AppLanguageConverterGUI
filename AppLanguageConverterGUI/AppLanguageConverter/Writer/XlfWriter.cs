using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using AppLanguageConverter.Tool;
using AppLanguageConverter.Data;

namespace AppLanguageConverter.Writer
{
    internal class XlfWriter
    {
        private bool replaceLinBreak;

        public void CreateXlfFile(string path, List<string> headerList, int mainLanguageIndex, Dictionary<string, LanguageData> languageDic, bool replaceLinBreak)
        {
            this.replaceLinBreak = replaceLinBreak;
            string soureLanguageCode = Utility.GetLanguageCode(headerList[mainLanguageIndex]);

            for (int i = 0; i < headerList.Count; i++)
            {
                if (i == mainLanguageIndex)
                {
                    continue;
                }

                string currentHeader = headerList[i];
                string currentLanguageCode = Utility.GetLanguageCode(currentHeader);
                string xlfFileName = GetXlfFileName(currentHeader);

                if (!string.IsNullOrEmpty(xlfFileName))
                {
                    string xlfFilePath = $"{path}\\{xlfFileName}";

                    // https://csharp.net-tutorials.com/xml/writing-xml-with-the-xmldocument-class/
                    XmlDocument xmlDoc = new XmlDocument();

                    // ?xml
                    XmlDeclaration xmldecl = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                    xmlDoc.AppendChild(xmldecl);

                    // xliff
                    XmlNode xliffNode = xmlDoc.CreateElement("xliff");

                    xliffNode.Attributes.Append(CreateXmlAttribute(xmlDoc, "version", "1.2"));
                    xliffNode.Attributes.Append(CreateXmlAttribute(xmlDoc, "xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance"));
                    xliffNode.Attributes.Append(CreateXmlAttribute(xmlDoc, "xsi:schemaLocation", "urn:oasis:names:tc:xliff:document:1.2 xliff-core-1.2-transitional.xsd"));

                    xmlDoc.AppendChild(xliffNode);

                    // file
                    XmlNode fileNode = xmlDoc.CreateElement("file");

                    fileNode.Attributes.Append(CreateXmlAttribute(xmlDoc, "datatype", "xml"));
                    fileNode.Attributes.Append(CreateXmlAttribute(xmlDoc, "source-language", soureLanguageCode));
                    fileNode.Attributes.Append(CreateXmlAttribute(xmlDoc, "target-language", currentLanguageCode));
                    fileNode.Attributes.Append(CreateXmlAttribute(xmlDoc, "original", "OINTRADE/MULTILANGUAGE/APPLANGUAGE.RESX"));
                    fileNode.Attributes.Append(CreateXmlAttribute(xmlDoc, "tool-id", "MultilingualAppToolkit"));
                    fileNode.Attributes.Append(CreateXmlAttribute(xmlDoc, "product-name", "n/a"));
                    fileNode.Attributes.Append(CreateXmlAttribute(xmlDoc, "product-version", "n/a"));
                    fileNode.Attributes.Append(CreateXmlAttribute(xmlDoc, "build-num", "n/a"));

                    xliffNode.AppendChild(fileNode);

                    // header
                    XmlNode headerNode = xmlDoc.CreateElement("header");
                    xliffNode.AppendChild(headerNode);

                    // tool
                    XmlNode toolNode = xmlDoc.CreateElement("tool");
                    toolNode.Attributes.Append(CreateXmlAttribute(xmlDoc, "tool-id", "MultilingualAppToolkit"));
                    toolNode.Attributes.Append(CreateXmlAttribute(xmlDoc, "tool-name", "Multilingual App Toolkit"));
                    toolNode.Attributes.Append(CreateXmlAttribute(xmlDoc, "tool-version", "4.0.6900.0"));
                    toolNode.Attributes.Append(CreateXmlAttribute(xmlDoc, "tool-company", "Microsoft"));

                    headerNode.AppendChild(toolNode);

                    // body
                    XmlNode bodyNode = xmlDoc.CreateElement("body");
                    xliffNode.AppendChild(bodyNode);

                    // group
                    XmlNode groupNode = xmlDoc.CreateElement("group");
                    groupNode.Attributes.Append(CreateXmlAttribute(xmlDoc, "id", "OINTRADE/MULTILANGUAGE/APPLANGUAGE.RESX"));
                    groupNode.Attributes.Append(CreateXmlAttribute(xmlDoc, "datatype", "resx"));

                    bodyNode.AppendChild(groupNode);

                    foreach (var item in languageDic)
                    {
                        var language = item.Value;

                        // trans-unit
                        XmlNode transunitNode = xmlDoc.CreateElement("trans-unit");
                        transunitNode.Attributes.Append(CreateXmlAttribute(xmlDoc, "id", language.LanguageID));
                        transunitNode.Attributes.Append(CreateXmlAttribute(xmlDoc, "translate", "yes"));
                        transunitNode.Attributes.Append(CreateXmlAttribute(xmlDoc, "xml:space", "preserve"));

                        groupNode.AppendChild(transunitNode);

                        // source
                        XmlNode sourceNode = xmlDoc.CreateElement("source");
                        sourceNode.InnerText = Utility.GetLanguageText(language, headerList[mainLanguageIndex], replaceLinBreak);
                        transunitNode.AppendChild(sourceNode);

                        //target
                        XmlNode targetNode = xmlDoc.CreateElement("target");
                        targetNode.Attributes.Append(CreateXmlAttribute(xmlDoc, "state", "translated"));
                        targetNode.InnerText = Utility.GetLanguageText(language, currentHeader, replaceLinBreak);
                        transunitNode.AppendChild(targetNode);
                    }

                    xmlDoc.Save(xlfFilePath);
                }
            }
        }

        private XmlAttribute CreateXmlAttribute(XmlDocument xmlDoc, string attributeKey, string attributeValue)
        {
            var attribute = xmlDoc.CreateAttribute(attributeKey);
            attribute.Value = attributeValue;
            return attribute;
        }

        private string GetXlfFileName(string languageName)
        {
            string languageCode = Utility.GetLanguageCode(languageName);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Ointrade");
            stringBuilder.Append($".{languageCode}");
            stringBuilder.Append(".xlf");
            return stringBuilder.ToString();
        }
    }
}
