using System;
using System.Collections.Generic;
using SFDC.Metadata;
using Salesforce_Package.ManageXML;
using Salesforce_Package.PartnerApi;
using Salesforce_Package.Xml;
using Salesforce_Package.Xml.Config;
using Salesforce_Package.Xml.Package;

namespace Salesforce_Package.MetadataApi{

    public class MetadataApiService {
        
        private static MetadataClientResponse getMetadataClient(MetadataClientRequest request){
             PartnerLoginRequest requestPattern = new PartnerLoginRequest{
                Username = request.Username,
                Password = request.Password,
                SecurityToken = request.SecurityToken,
            };
            PartnerLoginResponse responsePartner = PartnerApiService.login(requestPattern);
            return MetadataClientService.getMetadataClient(responsePartner.UserId,responsePartner.SessionId,responsePartner.ServerUrl); 
        }

        public static void getAllPackage(Organization Organization){
             MetadataClientRequest request = new MetadataClientRequest();
             request.Username = Organization.Username;
             request.Password = Organization.Password;
             request.SecurityToken = Organization.SecurityToken;
             MetadataClientResponse response  = getMetadataClient(request);
             List<listMetadataResponse> metadataResponse = new List<listMetadataResponse>();
            
             foreach(string strType in MetaConstants.metas){
                ConsoleHelper.WriteDocLine(strType);
                listMetadataResponse responseMeta = MetadataListMetadataApiService.listMetadata(response.Metadataclient,strType);
                metadataResponse.Add(responseMeta);
             }
             
             writePackageXml(metadataResponse);
        } 

        public static void writePackageXml(List<listMetadataResponse> metadataResponse){
            Salesforce_Package.Xml.Package.Package package = new Salesforce_Package.Xml.Package.Package();
            package.Types = new List<Types>();

            foreach (var response in metadataResponse)
            {
               Types types =  generatePackageOFTypes(response);
               if(types.Members.Count>0){
                  package.Types.Add(generatePackageOFTypes(response));
               }
            }

            ManageXMLPackage.doWrite(package);
        }

        public static Types generatePackageOFTypes(listMetadataResponse response){
            ConsoleHelper.WriteDocLine("generatePackageOFTypes");
            Types type = new Types();
            type.Members = new List<String>();
            Boolean isHaveResponse = response != null;
            if(isHaveResponse){
                ConsoleHelper.WriteDocLine("Entrou Response");
                Boolean isHaveResult = response.result != null;
                if(isHaveResult){
                    ConsoleHelper.WriteDocLine("Entrou Result");
                    foreach (FileProperties f in response.result)
                    {
                        ConsoleHelper.WriteDocLine(f.type + f.fullName);
                        type.Name = f.type;
                        type.Members.Add(f.fullName);
                    }
                }  
            }
          
            return type;
        }

    }

}