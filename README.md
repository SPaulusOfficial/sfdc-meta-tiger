# Project Meta Tiger

Creating a Salesforce file tree through the Repository using package.xml, 
is working with this Metadata for now:

<table>
  <tr>
    <td><strong>ApexClass</strong></td>
    <td><strong>ApexTrigger</strong></td>
    <td><strong>ApexPage</strong></td>
    <td><strong>ApexComponent</strong></td>
    <td><strong>CustomMetadata</strong></td>
    <td><strong>CustomObject</strong></td>
  </tr>
  <tr>
    <td><strong>CustomField</strong></td>
    <td><strong>EmailTemplate</strong></td>
    <td><strong>Layout</strong></td>
    <td><strong>PermissionSet</strong></td>
    <td><strong>Profile</strong></td>
    <td><strong>Flow</strong></td>
  </tr>
  <tr>
    <td><strong>ListView</strong></td>
    <td><strong>Settings</strong></td>
    <td><strong>ValidationRules</strong></td>
    <td><strong>Workflow</strong></td>
    <td><strong>WorkflowRules</strong></td>
    <td><strong>Weblink</strong></td>
  </tr>
  <tr>
    <td><strong>RecordTypes</strong></td>
    <td><strong>StandardValueSet</strong></td>
    <td><strong>MilestoneType</strong></td>
    <td><strong>RemoteSiteSetting</strong></td>
    <td><strong>FlowDefinition</strong></td>
    <td><strong>CustomTab</strong></td>
  </tr>
  <tr>
    <td><strong>EntitlementProcess</strong></td>
    <td><strong>AssignmentRules</strong></td>
  </tr>
</table>

Install  Visual Studio Code.<br />
Install SDK do .NET Core 2.2 <a href="https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.104-windows-x64-installer">Download</a> <br />
Install the C # extension for the Visual Studio Code. To learn more about installing extensions in Visual Studio Code, check out the VS Code Extension Marketplace.<br />

You can have more information on this link, how to install the dependencies before running the program:
https://docs.microsoft.com/pt-br/dotnet/core/tutorials/with-visual-studio-code<br />

<img src="https://github.com/brunoslribeiro/sfdc-package-repository-files/blob/master/assets/SFDC-PackageManifest.PNG">

In VisualCode using the terminal <br />
<strong>"dotNet run"</strong> command The following question will appear:<br />
<strong>"Please enter the path of the Package.xml path"</strong><br />
Enter the directory where your package.xml is located | Example: C:\Documents\workspace\DEV05\package.xml<br />
<strong>"Please enter the path of the repository where the files are:"</strong><br />
Enter your directory path, where the files are located | C:\Documents\workspace\DEV05<br />
<br />
Result:<br />
<img src="https://github.com/brunoslribeiro/sfdc-package-repository-files/blob/master/assets/Result.PNG">
At the end it will copy the files that are needed in the package.xml, with the appropriate folders already addressed.<br />
<br />
I hope it's useful!<br />

News:</br>
<u>Add Config Xml for Path Package | DirectoryTarget | Repository</u>

Create directory Config/config.xml file with code below:

```xml
<?xml version="1.0"?>
<Config>
  <GeneralDirectoryTarget>C:\\package</GeneralDirectoryTarget>
  <PackageManifest>
	    <Id>1</Id>
      <DirectoryTarget>C:\\package</DirectoryTarget>
      <RepositorySource>C:\\CI</RepositorySource>
      <PackageFile>C:\\CI\\package.xml</PackageFile>  
  </PackageManifest>
  <VersionNumber>4.0</VersionNumber>
</Config>
```

Progress:</br>
<u> More CustomLabel - Begin 23/02/2019 - Final:23/02/2019 </u></br>
<u> Auto Merge for CustomObject - Begin 21/02/2019 - Final:??? </u></br>
