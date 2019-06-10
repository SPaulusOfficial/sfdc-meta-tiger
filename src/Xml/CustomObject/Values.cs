using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace MetaTiger.Xml.CustomObject
{
	[Serializable()]
	[XmlRoot(ElementName="values", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class Values {
		[XmlElement(ElementName="fullName", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string FullName { get; set; }
		[XmlElement(ElementName="default", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Default { get; set; }
	}

}
