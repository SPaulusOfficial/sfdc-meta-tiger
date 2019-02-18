using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Salesforce_Package.Xml.CustomObject
{
	[Serializable()]
	[XmlRoot(ElementName="picklistValues", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class PicklistValues {
		[XmlElement(ElementName="picklist", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Picklist { get; set; }
		[XmlElement(ElementName="values", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<Values> Values { get; set; }
	}

}
