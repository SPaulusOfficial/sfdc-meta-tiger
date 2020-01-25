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

<h3> 3 - Retrieve Files in Package </h3>   

This functionality serves to download the metadata mentioned in a package.xml just pass the organization and path that it will download in the package directory a zip file.
<h3> 4 - Get All Package.xml With User Last Modified </h3>

This feature has a responsibility to take everything that has been changed by a user list in the sandbox or organization, adding a start and end date. A package.xml will be created in the MetaTiger root directory only with appropriate user changes.

This feature also takes metadata creations that were made by users.

<h3> 5 - Get All Package.xml With User Created </h3>  

You have a responsibility to get the metadata that was only created by users at that reference period.

<h3>6 - Deploy Package in Salesforce</h3>  

This feature has the responsibility of deploying to any Salesforce environment, it allows various types of deploy's.

<h3>Configuration Meta Tiger</h3>

Install  Visual Studio Code.<br />
Install SDK do .NET Core 3.1 <a href="https://dotnet.microsoft.com/download/dotnet-core/3.1">Download</a> <br />
Install the C # extension for the Visual Studio Code. To learn more about installing extensions in Visual Studio Code, check out the VS Code Extension Marketplace.<br />

You can have more information on this link, how to install the dependencies before running the program:
https://docs.microsoft.com/pt-br/dotnet/core/tutorials/with-visual-studio-code<br />

<img src="https://github.com/brunoslribeiro/sfdc-package-repository-files/blob/master/assets/SFDC-PackageManifest.PNG">

In VisualCode using the terminal <br />

<strong>Execute command --> dotNet run</strong>

Just select the options below and use the tool normally it will prompt you for the required information.

I hope it's useful!<br />

<h3>🚨 CONHEÇA O META TIGER! ft. Bruno Ribeiro 🎥 | Canal Salesforce Brasil - Live</h3>

[![MetaTiger Live Brazil](https://img.youtube.com/vi/ys5mhpL2Ibg/0.jpg)](https://www.youtube.com/watch?v=ys5mhpL2Ibg)

In this Live I showed a little of the potential of MetaTiger, I hope you enjoy. <br/>

#metadata #metadataapi #metatiger #brunoslribeiro #salesforce
