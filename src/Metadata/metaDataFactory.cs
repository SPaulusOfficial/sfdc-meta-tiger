using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Salesforce_Package.Metadata
{
    class MetaDataFactory {
        
        public static IMetadata getMetadata(String Metadata){
            
            switch (Metadata)
			{
				case MetaConstants.ApexClass: return new MetaApexClass();
				case MetaConstants.ApexTrigger: return new MetaApexTrigger();
				case MetaConstants.ApexComponent: return new MetaApexComponent();
				case MetaConstants.ApexPage: return new MetaApexPage();
				case MetaConstants.CustomMetadata: return new MetaCustomMetadata();
				case MetaConstants.CustomObject: return new MetaCustomObject();
				case MetaConstants.CustomField:return new MetaCustomField();
				case MetaConstants.EmailTemplate: return new MetaEmailTemplate();
				case MetaConstants.Layout: return new MetaLayout();
				case MetaConstants.PermissionSet: return new MetaPermissionSet();
				case MetaConstants.Profile: return new MetaProfiles();
				case MetaConstants.StaticResource: return new MetaStaticResource();				
				case MetaConstants.RemoteSiteSetting: return new MetaRemoteSiteSetting();				
				case MetaConstants.EntitlementProcess:  return new MetaEntitlementProcess();				
				case MetaConstants.Flow: return new MetaFlow();			
				case MetaConstants.FlowDefinition:  return new MetaFlowDefinition();					
				case MetaConstants.Settings: return new MetaSettings();			
				case MetaConstants.ListView: return new MetaListView();					
				case MetaConstants.ValidationRule: return new MetaValidationRule();					
				case MetaConstants.RecordType: return new MetaRecordType();			
				case MetaConstants.MilestoneType: return new MetaMilestoneType();				
				case MetaConstants.WebLink:  return new MetaWebLink();			
				case MetaConstants.Workflow: return new MetaWorkflow();
				case MetaConstants.WorkflowRule:return new MetaWorkflowRule();
				case MetaConstants.StandardValueSet: return new MetaStandardValueSet();
				case MetaConstants.CustomTab: return new MetaCustomTab();
				case MetaConstants.AssignmentRules: return new metaAssignmentRules();
				default: throw new System.ArgumentException("Metadata not found", Metadata);
			}
		}
	}
}
