using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Salesforce_Package.Xml.Workflow
{
	[Serializable()]
	[XmlRoot(ElementName="fieldUpdates", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class FieldUpdates {
		[XmlElement(ElementName="fullName", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string FullName { get; set; }
		[XmlElement(ElementName="field", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Field { get; set; }
		[XmlElement(ElementName="formula", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Formula { get; set; }
		[XmlElement(ElementName="name", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Name { get; set; }
		[XmlElement(ElementName="notifyAssignee", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string NotifyAssignee { get; set; }
		[XmlElement(ElementName="operation", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Operation { get; set; }
		[XmlElement(ElementName="protected", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Protected { get; set; }
		[XmlElement(ElementName="description", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Description { get; set; }
		[XmlElement(ElementName="literalValue", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string LiteralValue { get; set; }
		[XmlElement(ElementName="reevaluateOnChange", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string ReevaluateOnChange { get; set; }
		[XmlElement(ElementName="lookupValue", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string LookupValue { get; set; }
		[XmlElement(ElementName="lookupValueType", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string LookupValueType { get; set; }
	}

}
