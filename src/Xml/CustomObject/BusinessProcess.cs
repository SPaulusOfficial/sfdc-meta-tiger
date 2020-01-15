using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace MetaTiger.Xml.CustomObject
{
	[Serializable()]
	[XmlRoot(ElementName="businessProcesses", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class _BusinessProcess {
		[XmlElement(ElementName="fullName", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string FullName { get; set; }
		[XmlElement(ElementName="description", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Description { get; set; }
		[XmlElement(ElementName="isActive", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string IsActive { get; set; }
		[XmlElement(ElementName="values", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<Values> Values { get; set; }
	}

}
