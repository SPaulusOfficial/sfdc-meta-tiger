using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace MetaTiger.Xml.Workflow
{
	[Serializable()]
	[XmlRoot(ElementName="actions", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class Actions {
		[XmlElement(ElementName="name", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Name { get; set; }
		[XmlElement(ElementName="type", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Type { get; set; }
	}

}
