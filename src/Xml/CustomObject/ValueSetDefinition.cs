using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Salesforce_Package.Xml.CustomObject
{
	[Serializable()]
	[XmlRoot(ElementName="valueSetDefinition", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class ValueSetDefinition {
		[XmlElement(ElementName="sorted", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Sorted { get; set; }
		[XmlElement(ElementName="value", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<Value> Value { get; set; } 
	}

}
