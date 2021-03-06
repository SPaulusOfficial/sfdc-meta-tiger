# Project Meta Tiger - Application For Metadata Salesforce

<img src="https://github.com/brunoslribeiro/sfdc-package-repository-files/blob/master/assets/metatiger.png">

Author: Bruno Smith Lopes Ribeiro

This project is intended to make life easier for Salesforce developers by updating metadata that is changed or created in the sandbox's, and to help deploy to production environments by relating package.xml to the artifacts in the repository.

<h3>1 - Get All Package.xml</h3>                     

his feature serves to get a list of all metadata in your organization. They will be added in a package.xml in the MetaTiger directory called package.

<h3> 2 - Generate Package With Files of Repository </h3>   

This feature is for taking the files that are stored in your repository and preparing for deployment.

List of supported metadata:

&nbsp;<strong>AppMenu</strong> &nbsp;<strong>ApexClass</strong> &nbsp;<strong>ApexTrigger</strong> &nbsp;<strong>ApexComponent</strong> &nbsp;<strong>ApexPage</strong> &nbsp;<strong>CustomMetadata</strong> &nbsp;<strong>CustomObject</strong> &nbsp;<strong>CustomLabels</strong> &nbsp;<strong>CustomField</strong> &nbsp;<strong>DelegateGroup</strong> &nbsp;<strong>EmailTemplate</strong> &nbsp;<strong>Layout</strong> &nbsp;<strong>PermissionSet</strong> &nbsp;<strong>Profile</strong> &nbsp;<strong>StaticResource</strong> &nbsp;<strong>RemoteSiteSetting</strong> &nbsp;<strong>EntitlementProcess</strong> &nbsp;<strong>Flow</strong> &nbsp;<strong>CustomObjectTranslation</strong> &nbsp;<strong>FlowDefinition</strong> &nbsp;<strong>Settings</strong> &nbsp;<strong>ListView</strong> &nbsp;<strong>ValidationRule</strong> &nbsp;<strong>RecordType</strong> &nbsp;<strong>MilestoneType</strong> &nbsp;<strong>WebLink</strong> &nbsp;<strong>Workflow</strong> &nbsp;<strong>WorkflowRule</strong> &nbsp;<strong>StandardValueSet</strong> &nbsp;<strong>CustomTab</strong> &nbsp;<strong>AssignmentRules</strong> &nbsp;<strong>AuraDefinitionBundle</strong> &nbsp;<strong>CompactLayout</strong> &nbsp;<strong>CustomApplication</strong> &nbsp;<strong>FlexiPage</strong> &nbsp;<strong>Territory2Type</strong> &nbsp;<strong>Territory2</strong> &nbsp;<strong>Territory2Model</strong> &nbsp;<strong>ContentAsset</strong> &nbsp;<strong>SharingRules</strong> &nbsp;<strong>BrandingSet</strong> &nbsp;<strong>LightningExperienceTheme </strong>

We added in our inventory now in MetaTiger, the functionality to execute the PMD, to carry out its code validations.

<img src="https://pmd.github.io/img/pmd_logo.png">

<h3> 3 - Retrieve Files in Package </h3>   

This functionality serves to download the metadata mentioned in a package.xml just pass the organization and path that it will download in the package directory a zip file.
<h3> 4 - Get All Package.xml With User Last Modified </h3>

This feature has a responsibility to take everything that has been changed by a user list in the sandbox or organization, adding a start and end date. A package.xml will be created in the MetaTiger root directory only with appropriate user changes.

This feature also takes metadata creations that were made by users.

<h3> 5 - Get All Package.xml With User Created </h3>  

You have a responsibility to get the metadata that was only created by users at that reference period.

<h3>6 - Deploy Package in Salesforce</h3>  

This feature has the responsibility of deploying to any Salesforce environment, it allows various types of deploy's.

<h3>Feature Jenkins CI/CD With MetaTiger</h3>  

<img src="http://missaodevops.com.br/img/warrior/m08-jenkins.png"/>

We added a feature in MetaTiger for deployments to be dynamically, using some commands in Jenkins. Check our library to find out how to set it up.

<h3>Check out our releases on the link below:</h3>

<a href="https://github.com/brunoslribeiro/sfdc-meta-tiger/releases/tag/MetaTigerv8.0.0">Download - MetaTiger - v8.0.0</a>

I hope it's useful!<br />
