using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Salesforce_Package.Xml.Workflow
{
	[Serializable()]
	[XmlRoot(ElementName="recipients", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class Recipients {
		[XmlElement(ElementName="field", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Field { get; set; }
		[XmlElement(ElementName="type", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Type { get; set; }
		[XmlElement(ElementName="recipient", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Recipient { get; set; }
	}

}
