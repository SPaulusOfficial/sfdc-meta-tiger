using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Salesforce_Package.XML
{
	[Serializable()]
	[XmlRoot(ElementName="CustomObject", Namespace="http://soap.sforce.com/2006/04/metadata")]
	public class CustomObject {
		[XmlElement(ElementName="actionOverrides", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<ActionOverrides> ActionOverrides { get; set; }
		[XmlElement(ElementName="allowInChatterGroups", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string AllowInChatterGroups { get; set; }
		[XmlElement(ElementName="compactLayoutAssignment", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string CompactLayoutAssignment { get; set; }
		[XmlElement(ElementName="deploymentStatus", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string DeploymentStatus { get; set; }
		[XmlElement(ElementName="enableActivities", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string EnableActivities { get; set; }
		[XmlElement(ElementName="enableBulkApi", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string EnableBulkApi { get; set; }
		[XmlElement(ElementName="enableFeeds", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string EnableFeeds { get; set; }
		[XmlElement(ElementName="enableHistory", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string EnableHistory { get; set; }
		[XmlElement(ElementName="enableLicensing", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string EnableLicensing { get; set; }
		[XmlElement(ElementName="enableReports", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string EnableReports { get; set; }
		[XmlElement(ElementName="enableSearch", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string EnableSearch { get; set; }
		[XmlElement(ElementName="enableSharing", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string EnableSharing { get; set; }
		[XmlElement(ElementName="enableStreamingApi", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string EnableStreamingApi { get; set; }
		[XmlElement(ElementName="externalSharingModel", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string ExternalSharingModel { get; set; }
		[XmlElement(ElementName="fields", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<Fields> Fields { get; set; }
		[XmlElement(ElementName="gender", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Gender { get; set; }
		[XmlElement(ElementName="label", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Label { get; set; }
		[XmlElement(ElementName="listViews", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<_ListViews> ListViews { get; set; }
		[XmlElement(ElementName="nameField", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public NameField NameField { get; set; }
		[XmlElement(ElementName="pluralLabel", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string PluralLabel { get; set; }
		[XmlElement(ElementName="recordTypeTrackFeedHistory", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string RecordTypeTrackFeedHistory { get; set; }
		[XmlElement(ElementName="recordTypeTrackHistory", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string RecordTypeTrackHistory { get; set; }
		[XmlElement(ElementName="recordTypes", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<RecordTypes> RecordTypes { get; set; }
		[XmlElement(ElementName="searchLayouts", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public SearchLayouts SearchLayouts { get; set; }
		[XmlElement(ElementName="sharingModel", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string SharingModel { get; set; }
		[XmlElement(ElementName="sharingReasons", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<SharingReasons> SharingReasons { get; set; }
		[XmlElement(ElementName="validationRules", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public List<ValidationRules> ValidationRules { get; set; }
		[XmlElement(ElementName="visibility", Namespace="http://soap.sforce.com/2006/04/metadata")]
		public string Visibility { get; set; }
		[XmlAttribute(AttributeName="xmlns")]
		public string Xmlns { get; set; }
	}

}
