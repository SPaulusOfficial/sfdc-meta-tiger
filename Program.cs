using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Salesforce_Package.Metadata;
using Salesforce_Package.Manage;
using Salesforce_Package.ManageXML;
using Salesforce_Package.Xml.Config;
using SFDC.Partner;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SFDC.MetadataService;
using System.ServiceModel;

namespace Salesforce_Package
{
    class Program
    {

        static string userName = "bruno_smith10@hotmail.com";
        static string password = "Netero40#####";
        static string securityToken = "wPC63Ccnu6hKydagrwkXT0Rax";
        static string metadataServerUrl;
        static SoapClient sc;
        static MetadataPortTypeClient mc;
        static loginResponse lresp;
        static LoginResult lres;
        static LoginScopeHeader lsr = null;
        static string serverUrl;
        static string sessionId;
        static string userId;

        static void Main(string[] args)
        {
           
            Console.WriteLine("");
            ConsoleHelper.WriteDocLine("###################################################");
            ConsoleHelper.WriteDocLine("#   Salesforce - PACKAGE MANIFEST - Version 4.0   #");
            ConsoleHelper.WriteDocLine("#           Generate files of Repository          #");
            ConsoleHelper.WriteDocLine("#         Author:Bruno Smith Lopes Ribeiro        #");
            ConsoleHelper.WriteDocLine("#        E-mail:bruno_smith10@hotmail.com         #");
            ConsoleHelper.WriteDocLine("###################################################");
            Console.WriteLine("");

            sc = new SoapClient();
           
            Run().Wait();

            List<String> strNames = new List<String>{"*"};

            // end point
            //SFDC.MetadataService.MetadataPortTypeClient.EndpointConfiguration endpoint = new SFDC.MetadataService.MetadataPortTypeClient.EndpointConfiguration(metadataServerUrl);

            var binding = new BasicHttpBinding() {
                Name = "metadata"
            };
            binding.Security.Mode = BasicHttpSecurityMode.Transport;

            var endpoint = new EndpointAddress(metadataServerUrl);

            mc = new MetadataPortTypeClient(binding,endpoint);
            ListMetadataQuery().Wait();
            

         

            //generatePackageWithFilesofRepository();
        }

        static async System.Threading.Tasks.Task Run()
        {
            lresp = await SfLogin();
            lres = lresp.result;
            serverUrl = lres.serverUrl;
            sessionId = lres.sessionId;
            userId = lres.userId;
            metadataServerUrl = lres.metadataServerUrl;
            ConsoleHelper.WriteQuestionLine(sessionId);
            ConsoleHelper.WriteQuestionLine("Break");
        }

        static async Task<loginResponse> SfLogin()
        {
            loginResponse lr = await sc.loginAsync(null,null, userName, password + securityToken);
            return lr;
        }


        static async Task<SFDC.MetadataService.listMetadataResponse> ListMetadataQuery()
        {
            SFDC.MetadataService.SessionHeader sessionHeader = new SFDC.MetadataService.SessionHeader { sessionId = sessionId };

            SFDC.MetadataService.CallOptions callOptions = new SFDC.MetadataService.CallOptions();
            callOptions.client  = userId;

            SFDC.MetadataService.ListMetadataQuery q = new SFDC.MetadataService.ListMetadataQuery();
            q.type = "CustomObject";
            SFDC.MetadataService.listMetadataResponse lstMetaResponse =  await mc.listMetadataAsync(sessionHeader, callOptions, new []{ q} , 45.0);
            foreach (FileProperties f in lstMetaResponse.result)
            {
                Console.WriteLine("response with message: " + f.fileName);
                Console.WriteLine("response with message: " + f.fullName);
            }
            
            return lstMetaResponse;
        }

        

        public static void generatePackageWithFilesofRepository(){
            var mapPackage = new Dictionary<string, List<string>>();

            String pathPackage = null;
            String pathRepository = null;
            String pathTarget = null;

            ManageXMLConfig manageXmlConfig = new ManageXMLConfig();

            Config m_config = manageXmlConfig.config;
            
            if(m_config.PackageManifest.Count>0){                
                PackageManifest packageManifest = chooseCodePackageManifest();

                pathPackage = packageManifest.PackageFile;
                pathRepository = packageManifest.RepositorySource;
                pathTarget = packageManifest.DirectoryTarget!=null ? packageManifest.DirectoryTarget : m_config.GeneralDirectoryTarget;
            }else{
                pathTarget = m_config.GeneralDirectoryTarget;
            }

            if(pathPackage==null || pathRepository==null || pathTarget==null){

                ConsoleHelper.WriteQuestionLine(">>> Please enter the path of the Package.xml:");
                
                pathPackage = Console.ReadLine();

                ConsoleHelper.WriteQuestionLine(">>> Please enter the path of the repository where the files are:");

                pathRepository = Console.ReadLine();

                PackageManifest myManifest = new PackageManifest(){
                    PackageFile = pathPackage,
                    RepositorySource = pathRepository,
                    Id = m_config.PackageManifest.Count + 1
                };

                m_config.PackageManifest.Add(myManifest);

                ManageXMLConfig.doWrite(m_config);
            }

            if(!ManageDirectory.validateDirectory(pathRepository)){
                ConsoleHelper.WriteErrorLine(">>> Path not found:" + pathRepository);
                return;
            }

            mapPackage = ManageXMLPackage.buildMap(pathPackage);    

            List<IMetadata> MetaDatas = stageCreateDirectorys(mapPackage, pathTarget);
            stageValidateMetadata(mapPackage, MetaDatas);
            stageCopyMetadata(pathRepository, pathTarget, MetaDatas);
            stageMergeMetadata(pathRepository,pathTarget,MetaDatas);
            stageCopyPackageFinal(pathPackage, pathTarget);

            ConsoleHelper.WriteDoneLine(">> Finalize the process...");
        }


        public static PackageManifest chooseCodePackageManifest(){
            ConsoleHelper.WriteQuestionLine(">>> Choose code package manifest save in Config:");
            Config m_config = ManageXMLConfig.Deserialize();
            Dictionary<int,PackageManifest> m_packages = new Dictionary<int,PackageManifest>();
            if(m_config.PackageManifest.Count>0){
              ConsoleHelper.WriteDocLine("Id | Package | RepositoryPath | DirectoryTarget");
              foreach (var item in m_config.PackageManifest)
                {
                    m_packages.Add(item.Id,item);
                    String namePackage = String.Concat(item.Id," | ");
                    String packageFilePath = String.Concat(item.PackageFile," | ");
                    String RepositoryPath = String.Concat(item.RepositorySource," | ");
                    String DirectoryTarget = String.Concat(item.DirectoryTarget," ");
                    Console.WriteLine(String.Concat(namePackage,packageFilePath,RepositoryPath,DirectoryTarget));
                }
            }

            try
            {
               ConsoleHelper.WriteQuestionLine(">>> Code Package:"); 
               int id = Int32.Parse(Console.ReadLine());

               if(m_packages.ContainsKey(id)){
                   return (m_packages[id]);
               }else{
                   ConsoleHelper.WriteWarningLine("Not Found PackageManifest");
                   return new PackageManifest();
               }
            }
            catch (System.Exception)
            { 
                return new PackageManifest();
                throw;
            }

            
        }

        private static void stageMergeMetadata(string pathSource,string pathDir, List<IMetadata> MetaDatas)
        {
            ConsoleHelper.WriteDoneLine(">> Merging Metadata...");
            foreach (IMetadata m_Metadata in MetaDatas)
            {
                m_Metadata.doMerge();
            }
            ManageXMLCustomObjectMerge merge = ManageXMLCustomObjectMerge.getInstance();
            merge.defaultParameters(pathSource);
            merge.writeAllInstances(pathDir);
        }

        private static void stageCopyPackageFinal(string path, string pathDir)
        {
            ConsoleHelper.WriteDoneLine(">> Copying package...");            

            ManageCopy.doCopy(path.Replace("package.xml", ""), pathDir, "package.xml");            
        }

        private static void stageCopyMetadata(string pathFiles, string pathDir, List<IMetadata> MetaDatas)
        {
            ConsoleHelper.WriteDoneLine(">> Copying Metadata...");
            foreach (IMetadata m_Metadata in MetaDatas)
            {
                m_Metadata.doCopy(pathFiles, pathDir);
            }
        }

        private static void stageValidateMetadata(Dictionary<string, List<string>> mapPackage, List<IMetadata> MetaDatas)
        {
           ConsoleHelper.WriteDoneLine(">> Validating Metadata...");

            foreach (var type in mapPackage)
            {
                foreach (var member in type.Value)
                {
                    foreach (IMetadata m_Metadata in MetaDatas)
                    {
                        m_Metadata.isValidThenAdd(type.Key, member);
                    }
                }
            }
        }

        private static List<IMetadata> stageCreateDirectorys(Dictionary<string, List<string>> mapPackage, string pathDir)
        {
            ConsoleHelper.WriteDoneLine(">> Creating directories...");
            List<IMetadata> MetaDatas = ManageDirectory.buildDirectorys(mapPackage, pathDir);
            return MetaDatas;
        }
                
    }


    
}
