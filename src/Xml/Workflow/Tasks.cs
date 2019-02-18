using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Salesforce_Package.Xml.Workflow
{
	[Serializable()]
	[XmlRoot(ElementName="tasks", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class Tasks {
		[XmlElement(ElementName="fullName", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string FullName { get; set; }
		[XmlElement(ElementName="assignedToType", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string AssignedToType { get; set; }
		[XmlElement(ElementName="dueDateOffset", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string DueDateOffset { get; set; }
		[XmlElement(ElementName="notifyAssignee", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string NotifyAssignee { get; set; }
		[XmlElement(ElementName="priority", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Priority { get; set; }
		[XmlElement(ElementName="protected", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Protected { get; set; }
		[XmlElement(ElementName="status", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Status { get; set; }
		[XmlElement(ElementName="subject", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Subject { get; set; }
		[XmlElement(ElementName="assignedTo", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string AssignedTo { get; set; }
		[XmlElement(ElementName="offsetFromField", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string OffsetFromField { get; set; }
		[XmlElement(ElementName="description", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Description { get; set; }
	}

}
