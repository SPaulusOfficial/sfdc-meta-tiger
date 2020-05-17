using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MetaTiger.Metadata;
using MetaTiger.ManageFile;
using MetaTiger.ManageFileXML;
using MetaTiger.Xml.Config;
using MetaTiger.Api.Metadata;
using MetaTiger.Helper;

namespace MetaTiger.Service{

    public class GeneratePackageRepository{

        public static Organization enviroment = null; 

        public static void generatePackageRepository(){
            PackageManifest packageManifest;
            Config m_config = ConfigService.getConfig();
            packageManifest = ConfigService.chooseCodePackageManifest();
            run(packageManifest);
        }

        public static String generatePackageRepository(String branchName, String pathRepository){
            PackageManifest packageManifest;
            enviroment = ConfigService.getOrganization(branchName); 
            packageManifest = ConfigService.chooseCodePackageManifest(branchName, pathRepository);
            run(packageManifest);
            return packageManifest.DirectoryTarget;
        }

        public static void run(PackageManifest packageManifest)
        {
            Dictionary<string, List<string>> mapPackage = new Dictionary<string, List<string>>();

            if (!ManageFileDirectory.validateDirectory(packageManifest.RepositorySource))
            {
                ConsoleHelper.WriteErrorLine(">>> Path not found:" + packageManifest.RepositorySource);
                return;
            }

            mapPackage = ManageXMLPackage.buildMap(packageManifest.PackageFile);
            
            new PackageRepositoryWork(packageManifest, mapPackage,enviroment).run();
        
            ConsoleHelper.WriteDoneLine(">> Finalize the process...");
        }
    }
}

 