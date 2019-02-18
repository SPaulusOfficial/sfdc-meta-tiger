using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Salesforce_Package
{
    class MetaDirectory {

		public static String getDirectory(String typeMetadata){
			
			switch (typeMetadata)
			{
				case MetaConstants.ApexClass: return "classes";
				case MetaConstants.ApexTrigger: return "triggers";
				case MetaConstants.ApexComponent: return "components";
				case MetaConstants.ApexPage: return "pages";
				case MetaConstants.CustomMetadata: return "customMetadata";
				case MetaConstants.CustomObject: return "objects";
				case MetaConstants.CustomField: return "_customfield";
				case MetaConstants.EmailTemplate: return "email";
				case MetaConstants.Layout: return "layouts";
				case MetaConstants.PermissionSet: return "permissionsets";
				case MetaConstants.Profile: return "profiles";
				case MetaConstants.StaticResource: return "staticresources";				
				case MetaConstants.RemoteSiteSetting: return "remoteSiteSettings";				
				case MetaConstants.EntitlementProcess: return "entitlementProcesses";				
				case MetaConstants.Flow: return "flows";				
				case MetaConstants.FlowDefinition: return "flowDefinitions";				
				case MetaConstants.Settings: return "settings";				
				case MetaConstants.ListView: return "_listview";				
				case MetaConstants.ValidationRule: return "_validationrule";				
				case MetaConstants.RecordType: return "_recordtype";				
				case MetaConstants.MilestoneType: return "milestoneTypes";				
				case MetaConstants.WebLink: return "weblinks";				
				case MetaConstants.Workflow: return "workflows";
				case MetaConstants.WorkflowRule: return "_workflowrule";
				case MetaConstants.StandardValueSet: return "standardValueSets";
				default: throw new System.ArgumentException("Directory not found for Metadata:", typeMetadata);
			}
		}
		
	}
}
