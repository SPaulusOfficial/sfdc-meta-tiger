# sfdc-package-repository-files

Create structure of Package with Repository, 
is working with this metadata for now:

ApexClass
ApexPage
CustomMetadata
CustomObject
EmailTemplate
Layout
PermissionSet
Profile

Install  Visual Studio Code.
Install SDK do .NET Core.
Install the C # extension for the Visual Studio Code. To learn more about installing extensions in Visual Studio Code, check out the VS Code Extension Marketplace.

You can have more information on this link, how to install the dependencies before running the program:
https://docs.microsoft.com/pt-br/dotnet/core/tutorials/with-visual-studio-code

In VisualCode using the terminal 
"dotNet run" command The following question will appear:
"Please enter the path of the Package.xml path"
Enter the directory where your package.xml is located | Example: C:\Documents\workspace\DEV05\package.xml
"Please enter the path of the repository where the files are:"
Enter your directory path, where the files are located | C:\Documents\workspace\DEV05

Result:
At the end it will copy the files that are needed in the package.xml, with the appropriate folders already addressed.

For now I'm adding a folder called package on drive C: /

I hope it's useful!
