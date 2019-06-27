using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace MetaTiger.Xml.Workflow
{
	[Serializable()]
	[XmlRoot(ElementName="Workflow", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class Workflow {
		[XmlElement(ElementName="alerts", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<Alerts> Alerts { get; set; }
		[XmlElement(ElementName="fieldUpdates", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<FieldUpdates> FieldUpdates { get; set; }
		[XmlElement(ElementName="rules", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<Rules> Rules { get; set; }
		[XmlElement(ElementName="tasks", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<Tasks> Tasks { get; set; }
		[XmlAttribute(AttributeName="xmlns")]
		public string Xmlns { get; set; }
	}

}
