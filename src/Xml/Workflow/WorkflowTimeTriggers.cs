using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace MetaTiger.Xml.Workflow
{
	[Serializable()]
	[XmlRoot(ElementName="workflowTimeTriggers", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class WorkflowTimeTriggers {
		[XmlElement(ElementName="actions", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<Actions> Actions { get; set; }
		[XmlElement(ElementName="offsetFromField", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string OffsetFromField { get; set; }
		[XmlElement(ElementName="timeLength", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string TimeLength { get; set; }
		[XmlElement(ElementName="workflowTimeTriggerUnit", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string WorkflowTimeTriggerUnit { get; set; }
	}

}
