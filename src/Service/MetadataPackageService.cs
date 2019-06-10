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
    class MetadataPackageService {
        

        public static void getAllPackage(){
             Organization m_organization = MetadataConfigService.chooseCodeOrganization();
             MetadataApiService.getAllPackage(m_organization);
             ConsoleHelper.WriteDoneLine(">> Finalize the process...");
        }

        public static void retrieveAllPackage(){
             Organization m_organization = MetadataConfigService.chooseCodeOrganization();
             //PackageManifest package = MetadataConfigService.chooseCodePackageManifest();
             ConsoleHelper.WriteQuestionLine(Constants.LANG_PLEASEENTERPATHPACKAGE);
             string pathPackage = Console.ReadLine();
             MetadataApiService.retrieveMetadata(m_organization, pathPackage);
             ConsoleHelper.WriteDoneLine(">> Finalize the process...");
        }

         public static void generatePackageRepository(){
            Dictionary<string, List<string>> mapPackage = new Dictionary<string, List<string>>();
        
            PackageManifest packageManifest;

            Config m_config = MetadataConfigService.getConfig();

            packageManifest = MetadataConfigService.chooseCodePackageManifest();

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
    }

}