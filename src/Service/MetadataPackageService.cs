using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Salesforce_Package.Metadata;
using Salesforce_Package.Manage;
using Salesforce_Package.ManageXML;
using Salesforce_Package.Xml.Config;
using Salesforce_Package.MetadataApi;

namespace Salesforce_Package.Metadata{
    class MetadataPackageService {
        

        public static void getAllPackage(){
             Organization m_organization = MetadataConfigService.chooseCodeOrganization();
             MetadataApiService.getAllPackage(m_organization);
             ConsoleHelper.WriteDoneLine(">> Finalize the process...");
        }

         public static void generatePackageRepository(){
            Dictionary<string, List<string>> mapPackage = new Dictionary<string, List<string>>();
        
            PackageManifest packageManifest;

            Config m_config = MetadataConfigService.getConfig();

            packageManifest = MetadataConfigService.chooseCodePackageManifest();

            if (!ManageDirectory.validateDirectory(packageManifest.RepositorySource)){
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