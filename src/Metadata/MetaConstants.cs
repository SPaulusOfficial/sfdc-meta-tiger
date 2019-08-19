using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace MetaTiger
{
    class MetaConstants {
			public const string AccessControlPolicy="AccessControlPolicy";
			public const string AccountRelationshipShareRule="AccountRelationshipShareRule";
			public const string AccountSettings="AccountSettings";
			public const string ActionLinkGroupTemplate="ActionLinkGroupTemplate";
			public const string ActivitiesSettings="ActivitiesSettings";
			public const string AddressSettings="AddressSettings";
			public const string AnalyticSnapshot="AnalyticSnapshot";
			public const string ApexClass="ApexClass";
			public const string ApexComponent="ApexComponent";
			public const string ApexPage="ApexPage";
			public const string ApexTestSuite="ApexTestSuite";
			public const string ApexTrigger="ApexTrigger";
			public const string AppMenu="AppMenu";
			public const string ApprovalProcess="ApprovalProcess";
			public const string AssignmentRule="AssignmentRule";
			public const string AssignmentRules="AssignmentRules";
			public const string Audience="Audience";
			public const string AuraDefinitionBundle="AuraDefinitionBundle";
			public const string AuthProvider="AuthProvider";
			public const string AutoResponseRule="AutoResponseRule";
			public const string AutoResponseRules="AutoResponseRules";
			public const string Bot="Bot";
			public const string BotVersion="BotVersion";
			public const string BrandingSet="BrandingSet";
			public const string BusinessHoursEntry="BusinessHoursEntry";
			public const string BusinessHoursSettings="BusinessHoursSettings";
			public const string BusinessProcess="BusinessProcess";
			public const string CallCenter="CallCenter";
			public const string CampaignInfluenceModel="CampaignInfluenceModel";
			public const string CaseSettings="CaseSettings";
			public const string CaseSubjectParticle="CaseSubjectParticle";
			public const string Certificate="Certificate";
			public const string ChannelLayout="ChannelLayout";
			public const string ChatterAnswersSettings="ChatterAnswersSettings";
			public const string ChatterExtension="ChatterExtension";
			public const string CleanDataService="CleanDataService";
			public const string CMSConnectSource="CMSConnectSource";
			public const string CommandAction="CommandAction";
			public const string Community="Community";
			public const string CommunityTemplateDefinition="CommunityTemplateDefinition";
			public const string CommunityThemeDefinition="CommunityThemeDefinition";
			public const string CompactLayout="CompactLayout";
			public const string CompanySettings="CompanySettings";
			public const string ConnectedApp="ConnectedApp";
			public const string ContentAsset="ContentAsset";
			public const string ContractSettings="ContractSettings";
			public const string CorsWhitelistOrigin="CorsWhitelistOrigin";
			public const string CspTrustedSite="CspTrustedSite";
			public const string CustomApplication="CustomApplication";
			public const string CustomApplicationComponent="CustomApplicationComponent";
			public const string CustomFeedFilter="CustomFeedFilter";
			public const string CustomField="CustomField";
			public const string CustomHelpMenuSection="CustomHelpMenuSection";
			public const string CustomLabel="CustomLabel";
			public const string CustomLabels="CustomLabels";
			public const string CustomMetadata="CustomMetadata";
			public const string CustomNotificationType="CustomNotificationType";
			public const string CustomObject="CustomObject";
			public const string CustomObjectTranslation="CustomObjectTranslation";
			public const string CustomPageWebLink="CustomPageWebLink";
			public const string CustomPermission="CustomPermission";
			public const string CustomSite="CustomSite";
			public const string CustomTab="CustomTab";
			public const string CustomValue="CustomValue";
			public const string Dashboard="Dashboard";
			public const string DashboardFolder="DashboardFolder";
			public const string DataCategoryGroup="DataCategoryGroup";
			public const string DelegateGroup="DelegateGroup";
			public const string Document="Document";
			public const string DocumentFolder="DocumentFolder";
			public const string DuplicateRule="DuplicateRule";
			public const string EclairGeoData="EclairGeoData";
			public const string EmailFolder="EmailFolder";
			public const string EmailServicesFunction="EmailServicesFunction";
			public const string EmailTemplate="EmailTemplate";
			public const string EmbeddedServiceBranding="EmbeddedServiceBranding";
			public const string EmbeddedServiceConfig="EmbeddedServiceConfig";
			public const string EmbeddedServiceFieldService="EmbeddedServiceFieldService";
			public const string EmbeddedServiceFlowConfig="EmbeddedServiceFlowConfig";
			public const string EmbeddedServiceLiveAgent="EmbeddedServiceLiveAgent";
			public const string EntitlementProcess="EntitlementProcess";
			public const string EntitlementSettings="EntitlementSettings";
			public const string EntitlementTemplate="EntitlementTemplate";
			public const string EntityImplements="EntityImplements";
			public const string EscalationRule="EscalationRule";
			public const string EscalationRules="EscalationRules";
			public const string EventDelivery="EventDelivery";
			public const string EventSubscription="EventSubscription";
			public const string ExternalDataSource="ExternalDataSource";
			public const string ExternalServiceRegistration="ExternalServiceRegistration";
			public const string FieldServiceSettings="FieldServiceSettings";
			public const string FieldSet="FieldSet";
			public const string FileUploadAndDownloadSecuritySettings="FileUploadAndDownloadSecuritySettings";
			public const string FlexiPage="FlexiPage";
			public const string Flow="Flow";
			public const string FlowCategory="FlowCategory";
			public const string FlowDefinition="FlowDefinition";
			public const string Folder="Folder";
			public const string ForecastingSettings="ForecastingSettings";
			public const string Form="Form";
			public const string FormSection="FormSection";
			public const string GlobalPicklistValue="GlobalPicklistValue";
			public const string GlobalValueSet="GlobalValueSet";
			public const string GlobalValueSetTranslation="GlobalValueSetTranslation";
			public const string Group="Group";
			public const string HomePageComponent="HomePageComponent";
			public const string HomePageLayout="HomePageLayout";
			public const string IdeasSettings="IdeasSettings";
			public const string Index="Index";
			public const string InstalledPackage="InstalledPackage";
			public const string IntegrationHubSettings="IntegrationHubSettings";
			public const string IntegrationHubSettingsType="IntegrationHubSettingsType";
			public const string IoTSettings="IoTSettings";
			public const string KeywordList="KeywordList";
			public const string KnowledgeSettings="KnowledgeSettings";
			public const string Layout="Layout";
			public const string LeadConvertSettings="LeadConvertSettings";
			public const string Letterhead="Letterhead";
			public const string LicenseDefinition="LicenseDefinition";
			public const string LightningBolt="LightningBolt";
			public const string LightningComponentBundle="LightningComponentBundle";
			public const string LightningExperienceTheme="LightningExperienceTheme";
			public const string ListView="ListView";
			public const string LiveAgentSettings="LiveAgentSettings";
			public const string LiveChatAgentConfig="LiveChatAgentConfig";
			public const string LiveChatButton="LiveChatButton";
			public const string LiveChatDeployment="LiveChatDeployment";
			public const string LiveChatSensitiveDataRule="LiveChatSensitiveDataRule";
			public const string LiveMessageSettings="LiveMessageSettings";
			public const string MacroSettings="MacroSettings";
			public const string ManagedTopic="ManagedTopic";
			public const string ManagedTopics="ManagedTopics";
			public const string MatchingRule="MatchingRule";
			public const string MatchingRules="MatchingRules";
			public const string MetadataWithContent="MetadataWithContent";
			public const string MilestoneType="MilestoneType";
			public const string MlDomain="MlDomain";
			public const string MobileSettings="MobileSettings";
			public const string ModerationRule="ModerationRule";
			public const string NamedCredential="NamedCredential";
			public const string NameSettings="NameSettings";
			public const string Network="Network";
			public const string NetworkBranding="NetworkBranding";
			public const string OmniChannelSettings="OmniChannelSettings";
			public const string OpportunitySettings="OpportunitySettings";
			public const string Orchestration="Orchestration";
			public const string OrchestrationContext="OrchestrationContext";
			public const string OrderSettings="OrderSettings";
			public const string OrgPreferenceSettings="OrgPreferenceSettings";
			public const string Package="Package";
			public const string PathAssistant="PathAssistant";
			public const string PathAssistantSettings="PathAssistantSettings";
			public const string PermissionSet="PermissionSet";
			public const string PermissionSetGroup="PermissionSetGroup";
			public const string PersonListSettings="PersonListSettings";
			public const string PicklistValue="PicklistValue";
			public const string PlatformActionList="PlatformActionList";
			public const string PlatformCachePartition="PlatformCachePartition";
			public const string PlatformEventChannel="PlatformEventChannel";
			public const string Portal="Portal";
			public const string PostTemplate="PostTemplate";
			public const string PresenceDeclineReason="PresenceDeclineReason";
			public const string PresenceUserConfig="PresenceUserConfig";
			public const string ProductSettings="ProductSettings";
			public const string Profile="Profile";
			public const string ProfilePasswordPolicy="ProfilePasswordPolicy";
			public const string ProfileSessionSetting="ProfileSessionSetting";
			public const string Queue="Queue";
			public const string QueueRoutingConfig="QueueRoutingConfig";
			public const string QuickAction="QuickAction";
			public const string QuoteSettings="QuoteSettings";
			public const string RecommendationStrategy="RecommendationStrategy";
			public const string RecordActionDeployment="RecordActionDeployment";
			public const string RecordType="RecordType";
			public const string RemoteSiteSetting="RemoteSiteSetting";
			public const string Report="Report";
			public const string ReportFolder="ReportFolder";
			public const string ReportType="ReportType";
			public const string Role="Role";
			public const string RoleOrTerritory="RoleOrTerritory";
			public const string SamlSsoConfig="SamlSsoConfig";
			public const string Scontrol="Scontrol";
			public const string SearchSettings="SearchSettings";
			public const string SecuritySettings="SecuritySettings";
			public const string ServiceChannel="ServiceChannel";
			public const string ServicePresenceStatus="ServicePresenceStatus";
			public const string SharingBaseRule="SharingBaseRule";
			public const string SharingCriteriaRule="SharingCriteriaRule";
			public const string SharingOwnerRule="SharingOwnerRule";
			public const string SharingReason="SharingReason";
			public const string SharingRules="SharingRules";
			public const string SharingSet="SharingSet";
			public const string SharingTerritoryRule="SharingTerritoryRule";
			public const string SiteDotCom="SiteDotCom";
			public const string Skill="Skill";
			public const string SocialCustomerServiceSettings="SocialCustomerServiceSettings";
			public const string StandardValue="StandardValue";
			public const string StandardValueSet="StandardValueSet";
			public const string StandardValueSetTranslation="StandardValueSetTranslation";
			public const string StaticResource="StaticResource";
			public const string SynonymDictionary="SynonymDictionary";
			public const string Territory="Territory";
			public const string Territory2="Territory2";
			public const string Territory2Model="Territory2Model";
			public const string Territory2Rule="Territory2Rule";
			public const string Territory2Settings="Territory2Settings";
			public const string Territory2Type="Territory2Type";
			public const string TimeSheetTemplate="TimeSheetTemplate";
			public const string TopicsForObjects="TopicsForObjects";
			public const string TransactionSecurityPolicy="TransactionSecurityPolicy";
			public const string Translations="Translations";
			public const string UiPlugin="UiPlugin";
			public const string UserCriteria="UserCriteria";
			public const string ValidationRule="ValidationRule";
			public const string VisualizationPlugin="VisualizationPlugin";
			public const string WaveApplication="WaveApplication";
			public const string WaveDashboard="WaveDashboard";
			public const string WaveDataflow="WaveDataflow";
			public const string WaveDataset="WaveDataset";
			public const string WaveLens="WaveLens";
			public const string WaveRecipe="WaveRecipe";
			public const string WaveTemplateBundle="WaveTemplateBundle";
			public const string WaveXmd="WaveXmd";
			public const string WebLink="WebLink";
			public const string Workflow="Workflow";
			public const string WorkflowAction="WorkflowAction";
			public const string WorkflowAlert="WorkflowAlert";
			public const string WorkflowFieldUpdate="WorkflowFieldUpdate";
			public const string WorkflowFlowAction="WorkflowFlowAction";
			public const string WorkflowKnowledgePublish="WorkflowKnowledgePublish";
			public const string WorkflowOutboundMessage="WorkflowOutboundMessage";
			public const string WorkflowRule="WorkflowRule";
			public const string WorkflowSend="WorkflowSend";
			public const string WorkflowTask="WorkflowTask";

			public const string Settings="Settings";


		public static readonly IList<String> metas = new ReadOnlyCollection<string>
    (new List<String> { 
       AccessControlPolicy, AccountRelationshipShareRule, AccountSettings, ActionLinkGroupTemplate, ActivitiesSettings, AddressSettings, AnalyticSnapshot, ApexClass, ApexComponent, ApexPage, ApexTestSuite, ApexTrigger, AppMenu, ApprovalProcess, AssignmentRule, AssignmentRules, Audience, AuraDefinitionBundle, AuthProvider, AutoResponseRule, AutoResponseRules, Bot, BotVersion, BrandingSet, BusinessHoursEntry, BusinessHoursSettings, BusinessProcess, CallCenter, CampaignInfluenceModel, CaseSettings, CaseSubjectParticle, Certificate, ChannelLayout, ChatterAnswersSettings, ChatterExtension, CleanDataService, 
			 CMSConnectSource, CommandAction, Community, CommunityTemplateDefinition, CommunityThemeDefinition, CompactLayout, CompanySettings, ConnectedApp, ContentAsset, ContractSettings, CorsWhitelistOrigin, CspTrustedSite, CustomApplication, CustomApplicationComponent, CustomFeedFilter, CustomField, CustomHelpMenuSection, CustomLabel, CustomLabels, CustomMetadata, CustomNotificationType, CustomObject, CustomObjectTranslation, CustomPageWebLink, CustomPermission, CustomSite, CustomTab, 
			 CustomValue, Dashboard, DashboardFolder, DataCategoryGroup, DelegateGroup, Document, DocumentFolder, DuplicateRule, EclairGeoData, EmailFolder, EmailServicesFunction, EmailTemplate, EmbeddedServiceBranding, EmbeddedServiceConfig, EmbeddedServiceFieldService, 
			 EmbeddedServiceFlowConfig, EmbeddedServiceLiveAgent, EntitlementProcess, EntitlementSettings, EntitlementTemplate, EntityImplements, EscalationRule, EscalationRules, EventDelivery, EventSubscription, ExternalDataSource, ExternalServiceRegistration, FieldServiceSettings, FieldSet, FileUploadAndDownloadSecuritySettings, FlexiPage, Flow, FlowCategory, FlowDefinition, Folder, ForecastingSettings, Form, 
			 FormSection, GlobalPicklistValue, GlobalValueSet, GlobalValueSetTranslation, Group, HomePageComponent, HomePageLayout, IdeasSettings, Index, InstalledPackage, IntegrationHubSettings, IntegrationHubSettingsType, IoTSettings, KeywordList, KnowledgeSettings, Layout, 
			 LeadConvertSettings, Letterhead, LicenseDefinition, LightningBolt, LightningComponentBundle, LightningExperienceTheme, ListView, LiveAgentSettings, LiveChatAgentConfig, LiveChatButton, LiveChatDeployment, LiveChatSensitiveDataRule, LiveMessageSettings, MacroSettings, ManagedTopic, ManagedTopics, MatchingRule, MatchingRules, MetadataWithContent,
			 MilestoneType, MlDomain, MobileSettings, ModerationRule, NamedCredential, NameSettings, Network, NetworkBranding, OmniChannelSettings, OpportunitySettings, Orchestration, OrchestrationContext, OrderSettings, OrgPreferenceSettings, Package, PathAssistant, PathAssistantSettings, PermissionSet, PermissionSetGroup, PersonListSettings, PicklistValue, PlatformActionList, PlatformCachePartition, PlatformEventChannel, Portal, PostTemplate, PresenceDeclineReason, PresenceUserConfig, ProductSettings, Profile, ProfilePasswordPolicy, ProfileSessionSetting, Queue, QueueRoutingConfig, QuickAction, QuoteSettings, RecommendationStrategy, RecordActionDeployment,
			 RecordType, RemoteSiteSetting, Report, ReportFolder, ReportType, Role, RoleOrTerritory, SamlSsoConfig, Scontrol, SearchSettings, SecuritySettings, ServiceChannel, ServicePresenceStatus, SharingBaseRule, SharingCriteriaRule, SharingOwnerRule, SharingReason, SharingRules, SharingSet, SharingTerritoryRule, SiteDotCom, Skill, SocialCustomerServiceSettings, StandardValue, StandardValueSet, StandardValueSetTranslation,
			 StaticResource,Settings, SynonymDictionary, Territory, Territory2, Territory2Model, Territory2Rule, Territory2Settings, Territory2Type, TimeSheetTemplate, TopicsForObjects, 
			 TransactionSecurityPolicy, Translations, UiPlugin,
			 UserCriteria, ValidationRule, VisualizationPlugin, WaveApplication, 
			 WaveDashboard, WaveDataflow, WaveDataset, WaveLens, WaveRecipe, 
			 WaveTemplateBundle, WaveXmd, WebLink, Workflow, WorkflowAction, 
			 WorkflowAlert, WorkflowFieldUpdate, WorkflowFlowAction, 
			 WorkflowKnowledgePublish, WorkflowOutboundMessage, 
			 WorkflowRule, WorkflowSend, WorkflowTask 
				});
			
	}
}
