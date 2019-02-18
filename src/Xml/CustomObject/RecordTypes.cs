using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Salesforce_Package.Xml.CustomObject
{
	[Serializable()]
	[XmlRoot(ElementName="recordTypes", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class RecordTypes {
		[XmlElement(ElementName="fullName", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string FullName { get; set; }
		[XmlElement(ElementName="active", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Active { get; set; }
		[XmlElement(ElementName="label", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Label { get; set; }
		[XmlElement(ElementName="picklistValues", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<PicklistValues> PicklistValues { get; set; }
	}

}
