using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Salesforce_Package
{
	[Serializable()]
	[XmlRoot(ElementName="searchLayouts", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class SearchLayouts {
		[XmlElement(ElementName="customTabListAdditionalFields", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<string> CustomTabListAdditionalFields { get; set; }
		[XmlElement(ElementName="lookupDialogsAdditionalFields", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<string> LookupDialogsAdditionalFields { get; set; }
		[XmlElement(ElementName="lookupPhoneDialogsAdditionalFields", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<string> LookupPhoneDialogsAdditionalFields { get; set; }
		[XmlElement(ElementName="searchFilterFields", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<string> SearchFilterFields { get; set; }
		[XmlElement(ElementName="searchResultsAdditionalFields", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<string> SearchResultsAdditionalFields { get; set; }
	}

}
