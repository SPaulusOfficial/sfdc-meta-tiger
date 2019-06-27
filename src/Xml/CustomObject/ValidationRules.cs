using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace MetaTiger.Xml.CustomObject
{
	[Serializable()]
	[XmlRoot(ElementName="validationRules", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class ValidationRules{
		[XmlElement(ElementName="fullName", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string FullName { get; set; }
		[XmlElement(ElementName="active", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Active { get; set; }
		[XmlElement(ElementName="description", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Description { get; set; }
		[XmlElement(ElementName="errorConditionFormula", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string ErrorConditionFormula { get; set; }
		[XmlElement(ElementName="errorMessage", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string ErrorMessage { get; set; }
		[XmlElement(ElementName="errorDisplayField", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string ErrorDisplayField { get; set; }
	}

}
