using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Salesforce_Package.XML
{
	[Serializable()]
	[XmlRoot(ElementName="valueSet", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class ValueSet {
		[XmlElement(ElementName="valueSetDefinition", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public ValueSetDefinition ValueSetDefinition { get; set; }
		[XmlElement(ElementName="restricted", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Restricted { get; set; }
		[XmlElement(ElementName="valueSetName", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string ValueSetName { get; set; }
	}

}
