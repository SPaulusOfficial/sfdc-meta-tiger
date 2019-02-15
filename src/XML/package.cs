using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Salesforce_Package.XML
{
    [Serializable()]
    [XmlRoot(ElementName="Package", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class Package {
		[XmlElement(ElementName="types", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<Types> Types { get; set; }
		[XmlElement(ElementName="version", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Version { get; set; }
		[XmlAttribute(AttributeName="xmlns")]
		public string Xmlns { get; set; }
	}
}
