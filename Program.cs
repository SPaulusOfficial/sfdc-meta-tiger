using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Salesforce_Package.Metadata;
using Salesforce_Package.Manage;
using Salesforce_Package.ManageXML;
using Salesforce_Package.Xml.Config;
using Salesforce_Package.MetadataApi;

namespace Salesforce_Package
{
    class Program
    {

        static void Main(string[] args)
        {
           
            Console.WriteLine("");
            ConsoleHelper.WriteDocLine("###################################################");
            ConsoleHelper.WriteDocLine("#      Salesforce - All for One - Version 4.0     #");
            ConsoleHelper.WriteDocLine("#           Generate files of Repository          #");
            ConsoleHelper.WriteDocLine("#         Author:Bruno Smith Lopes Ribeiro        #");
            ConsoleHelper.WriteDocLine("#        E-mail:bruno_smith10@hotmail.com         #");
            ConsoleHelper.WriteDocLine("###################################################");
            ConsoleHelper.WriteQuestionLine("1 - Get All Package.xml");
            ConsoleHelper.WriteQuestionLine("2 - Generate Package With Files of Repository");
            int strAction = Convert.ToInt32(Console.ReadLine());

            switch (strAction)
            {
                case 1: 
                        getAllPackage();
                        break;
                case 2: generatePackageWithFilesofRepository();
                        break;
                default:
                        break;
            }
           
           
        }

        public static void getAllPackage(){
             Organization m_organization = chooseCodeOrganization();
             MetadataService.getAllPackage(m_organization);
             ConsoleHelper.WriteDoneLine(">> Finalize the process...");
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

        public static Organization chooseCodeOrganization(){
            ConsoleHelper.WriteQuestionLine(">>> Choose code organization save in Config:");
            Config m_config = ManageXMLConfig.Deserialize();
            Dictionary<int,Organization> m_organizations = new Dictionary<int,Organization>();
            if(m_config.PackageManifest.Count>0){
              ConsoleHelper.WriteDocLine("Id | UserName | Password | SecurityToken");
              foreach (var item in m_config.Organization)
                {
                    m_organizations.Add(item.Id,item);
                    String nameOrganization = String.Concat(item.Id," | ");
                    String Username = String.Concat(item.Username," | ");
                    String Password = String.Concat(item.Password," | ");
                    String SecurityToken = String.Concat(item.SecurityToken," ");
                    Console.WriteLine(String.Concat(nameOrganization,Username,Password,SecurityToken));
                }
            }

            try
            {
               ConsoleHelper.WriteQuestionLine(">>> Code Organization:"); 
               int id = Int32.Parse(Console.ReadLine());

               if(m_organizations.ContainsKey(id)){
                   return (m_organizations[id]);
               }else{
                   ConsoleHelper.WriteWarningLine("Not Found Organization");
                   return new Organization();
               }
            }
            catch (System.Exception)
            { 
                return new Organization();
                throw;
            }

            
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
