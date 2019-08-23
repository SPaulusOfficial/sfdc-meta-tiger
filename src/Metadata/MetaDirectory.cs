using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MetaTiger
{
    class MetaDirectory {

		public static String getDirectory(String typeMetadata){
			
			switch (typeMetadata)
			{
				case MetaConstants.AppMenu: return "appMenus";
				case MetaConstants.ApexClass: return "classes";
				case MetaConstants.ApexTrigger: return "triggers";
				case MetaConstants.ApexComponent: return "components";
				case MetaConstants.ApexPage: return "pages";
				case MetaConstants.CustomMetadata: return "customMetadata";
				case MetaConstants.CustomLabels: return "labels";
				case MetaConstants.CustomObject: return "objects";
				case MetaConstants.CustomField: return "_customfield";
				case MetaConstants.EmailTemplate: return "email";
				case MetaConstants.CustomObjectTranslation: return "objectTranslations";
				case MetaConstants.DelegateGroup: return "delegateGroups";
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
				case MetaConstants.CustomTab: return "tabs";
				case MetaConstants.AssignmentRules: return "assignmentRules";
				case MetaConstants.AuraDefinitionBundle: return "aura";
				case MetaConstants.CompactLayout: return "_compactlayout";
				case MetaConstants.CustomApplication: return "applications";
				case MetaConstants.FlexiPage: return "flexipages";
				case MetaConstants.Territory2Type: return "territory2Types";
				case MetaConstants.Territory2: return "territory2Models";
				case MetaConstants.Territory2Model: return "territory2Models";
				case MetaConstants.ContentAsset: return "contentassets";
				case MetaConstants.SharingRules: return "sharingRules";
				case MetaConstants.BrandingSet: return "brandingSets";
				case MetaConstants.LightningExperienceTheme: return "lightningExperienceThemes";
				default: throw new System.ArgumentException("Directory not found for Metadata:", typeMetadata);
			}
		}
		
	}
}
