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

        private static RetrieveResult checkResultsOfRetrieve(MetadataApiClientResponse response, string asyncId)
        {
            RetrieveResult result;
            checkRetrieveStatusResponse responseCheck;
            do
            {
               try{
                   responseCheck = MetadataApiCheckRetrieveService.checkRetrieveStatus(response.Metadataclient, asyncId);
                   result = responseCheck.result;
                   ConsoleHelper.WriteDocLine("We are check results, please wait!");
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