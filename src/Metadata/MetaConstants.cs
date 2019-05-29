using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace Salesforce_Package
{
    class MetaConstants {

		public const string ApexClass = "ApexClass";
		public const string ApexTrigger = "ApexTrigger";
		public const string ApexComponent = "ApexComponent";
		public const string ApexPage = "ApexPage";
		public const string CustomMetadata = "CustomMetadata";
		public const string CustomObject = "CustomObject";
		public const string CustomField = "CustomField";
		public const string ListView = "ListView";
		public const string EmailTemplate = "EmailTemplate";
		public const string Layout = "Layout";
		public const string PermissionSet = "PermissionSet";
		public const string Profile = "Profile";
		public const string StaticResource = "StaticResource";
		public const string RemoteSiteSetting = "RemoteSiteSetting";
		public const string Flow = "Flow";
		public const string FlowDefinition = "FlowDefinition";
		public const string Settings = "Settings";
		public const string ValidationRule = "ValidationRule";
		public const string EntitlementProcess = "EntitlementProcess";
		public const string RecordType = "RecordType";
		public const string MilestoneType = "MilestoneType";
		public const string WebLink = "WebLink";
		public const string Workflow = "Workflow";
		public const string WorkflowRule = "WorkflowRule";
		public const string StandardValueSet = "StandardValueSet";
		public const string AssignmentRules = "AssignmentRules";
		public const string CustomTab = "CustomTab";

		public static readonly IList<String> metas = new ReadOnlyCollection<string>
    (new List<String> { 
        ApexClass,ApexTrigger,ApexComponent,ApexPage,CustomMetadata,CustomObject,CustomField,ListView,
				EmailTemplate,Layout,PermissionSet,Profile,StaticResource,RemoteSiteSetting,Flow,FlowDefinition,
				Settings,ValidationRule,EntitlementProcess,RecordType,MilestoneType,WebLink,Workflow,WorkflowRule,
				StandardValueSet,AssignmentRules,CustomTab
				});
			
	}
}
