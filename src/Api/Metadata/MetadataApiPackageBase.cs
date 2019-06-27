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

     public abstract class MetadataApiPackageBase{

         
         public void run(Organization Organization,MetadataApiClientResponse response){
             List<listMetadataResponse> metadataResponse = new List<listMetadataResponse>();
             ConsoleHelper.WriteWarningLine("Downloading! Metadata tree!");
             foreach(string strType in MetaConstants.metas){
                ConsoleHelper.WriteDocLine(strType);
                try{
                  listMetadataResponse responseMeta = MetadataApiListMetadataService.listMetadata(response.Metadataclient,strType);
                  metadataResponse.Add(responseMeta);
                }
                catch (Exception e)
                {
                 ConsoleHelper.WriteErrorLine(e.Message);
                }
               
             }
             ConsoleHelper.WriteWarningLine("Write package your organization...");
             writePackageXml(metadataResponse);
             ConsoleHelper.WriteDoneLine("We got package.xml written!");
        }

        public void writePackageXml(List<listMetadataResponse> metadataResponse){
            MetaTiger.Xml.Package.Package package = new MetaTiger.Xml.Package.Package();
            package.Types = new List<Types>();

            foreach (var response in metadataResponse)
            {
               Types types =  generatePackageOFTypes(response);
               if(types.Members.Count>0){
                  package.Types.Add(types);
               }
            }

            ManageXMLPackage.doWrite(package);
        }

        public Types generatePackageOFTypes(listMetadataResponse response){
            Types type = new Types();
            type.Members = new List<String>();
            Boolean isHaveResponse = response != null;
            if(isHaveResponse){
                Boolean isHaveResult = response.result != null;
                if(isHaveResult){
                    foreach (FileProperties f in response.result)
                    {
                        if(this.doFilter(f)){
                           type.Name = f.type;
                           type.Members.Add(f.fullName);
                        }
                    }
                }  
            }

            type.Members.Sort((a, b) => a.CompareTo(b));
          
            return type;
        }

        public abstract bool doFilter(FileProperties f);

     }

}