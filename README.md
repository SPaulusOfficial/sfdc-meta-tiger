# sfdc-package-repository-files

Create structure of Package with Repository, 
is working with this metadata for now:

<ul>
  <li>ApexClass</li>
  <li>ApexPage</li>
  <li>ApexTrigger</li>
  <li>ApexComponent</li>
  <li>CustomMetadata</li>
  <li>CustomObject</li>
  <li>CustomField</li>
  <li>EmailTemplate</li>
  <li>Layout</li>
  <li>PermissionSet</li>
  <li>Profile</li>
  <li>Flow</li>
  <li>FlowDefinition</li>
  <li>EntitlementProcess</li>
  <li>RemoteSiteSetting</li>
  <li>ListView</li>
  <li>Settings</li>
  <li>ValidationRules</li>
</ul>

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
