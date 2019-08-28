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
    class MetadataConfigService {
        
        public static Config getConfig(){
            return ReadConfig();
        }

        public static Organization chooseCodeOrganization(){
            
            Config m_config = ManageXMLConfig.Deserialize();
            Dictionary<int,Organization> m_organizations = new Dictionary<int,Organization>();
            
            bool isHaveOrganization = m_config.Organization!=null && m_config.Organization.Count>0;
            
            if(isHaveOrganization){
              ConsoleHelper.WriteQuestionLine(Constants.LANG_CHOOSECODEPACKAGEMANIFESTINCONFIG);
              String rowTitle = getRowForScreen(Constants.propertiesOrganization);
              ConsoleHelper.WriteDocLine(rowTitle);
              foreach (var item in m_config.Organization)
                {
                    m_organizations.Add(item.Id,item);
                    String nameOrganization = viewBarInConsoleForScreen(item.Id.ToString());
                    String Username = viewBarInConsoleForScreen(item.Username);
                    String Password = viewBarInConsoleForScreen(item.Password); 
                    String SecurityToken = String.Concat(item.SecurityToken," ");
                    String production = String.Concat(item.Production," ");
                    Console.WriteLine(String.Concat(nameOrganization,Username,Password,SecurityToken,production));
                }
            }

            try
            {
               int id;
               if(isHaveOrganization){
                  ConsoleHelper.WriteQuestionLine(">>> Code Organization:Please enter for new Environment:"); 
                  id = Int32.Parse(Console.ReadLine());
               }else{
                   return generateOrganizationManifest();
               }

               if(m_organizations.ContainsKey(id)){
                   return (m_organizations[id]);
               }else{
                   ConsoleHelper.WriteWarningLine("Not Found Organization");
                   return new Organization();
               }
            }
            catch (System.Exception)
            { 
                 ConsoleHelper.WriteErrorLine("Not Found Organization");
                return generateOrganizationManifest();
            }

            
        }

        public static PackageManifest chooseCodePackageManifest(){
            Dictionary<int, PackageManifest> m_packages;

            ConsoleHelper.WriteQuestionLine(Constants.LANG_CHOOSECODEPACKAGEMANIFESTINCONFIG);

            Config m_config = ReadConfig();
            m_packages = viewPackageManifestInConfig(m_config);

            try
            {
                return selectedCodePackageManifest(m_packages,m_config);
            }
            catch (System.Exception)
            {
                return generatePackageManifest();
            }
        }

        private static PackageManifest generatePackageManifest(){
            ConsoleHelper.WriteQuestionLine(Constants.LANG_PLEASEENTERPATHPACKAGE);
            String pathPackage = Console.ReadLine();

            ConsoleHelper.WriteQuestionLine(Constants.LANG_PLEASEENTERPATHREPOSITORY);
            String pathRepository = Console.ReadLine();

            ConsoleHelper.WriteQuestionLine(Constants.LANG_PLEASEENTERTARGETPATH);
            String targetFiles = Console.ReadLine();

            Config m_config = getConfig();
            
            PackageManifest myManifest = createPackageManifest(pathPackage, pathRepository,targetFiles, m_config);

            m_config.PackageManifest.Add(myManifest);

            ManageXMLConfig.doWrite(m_config);

            return myManifest;
        }

        private static Organization generateOrganizationManifest(){
            ConsoleHelper.WriteQuestionLine(Constants.LANG_PLEASEENTERUSERNAME);
            String username = Console.ReadLine();

            ConsoleHelper.WriteQuestionLine(Constants.LANG_PLEASEENTERPASSWORD);
            String password = Console.ReadLine();

            ConsoleHelper.WriteQuestionLine(Constants.LANG_PLEASEENTERTOKEN);
            String token = Console.ReadLine();

            ConsoleHelper.WriteQuestionLine(Constants.LANG_PLEASEENTERPRODUCTION);
            
            string production = (Console.ReadLine()=="y") ? "true" : "false";

            Config m_config = getConfig();
            
            Organization vaOrganization = createOrganization(username, password,token,production, m_config);

            m_config.Organization.Add(vaOrganization);

            ManageXMLConfig.doWrite(m_config);

            return vaOrganization;
        }

         private static Organization createOrganization(string userName, string password,string token,string production, Config m_config)
        {
            return new Organization()
            {
                Username = userName,
                Password = password,
                SecurityToken = token,
                Production = production,
                Id = m_config.Organization.Count + 1,
            };
        }

        private static PackageManifest createPackageManifest(string pathPackage, string pathRepository,string pathtarget, Config m_config)
        {
            return new PackageManifest()
            {
                PackageFile = pathPackage,
                RepositorySource = pathRepository,
                Id = m_config.PackageManifest.Count + 1,
                DirectoryTarget = (pathtarget != null) ? pathtarget : m_config.GeneralDirectoryTarget
            };
        }

        private static PackageManifest selectedCodePackageManifest(Dictionary<int, PackageManifest> m_packages,Config m_config)
        {
            ConsoleHelper.WriteQuestionLine(Constants.LANG_CODEPACKAGE);
            int id = Int32.Parse(Console.ReadLine());

            Boolean isHaveKey = m_packages.ContainsKey(id);

            if (isHaveKey){
                PackageManifest selectedManifest = m_packages[id];
                selectedManifest.DirectoryTarget = selectedManifest.DirectoryTarget!=null ? selectedManifest.DirectoryTarget : m_config.GeneralDirectoryTarget;
                return (selectedManifest);
            }else{
                ConsoleHelper.WriteWarningLine(Constants.LANG_NOTFOUNDPACKAGEMANIFEST);
                throw new Exception();
            }
        }

        private static Config ReadConfig()
        {
            return ManageXMLConfig.Deserialize();
        }

        public static Dictionary<int,PackageManifest> viewPackageManifestInConfig(Config m_config){
            Dictionary<int,PackageManifest> m_packages = new Dictionary<int,PackageManifest>();
            
            Boolean isHavePackageManifestInConfig = m_config.PackageManifest.Count>0;
            
            if(isHavePackageManifestInConfig){
                viewRowsPackageManifest(m_config, m_packages);
            }
            return m_packages;
        }

        private static void viewRowsPackageManifest(Config m_config, Dictionary<int, PackageManifest> m_packages)
        {
            string rowTitle = getRowForScreen(Constants.propertiesPackageManifest);
            ConsoleHelper.WriteDocLine(rowTitle);

            foreach (var item in m_config.PackageManifest)
            {
                m_packages.Add(item.Id, item);

                string rowLine = getRowLinePackageForScreen(item);

                Console.WriteLine(rowLine);
            }
        }

        private static string getRowForScreen(List<String> listFieldsForTitle){
            List<String> rowPropertiesTitle = new List<String>();

            var lastField = listFieldsForTitle[listFieldsForTitle.Count - 1];

            foreach(String fieldTitle in listFieldsForTitle){
               
               Boolean isLastField = lastField!=fieldTitle;

               if(isLastField){
                  rowPropertiesTitle.Add(viewBarInConsoleForScreen(fieldTitle));
               }else{
                  rowPropertiesTitle.Add(fieldTitle);
               }
            }
            String rowTitle = String.Concat(rowPropertiesTitle);
            return rowTitle;
        }

        private static string getRowLinePackageForScreen(PackageManifest item)
        {
            List<String> rowPropertiesLine = new List<String>();
            string rowLine = getRowForScreen(new List<String> {item.Id.ToString(),item.PackageFile,
            item.RepositorySource,item.DirectoryTarget});
            return rowLine;
        }

        public static String viewBarInConsoleForScreen(String paStr){
           return String.Concat(paStr,Constants.separateColumnsInConsole);
       }

    }
}