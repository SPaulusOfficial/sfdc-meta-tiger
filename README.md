# sfdc-package-repository-files

Create structure of Package with Repository, 
is working with this Metadata for now:

<table>
  <tr>
    <td>ApexClass</td>
    <td>ApexTrigger</td>
    <td>ApexPage</td>
    <td>ApexComponent</td>
    <td>CustomMetadata</td>
    <td>CustomObject</td>
  </tr>
  <tr>
    <td>CustomField</td>
    <td>EmailTemplate</td>
    <td>Layout</td>
    <td>PermissionSet</td>
    <td>Profile</td>
    <td>Flow</td>
  </tr>
  <tr>
    <td>ListView</td>
    <td>Settings</td>
    <td>ValidationRules</td>
    <td>Workflow</td>
    <td>WorkflowRules</td>
    <td>Weblink</td>
  </tr>
  <tr>
    <td>RecordTypes</td>
    <td>StandardValueSet</td>
    <td>MilestoneType</td>
    <td>RemoteSiteSetting</td>
    <td>FlowDefinition</td>
  </tr>
</table>

Install  Visual Studio Code.<br />
Install SDK do .NET Core.<br />
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
For now I'm adding a folder called package on drive C: / <br />
<br />
I hope it's useful!<br />
