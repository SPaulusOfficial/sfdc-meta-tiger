using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace MetaTiger.Xml.CustomObject
{
	[Serializable()]
	[XmlRoot(ElementName="listViews", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class _ListViews {
		[XmlElement(ElementName="fullName", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string FullName { get; set; }
		[XmlElement(ElementName="columns", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<string> Columns { get; set; }
		[XmlElement(ElementName="filterScope", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string FilterScope { get; set; }
		[XmlElement(ElementName="filters", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public Filters Filters { get; set; }
		[XmlElement(ElementName="label", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Label { get; set; }
		[XmlElement(ElementName="sharedTo", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public SharedTo SharedTo { get; set; }
	}

}
