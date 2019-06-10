using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace MetaTiger.Xml.Workflow
{
	[Serializable()]
	[XmlRoot(ElementName="alerts", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class Alerts {
		[XmlElement(ElementName="fullName", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string FullName { get; set; }
		[XmlElement(ElementName="description", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Description { get; set; }
		[XmlElement(ElementName="protected", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Protected { get; set; }
		[XmlElement(ElementName="recipients", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<Recipients> Recipients { get; set; }
		[XmlElement(ElementName="senderAddress", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string SenderAddress { get; set; }
		[XmlElement(ElementName="senderType", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string SenderType { get; set; }
		[XmlElement(ElementName="template", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Template { get; set; }
		[XmlElement(ElementName="ccEmails", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string CcEmails { get; set; }
	}

}
