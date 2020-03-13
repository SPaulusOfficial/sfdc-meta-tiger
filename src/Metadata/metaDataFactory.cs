using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MetaTiger.Metadata
{
    class MetaDataFactory {
        
        public static IMetadata getMetadata(String Metadata){
            
            switch (Metadata)
			{
				case MetaConstants.AppMenu: return new MetaAppMenu();
				case MetaConstants.ApexClass: return new MetaApexClass();
				case MetaConstants.ApexTrigger: return new MetaApexTrigger();
				case MetaConstants.ApexComponent: return new MetaApexComponent();
				case MetaConstants.ApexPage: return new MetaApexPage();
				case MetaConstants.CustomMetadata: return new MetaCustomMetadata();
				case MetaConstants.CustomObject: return new MetaCustomObject();
				case MetaConstants.CustomLabels: return new MetaCustomLabels();
				case MetaConstants.CustomField:return new MetaCustomField();
				case MetaConstants.DelegateGroup:return new MetaDelegateGroup();
				case MetaConstants.EmailTemplate: return new MetaEmailTemplate();
				case MetaConstants.Layout: return new MetaLayout();
				case MetaConstants.PermissionSet: return new MetaPermissionSet();
				case MetaConstants.Profile: return new MetaProfiles();
				case MetaConstants.StaticResource: return new MetaStaticResource();				
				case MetaConstants.RemoteSiteSetting: return new MetaRemoteSiteSetting();				
				case MetaConstants.EntitlementProcess:  return new MetaEntitlementProcess();				
				case MetaConstants.Flow: return new MetaFlow();			
				case MetaConstants.CustomObjectTranslation: return new MetaCustomObjectTranslation();
				case MetaConstants.FlowDefinition:  return new MetaFlowDefinition();					
				case MetaConstants.Settings: return new MetaSettings();			
				case MetaConstants.ListView: return new MetaListView();					
				case MetaConstants.ValidationRule: return new MetaValidationRule();					
				case MetaConstants.RecordType: return new MetaRecordType();			
				case MetaConstants.MilestoneType: return new MetaMilestoneType();				
				case MetaConstants.WebLink:  return new MetaWebLink();			
				case MetaConstants.Workflow: return new MetaWorkflow();
				case MetaConstants.WorkflowRule:return new MetaWorkflowRule();
				case MetaConstants.WorkflowAlert:return new MetaWorkflowAlert();
				case MetaConstants.WorkflowFieldUpdate:return new MetaWorkflowFieldUpdate();
				case MetaConstants.WorkflowTask:return new MetaWorkflowTask();
				case MetaConstants.StandardValueSet: return new MetaStandardValueSet();
				case MetaConstants.CustomTab: return new MetaCustomTab();
				case MetaConstants.AssignmentRules: return new MetaAssignmentRules();
				case MetaConstants.AssignmentRule: return new metaAssignmentRule();
				case MetaConstants.AuraDefinitionBundle: return new metaAuraDefinitionBundle();
				case MetaConstants.LightningComponentBundle: return new metaLightningComponentBundle();
				case MetaConstants.CompactLayout: return new metaCompactLayout();
				case MetaConstants.CustomApplication: return new metaCustomApplication();
				case MetaConstants.FlexiPage: return new metaFlexiPage();
				case MetaConstants.Territory2Type: return new metaTerritory2Type();
				case MetaConstants.Territory2: return new metaTerritory2();
				case MetaConstants.Territory2Model: return new metaTerritory2Model();
				case MetaConstants.ContentAsset: return new metaContentAsset();
				case MetaConstants.SharingRules: return new metaSharingRules();
				case MetaConstants.BrandingSet: return new metaBrandingSet();
				case MetaConstants.LightningExperienceTheme: return new metaLightningExperienceTheme();
				case MetaConstants.Group:return new MetaGroup();
				case MetaConstants.DuplicateRule:return new metaDuplicateRule();
				case MetaConstants.LeadConvertSettings:return new metaLeadConvertSettings();
				case MetaConstants.MatchingRule:return new metaMatchingRule();
				case MetaConstants.PathAssistant:return new metaPathAssistant();
				case MetaConstants.QuickAction:return new metaQuickAction();
				case MetaConstants.BusinessProcess:return new metaBusinessProcess();
				case MetaConstants.GlobalValueSet:return new metaGlobalValueSet();
				case MetaConstants.CustomNotificationType:return new metaCustomNotificationType();
				case MetaConstants.Report:return new metaReport();
				case MetaConstants.Queue:return new MetaQueue();
				case MetaConstants.SharingCriteriaRule:return new metaSharingCriteriaRule();
				case MetaConstants.AccountRelationshipShareRule:return new metaAccountRelationshipShareRule();
				case MetaConstants.ActionLinkGroupTemplate:return new metaActionLinkGroupTemplate();
				case MetaConstants.AnalyticSnapshot:return new metaAnalyticSnapshot();
				case MetaConstants.Audience:return new metaAudience();
				case MetaConstants.AuthProvider:return new metaAuthProvider();
				case MetaConstants.AutoResponseRule:return new metaAutoResponseRule();
				case MetaConstants.AutoResponseRules:return new metaAutoResponseRules();
				case MetaConstants.Dashboard:return new metaDashboard();
				case MetaConstants.ApprovalProcess:return new MetaApprovalProcess();
				case MetaConstants.ReportType:return new metaReportType();
				default: throw new System.ArgumentException("Metadata not found", Metadata);
			}
		}
	}
}
