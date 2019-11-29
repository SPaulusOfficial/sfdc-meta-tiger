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

namespace MetaTiger.Metadata{

    public class MetadataGeneratePackageRepository{

        public static void generatePackageRepository(){
            PackageManifest packageManifest;
            Config m_config = MetadataConfigService.getConfig();
            packageManifest = MetadataConfigService.chooseCodePackageManifest();
            run(packageManifest);
        }

        public static String generatePackageRepository(String branchName, String pathRepository){
            PackageManifest packageManifest;
            Config m_config = MetadataConfigService.getConfig();
            packageManifest = MetadataConfigService.chooseCodePackageManifest(branchName, pathRepository);
            //System.IO.DirectoryInfo dInfo = new System.IO.DirectoryInfo(packageManifest.DirectoryTarget);
            //DeletingFiles(dInfo);
            run(packageManifest);
            return packageManifest.DirectoryTarget;
        }

        public static void run(PackageManifest packageManifest){
            Dictionary<string, List<string>> mapPackage = new Dictionary<string, List<string>>();

            if (!ManageFileDirectory.validateDirectory(packageManifest.RepositorySource)){
                ConsoleHelper.WriteErrorLine(">>> Path not found:" + packageManifest.RepositorySource);
                return;
            }

            mapPackage = ManageXMLPackage.buildMap(packageManifest.PackageFile);    

            List<IMetadata> MetaDatas = MetadataService.createDirectory(mapPackage, packageManifest.DirectoryTarget);
            MetadataService.validate(mapPackage, MetaDatas);
            MetadataService.copy(packageManifest.RepositorySource, packageManifest.DirectoryTarget, MetaDatas);
            MetadataService.merge(packageManifest.RepositorySource,packageManifest.DirectoryTarget,MetaDatas);
            MetadataService.copyPackage(packageManifest.PackageFile, packageManifest.DirectoryTarget);

            ConsoleHelper.WriteDoneLine(">> Finalize the process...");
        }

        public static void DeletingFiles(System.IO.DirectoryInfo directory)
        {
            //delete files:
            foreach (System.IO.FileInfo file in directory.GetFiles()) 
                file.Delete();
            //delete directories in this directory:
            foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories())
                directory.Delete(true);
        }

    }

    

}

 