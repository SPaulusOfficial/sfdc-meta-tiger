using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace MetaTiger.Xml.CustomObject
{
	[Serializable()]
	[XmlRoot(ElementName="nameField", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class NameField {
		[XmlElement(ElementName="label", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Label { get; set; }
		[XmlElement(ElementName="trackFeedHistory", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string TrackFeedHistory { get; set; }
		[XmlElement(ElementName="trackHistory", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string TrackHistory { get; set; }
		[XmlElement(ElementName="type", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Type { get; set; }
	}

}
