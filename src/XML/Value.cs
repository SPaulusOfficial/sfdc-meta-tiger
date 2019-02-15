using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Salesforce_Package.XML
{
	[Serializable()]
	[XmlRoot(ElementName="value", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class Value {
		[XmlElement(ElementName="fullName", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string FullName { get; set; }
		[XmlElement(ElementName="default", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Default { get; set; }
		[XmlElement(ElementName="label", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Label { get; set; }
	}

}
