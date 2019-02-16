using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Salesforce_Package
{
    class DirectoryContants {

		public const string ApexClass = "ApexClass";
		public const string ApexTrigger = "ApexTrigger";
		public const string ApexComponent = "ApexComponent";
		public const string ApexPage = "ApexPage";
		public const string CustomMetadata = "CustomMetadata";
		public const string CustomObject = "CustomObject";
		public const string CustomField = "CustomField";
		public const string EmailTemplate = "EmailTemplate";
		public const string Layout = "Layout";
		public const string PermissionSet = "PermissionSet";
		public const string Profile = "Profile";
		public const string StaticResource = "StaticResource";
		public const string RemoteSiteSetting = "RemoteSiteSetting";
		public const string Flow = "Flow";
		public const string FlowDefinition = "FlowDefinition";
		public const string EntitlementProcess = "EntitlementProcess";
		public static String renameDirectoryMetaData(String typeMetadata){
			
			switch (typeMetadata)
			{
				case ApexClass: return "classes";
				case ApexTrigger: return "triggers";
				case ApexComponent: return "components";
				case ApexPage: return "pages";
				case CustomMetadata: return "customMetadata";
				case CustomObject: return "objects";
				case CustomField: return "customfields";
				case EmailTemplate: return "email";
				case Layout: return "layouts";
				case PermissionSet: return "permissionsets";
				case Profile: return "profiles";
				case StaticResource: return "staticresources";				
				case RemoteSiteSetting: return "remoteSiteSettings";				
				case EntitlementProcess: return "entitlementProcesses";				
				case Flow: return "flows";				
				case FlowDefinition: return "flowDefinitions";				
				default: throw new System.ArgumentException("Metadata not found", typeMetadata);
			}
		}
		
	}
}
