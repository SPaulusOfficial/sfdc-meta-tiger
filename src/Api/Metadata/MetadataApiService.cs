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
using MetaTiger.ManageFile;

namespace MetaTiger.Api.Metadata{

    public class MetadataApiService {
        
        private static MetadataApiClientResponse getMetadataClient(MetadataApiClientRequest request)
        {
            ConsoleHelper.WriteWarningLine("Try login in your organization:");
            PartnerLoginRequest requestPattern = PartnerApiService.createPartnerLoginRequest(request);
            PartnerLoginResponse responsePartner = PartnerApiService.login(requestPattern);
            ConsoleHelper.WriteDoneLine("OK! We Can Enter!");
            return MetadataApiClientService.getMetadataClient(responsePartner.UserId, responsePartner.SessionId, responsePartner.ServerUrl);
        }
        
        public static void getAllPackage(Organization Organization)
        {
            MetadataApiClientResponse response = generateClientResponse(Organization);
            MetadataApiPackageService.getAllPackage(Organization, response);
        }

        public static void getAllPackageLastModifiedByName(Organization Organization,List<string> nameuser,List<String> dates)
        {
            MetadataApiClientResponse response = generateClientResponse(Organization);
            MetadataApiPackageService.getAllPackageOfUserLastModifiedByName(Organization, response,nameuser,dates);
        }

        public static void getAllPackageCreatedByName(Organization Organization,List<string> nameuser,List<String> dates)
        {
            MetadataApiClientResponse response = generateClientResponse(Organization);
            MetadataApiPackageService.getAllPackageCreatedByName(Organization, response,nameuser,dates);
        }

        private static MetadataApiClientResponse generateClientResponse(Organization Organization)
        {
            MetadataApiClientRequest request;
            MetadataApiClientResponse response;
            request = new MetadataApiClientRequest(){
                Username = Organization.Username,
                Password = Organization.Password,
                SecurityToken = Organization.SecurityToken,
                Api = Organization.Api,
                Production = (Organization.Production == "true") ? true : false
            };
            response = getMetadataClient(request);
            return response;
        }

        public static void retrieveMetadata(Organization Organization,string pathPackage){
            MetadataApiClientResponse response;
            SFDC.Metadata.Package package;
            RetrieveResult result;
            String asyncId;

            response = generateClientResponse(Organization);
            package = ManageXMLPackage.DeserializePackageApi(pathPackage);
            asyncId = MetadataApiRetrieveService.retrieve(response.Metadataclient,package);
    
            try
            {
                result = checkResultsOfRetrieve(response,asyncId);
                extractFile(result);
            }
            catch (Exception e)
            {
              ConsoleHelper.WriteErrorLine(e.Message);
            } 
        }

        public static void deployMetadata(Organization Organization,MetadataApiDeployRequest request){
            MetadataApiClientResponse response;
            DeployResult result;
            String asyncId;

            response = generateClientResponse(Organization);
            //package = ManageXMLPackage.DeserializePackageApi(pathPackage);
            asyncId = MetadataApiDeployService.deploy(response.Metadataclient,request);
    
            try
            {
                result = checkResultsOfDeploy(response,asyncId);
                //extractFile(result);
            }
            catch (Exception e)
            {
              ConsoleHelper.WriteErrorLine(e.Message);
            } 
        }

        private static DeployResult checkResultsOfDeploy(MetadataApiClientResponse response, string asyncId)
        {
            DeployResult result;
            checkDeployStatusResponse responseCheck;
            string debugLog = "";
                      
            ConsoleHelper.WriteDocLine("Request for a deploy submitted successfully.");
            ConsoleHelper.WriteDocLine("Request ID for the current deploy task: " + asyncId);
            ConsoleHelper.WriteDocLine("Waiting for server to finish processing the request...");

            do
            {
               try{
                   responseCheck = MetadataApiCheckDeployService.checkDeployStatus(response.Metadataclient, asyncId);
                   result = responseCheck.result;
                   ConsoleHelper.WriteDocLine("Request Status: "+ result.status);
                   if(result.stateDetail!=null){
                    ConsoleHelper.WriteDocLine(result.stateDetail);
                   }
                   if(responseCheck.DebuggingInfo!=null){
                     debugLog = responseCheck.DebuggingInfo.debugLog;
                   }
                   if(result.status==DeployStatus.Failed){
                    for(int i = 0; i < result.details.componentFailures.Length; i++){
                        DeployMessage message = result.details.componentFailures[i];
                        ConsoleHelper.WriteErrorLine(message.componentType + " " + message.fullName + " " + message.problem);
                    }
                    throw new Exception();
                   }
               }catch(Exception e){
                  result = new DeployResult();
                  ConsoleHelper.WriteErrorLine(e.Message);
               }
               Thread.Sleep(2000);   
               
            } while (!result.done);
           
            //.WriteDocLine(debugLog);

            return result;
        }

        private static RetrieveResult checkResultsOfRetrieve(MetadataApiClientResponse response, string asyncId)
        {
            RetrieveResult result;
            checkRetrieveStatusResponse responseCheck;

            ConsoleHelper.WriteDocLine("Request for a deploy submitted successfully.");
            ConsoleHelper.WriteDocLine("Request ID for the current deploy task: " + asyncId);
            ConsoleHelper.WriteDocLine("Waiting for server to finish processing the request...");

            do
            {
               try{
                   responseCheck = MetadataApiCheckRetrieveService.checkRetrieveStatus(response.Metadataclient, asyncId);
                   result = responseCheck.result;
                   
                   ConsoleHelper.WriteDocLine("Request Status: "+ result.status);
                   
               }catch(Exception e){
                  result = new RetrieveResult();
                  ConsoleHelper.WriteErrorLine(e.Message);
               }
               Thread.Sleep(2000);   
            } while (!result.done);
            
            return result;
        }

        private static void extractFile(RetrieveResult result)
        {
            bool isStatusFailed = result.status == RetrieveStatus.Failed;
            bool isStatusSucceeded = result.status == RetrieveStatus.Succeeded;
            bool isHaveMessages = result.messages != null;
            
            if (isStatusFailed)
            {
                ConsoleHelper.WriteErrorLine(result.errorMessage);
            }
            else if (isStatusSucceeded)
            {
                printMessages(result, isHaveMessages);
                String pathDirectory = Environment.CurrentDirectory + @"\package";
                createDirectoryPathPackage(pathDirectory);
                generateZipFile(result, pathDirectory);
                ConsoleHelper.WriteDoneLine("Finalize Success Retrieve!");
            }
        }

        private static void generateZipFile(RetrieveResult result, string pathDirectory)
        {
            String pathFile = pathDirectory + @"\package.zip";
            File.WriteAllBytes(pathFile, result.zipFile);
        }

        private static void createDirectoryPathPackage(string pathDirectory)
        {
            if (ManageFileDirectory.validateDirectory(pathDirectory))
            {
                ManageFileDirectory.createPackageDirectory(pathDirectory);
            }
        }

        private static void printMessages(RetrieveResult result, bool isHaveMessages)
        {
            if (isHaveMessages)
            {
                foreach (RetrieveMessage rm in result.messages)
                {
                    ConsoleHelper.WriteWarningLine(rm.fileName + " " + rm.problem);
                }
            }
        }
    }

}