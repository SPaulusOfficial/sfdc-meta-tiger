using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace MetaTiger.Xml.CustomObject
{
	[Serializable()]
	[XmlRoot(ElementName="webLinks", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class WebLink {
		[XmlElement(ElementName="fullName", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string FullName { get; set; }
		[XmlElement(ElementName="availability", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Availability { get; set; }
		[XmlElement(ElementName="displayType", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string DisplayType { get; set; }
		[XmlElement(ElementName="hasMenubar", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string HasMenubar { get; set; }
		[XmlElement(ElementName="hasScrollbars", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string HasScrollbars { get; set; }
		[XmlElement(ElementName="hasToolbar", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string HasToolbar { get; set; }
		[XmlElement(ElementName="height", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Height { get; set; }
		[XmlElement(ElementName="isResizable", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string IsResizable { get; set; }
		[XmlElement(ElementName="linkType", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string LinkType { get; set; }
		[XmlElement(ElementName="masterLabel", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string MasterLabel { get; set; }
		[XmlElement(ElementName="openType", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string OpenType { get; set; }
		[XmlElement(ElementName="page", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Page { get; set; }
		[XmlElement(ElementName="position", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Position { get; set; }
		[XmlElement(ElementName="protected", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Protected { get; set; }
		[XmlElement(ElementName="showsLocation", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string ShowsLocation { get; set; }
		[XmlElement(ElementName="showsStatus", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string ShowsStatus { get; set; }
	}

}
