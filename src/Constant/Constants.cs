using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Constants{

    public static readonly List<String> propertiesPackageManifest = new List<string>
    (new List<String> {"Id","Package","RepositoryPath","DirectoryTarget" });

    public static readonly List<String> propertiesOrganization = new List<string>
    (new List<String> {"Id","UserName","Password","SecurityToken","Production"});

    public static readonly String separateColumnsInConsole = " | ";

    public static readonly String LANG_CODEPACKAGE = ">>> Code Package:";
    public static readonly String LANG_NOTFOUNDPACKAGEMANIFEST = ">>> Not Found PackageManifest";

    public static readonly String LANG_PLEASEENTERPATHPACKAGE = ">>> Please enter the path of the Package.xml:"; 

    public static readonly String LANG_PLEASEENTERPATHREPOSITORY = ">>> Please enter the path of the repository where the files are:"; 

    public static readonly String LANG_CHOOSECODEPACKAGEMANIFESTINCONFIG = ">>> Choose code package manifest save in Config:"; 

    public static readonly String LANG_CHOOSECODEORGANIZATIONSAVEINCONFIG = ">>> Choose code organization save in Config:";
    
    public static readonly String LANG_PLEASEENTERUSERNAME = ">>> Please enter ther username of organization or sandbox:"; 

    public static readonly String LANG_PLEASEENTERPASSWORD = ">>> Please enter ther password of organization or sandbox:"; 

    public static readonly String LANG_PLEASEENTERTOKEN = ">>> Please enter ther token of organization or sandbox:"; 
   
    public static readonly String LANG_PLEASEENTERPRODUCTION = ">>> Please enter ther type of organization or production/sandbox: (y/n)"; 

}