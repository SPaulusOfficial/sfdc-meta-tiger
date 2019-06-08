using System;
using System.Collections.Generic;
using SFDC.Metadata;
using Salesforce_Package.ManageXML;
using Salesforce_Package.PartnerApi;
using Salesforce_Package.Xml;
using Salesforce_Package.Xml.Config;
using Salesforce_Package.Xml.Package;
using System.Threading;
using System.IO;
using System.IO.Compression;

namespace Salesforce_Package.MetadataApi{

    public class MetadataApiService {
        
        private static MetadataClientResponse getMetadataClient(MetadataClientRequest request){
             PartnerLoginRequest requestPattern = new PartnerLoginRequest{
                Username = request.Username,
                Password = request.Password,
                SecurityToken = request.SecurityToken,
                Production = request.Production
            };
            PartnerLoginResponse responsePartner = PartnerApiService.login(requestPattern);
            return MetadataClientService.getMetadataClient(responsePartner.UserId,responsePartner.SessionId,responsePartner.ServerUrl); 
        }

        public static void getAllPackage(Organization Organization){
             MetadataClientRequest request = new MetadataClientRequest();
             request.Username = Organization.Username;
             request.Password = Organization.Password;
             request.SecurityToken = Organization.SecurityToken;
             request.Production = (Organization.Production=="true") ? true : false ;
             MetadataClientResponse response  = getMetadataClient(request);
             List<listMetadataResponse> metadataResponse = new List<listMetadataResponse>();
            
             foreach(string strType in MetaConstants.metas){
                ConsoleHelper.WriteDocLine(strType);
                
                try{
                  listMetadataResponse responseMeta = MetadataListMetadataApiService.listMetadata(response.Metadataclient,strType);
                  metadataResponse.Add(responseMeta);
                }
                catch (Exception e)
                {
                 ConsoleHelper.WriteErrorLine(e.Message);
                }
               
             }
             
             writePackageXml(metadataResponse);
        }

        public static void retrieveMetadata(Organization Organization,string pathPackage){
            MetadataClientRequest request = new MetadataClientRequest();
            request.Username = Organization.Username;
            request.Password = Organization.Password;
            request.SecurityToken = Organization.SecurityToken;
            request.Production = (Organization.Production=="true") ? true : false ;
            MetadataClientResponse response  = getMetadataClient(request);
            SFDC.Metadata.Package package = ManageXMLPackage.DeserializePackageApi(pathPackage);
            
            checkRetrieveStatusResponse responseCheck;
            RetrieveResult result;

            String asyncId = MetadataRetrieveService.retrieve(response.Metadataclient,package);
    
           try{
                do
                {
                  responseCheck = MetadataCheckRetrieveService.checkRetrieveStatus(response.Metadataclient,asyncId);
                  result = responseCheck.result;
                  Thread.Sleep(2000);
                  ConsoleHelper.WriteDocLine(result.done.ToString());
                } while (!result.done);

                if(result.status == RetrieveStatus.Failed){
                    ConsoleHelper.WriteErrorLine(result.errorMessage);
                }else if(result.status == RetrieveStatus.Succeeded){
                    if(result.messages != null){
                        foreach(RetrieveMessage rm in result.messages) {
                            ConsoleHelper.WriteWarningLine(rm.fileName + " " + rm.problem);
                        }
                    }

                    String path = Environment.CurrentDirectory+"\\package\\zip\\package.zip";
                    File.WriteAllBytes(path,result.zipFile);
                    
                }
        
            }
            catch (Exception e)
            {
              ConsoleHelper.WriteErrorLine(e.Message);
            } 
            
           
        } 

        public static void writePackageXml(List<listMetadataResponse> metadataResponse){
            Salesforce_Package.Xml.Package.Package package = new Salesforce_Package.Xml.Package.Package();
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

        public static Types generatePackageOFTypes(listMetadataResponse response){
            Types type = new Types();
            type.Members = new List<String>();
            Boolean isHaveResponse = response != null;
            if(isHaveResponse){
                Boolean isHaveResult = response.result != null;
                if(isHaveResult){
                    foreach (FileProperties f in response.result)
                    {
                        type.Name = f.type;
                        type.Members.Add(f.fullName);
                    }
                }  
            }

            type.Members.Sort((a, b) => a.CompareTo(b));
          
            return type;
        }

    }

}