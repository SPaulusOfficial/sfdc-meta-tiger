using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Salesforce_Package.XML
{
	[Serializable()]
	[XmlRoot(ElementName="fields", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class Fields {
		[XmlElement(ElementName="fullName", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string FullName { get; set; }
		[XmlElement(ElementName="defaultValue", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string DefaultValue { get; set; }
		[XmlElement(ElementName="externalId", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string ExternalId { get; set; }
		[XmlElement(ElementName="label", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Label { get; set; }
		[XmlElement(ElementName="trackFeedHistory", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string TrackFeedHistory { get; set; }

        [XmlElement(ElementName="trackHistory", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string TrackHistory { get; set; }
		[XmlElement(ElementName="trackTrending", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string TrackTrending { get; set; }
		[XmlElement(ElementName="type", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Type { get; set; }
		[XmlElement(ElementName="caseSensitive", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string CaseSensitive { get; set; }
		[XmlElement(ElementName="length", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Length { get; set; }
		[XmlElement(ElementName="required", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Required { get; set; }
		[XmlElement(ElementName="unique", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Unique { get; set; }
		[XmlElement(ElementName="deleteConstraint", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string DeleteConstraint { get; set; }
		[XmlElement(ElementName="referenceTo", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string ReferenceTo { get; set; }
		[XmlElement(ElementName="relationshipName", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string RelationshipName { get; set; }
		[XmlElement(ElementName="formula", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Formula { get; set; }
		[XmlElement(ElementName="formulaTreatBlanksAs", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string FormulaTreatBlanksAs { get; set; }
		[XmlElement(ElementName="description", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Description { get; set; }
		[XmlElement(ElementName="precision", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Precision { get; set; }
		[XmlElement(ElementName="scale", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Scale { get; set; }
		[XmlElement(ElementName="visibleLines", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string VisibleLines { get; set; }
		[XmlElement(ElementName="inlineHelpText", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string InlineHelpText { get; set; }
		[XmlElement(ElementName="summaryForeignKey", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string SummaryForeignKey { get; set; }
		[XmlElement(ElementName="summaryOperation", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string SummaryOperation { get; set; }
		[XmlElement(ElementName="valueSet", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public ValueSet ValueSet { get; set; }
		[XmlElement(ElementName="relationshipLabel", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string RelationshipLabel { get; set; }
		[XmlElement(ElementName="displayFormat", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string DisplayFormat { get; set; }
	}

}
