using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace MetaTiger.Xml.CustomObject
{
	[XmlRoot(ElementName="actionOverrides", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class ActionOverrides {
		[XmlElement(ElementName="actionName", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string ActionName { get; set; }
		[XmlElement(ElementName="type", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Type { get; set; }
	}
}
