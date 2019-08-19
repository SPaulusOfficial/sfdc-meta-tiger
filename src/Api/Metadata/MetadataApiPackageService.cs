using System;
using System.Collections.Generic;
using SFDC.Metadata;
using MetaTiger.ManageFileXML;
using MetaTiger.PartnerApi;
using MetaTiger.Xml;
using MetaTiger.Xml.Config;
using MetaTiger.Xml.Package;
using System.Threading;
using System.IO;
using System.IO.Compression;
using MetaTiger.Helper;

namespace MetaTiger.Api.Metadata{

     public class MetadataApiPackageService{

        public static void getAllPackage(Organization Organization,MetadataApiClientResponse response){
            MetadataApiGetAllPackage packageTask = new MetadataApiGetAllPackage();
            packageTask.getAllPackage(Organization, response);
        }

        public static void getAllPackageOfUserLastModifiedByName(Organization Organization,MetadataApiClientResponse response,List<string> nameuser,List<String> dates){
            MetadataApiGetAllPackageLastModifiedByName packageTask = new MetadataApiGetAllPackageLastModifiedByName();
            packageTask.getAllPackage(Organization, response, nameuser,dates);
        }

        public static void getAllPackageCreatedByName(Organization Organization,MetadataApiClientResponse response,List<string> nameuser,List<String> dates){
            MetadataApiGetAllPackageCreatedByName packageTask = new MetadataApiGetAllPackageCreatedByName();
            packageTask.getAllPackage(Organization, response, nameuser,dates);
        }

     }

}