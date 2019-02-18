using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Salesforce_Package.Xml.CustomObject
{
	[Serializable()]
	[XmlRoot(ElementName="sharedTo", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class SharedTo {
		[XmlElement(ElementName="group", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Group { get; set; }
	}

}
