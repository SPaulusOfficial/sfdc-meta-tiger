using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace MetaTiger.Xml.CustomObject
{
	[Serializable()]
	[XmlRoot(ElementName="filters", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class Filters {
		[XmlElement(ElementName="field", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Field { get; set; }
		[XmlElement(ElementName="operation", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Operation { get; set; }
		[XmlElement(ElementName="value", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Value { get; set; }
	}

}
