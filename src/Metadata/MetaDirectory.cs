using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MetaTiger
{
    class MetaDirectory {

		public static String getDirectory(String typeMetadata){
			
			switch (typeMetadata)
			{
				case MetaConstants.AccountRelationshipShareRule: return "accountRelationshipShareRules";
				case MetaConstants.ActionLinkGroupTemplate: return "actionLinkGroupTemplates";
				case MetaConstants.AnalyticSnapshot: return "analyticSnapshots";
				case MetaConstants.Audience: return "audience";
				case MetaConstants.AuthProvider: return "authproviders";
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
				case MetaConstants.WebLink: return "_weblinks";				
				case MetaConstants.Workflow: return "workflows";
				case MetaConstants.WorkflowRule: return "_workflowrule";
				case MetaConstants.WorkflowAlert: return "_workflowAlert";
				case MetaConstants.WorkflowFieldUpdate: return "_workflowfieldupdate";
				case MetaConstants.WorkflowTask: return "_workflowtask";
				case MetaConstants.StandardValueSet: return "standardValueSets";
				case MetaConstants.CustomTab: return "tabs";
				case MetaConstants.AssignmentRules: return "assignmentRules";
				case MetaConstants.AssignmentRule: return "assignmentRules";
				case MetaConstants.AutoResponseRule: return "autoResponseRules";
				case MetaConstants.AutoResponseRules: return "autoResponseRules";
				case MetaConstants.AuraDefinitionBundle: return "aura";
				case MetaConstants.CompactLayout: return "_compactlayout";
				case MetaConstants.BusinessProcess: return "_businessProcesses";
				case MetaConstants.CustomApplication: return "applications";
				case MetaConstants.FlexiPage: return "flexipages";
				case MetaConstants.Territory2Type: return "territory2Types";
				case MetaConstants.Territory2: return "territory2Models";
				case MetaConstants.Territory2Model: return "territory2Models";
				case MetaConstants.ContentAsset: return "contentassets";
				case MetaConstants.SharingRules: return "sharingRules";
				case MetaConstants.SharingCriteriaRule: return "sharingRules";
				case MetaConstants.BrandingSet: return "brandingSets";
				case MetaConstants.LightningExperienceTheme: return "lightningExperienceThemes";
				case MetaConstants.LightningComponentBundle: return "lwc";
				case MetaConstants.Group: return "groups";
				case MetaConstants.DuplicateRule: return "duplicateRules";
				case MetaConstants.LeadConvertSettings: return "LeadConvertSettings";
				case MetaConstants.MatchingRule: return "matchingRules";
				case MetaConstants.PathAssistant: return "pathAssistants";
				case MetaConstants.QuickAction: return "quickActions";
				case MetaConstants.GlobalValueSet: return "globalValueSets";
				case MetaConstants.CustomNotificationType: return "notificationtypes";
				case MetaConstants.Report: return "reports";
				case MetaConstants.Queue: return "queues";
				case MetaConstants.Dashboard: return "dashboards";
				case MetaConstants.ApprovalProcess: return "approvalProcesses";
				case MetaConstants.ReportType: return "reportTypes";
				case MetaConstants.Document: return "documents";
				case MetaConstants.Letterhead: return "letterhead";
				case MetaConstants.WaveApplication : return "wave";
				case MetaConstants.WaveDashboard : return "wave";
				case MetaConstants.WaveDataflow : return "wave";
				case MetaConstants.WaveDataset : return "wave";
				case MetaConstants.WaveLens : return "wave";
				case MetaConstants.WaveRecipe : return "wave";
				case MetaConstants.WaveXmd : return "wave";
				case MetaConstants.WaveTemplateBundle : return "waveTemplates";
				default: throw new System.ArgumentException("Directory not found for Metadata:", typeMetadata);
			}
		}
		
	}
}
