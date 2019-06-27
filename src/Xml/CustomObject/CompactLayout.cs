using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace MetaTiger.Xml.CustomObject
{
	[Serializable()]
	[XmlRoot(ElementName="compactLayouts", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class _CompactLayouts {
		[XmlElement(ElementName="fullName", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string FullName { get; set; }
		[XmlElement(ElementName="fields", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<string> Fields { get; set; }
		[XmlElement(ElementName="label", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Label { get; set; }
	}

}
