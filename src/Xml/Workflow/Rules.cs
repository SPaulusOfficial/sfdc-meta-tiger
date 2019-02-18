using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Salesforce_Package.Xml.Workflow
{
	[Serializable()]
	[XmlRoot(ElementName="rules", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class Rules {
		[XmlElement(ElementName="fullName", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string FullName { get; set; }
		[XmlElement(ElementName="actions", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<Actions> Actions { get; set; }
		[XmlElement(ElementName="active", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Active { get; set; }
		[XmlElement(ElementName="description", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Description { get; set; }
		[XmlElement(ElementName="formula", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Formula { get; set; }
		[XmlElement(ElementName="triggerType", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string TriggerType { get; set; }
		[XmlElement(ElementName="criteriaItems", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<CriteriaItems> CriteriaItems { get; set; }
		[XmlElement(ElementName="workflowTimeTriggers", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public WorkflowTimeTriggers WorkflowTimeTriggers { get; set; }
		[XmlElement(ElementName="booleanFilter", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string BooleanFilter { get; set; }
	}

}
