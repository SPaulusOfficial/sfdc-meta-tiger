using System;
using System.Text;
using System.Text.RegularExpressions;
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
    class ConfigService {
        
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
                    String idOrganization = viewBarInConsoleForScreen(item.Id.ToString());
                    String NickOrganization = viewBarInConsoleForScreen(item.Nick);
                    String Username = viewBarInConsoleForScreen(item.Username);
                    String Password = viewBarInConsoleForScreen(getRowPassword(item.Password,'*')); 
                    String SecurityToken = String.Concat(getRowPassword(item.SecurityToken,'*')," ");
                    String production = String.Concat(getEnvironment(item.Production)," ");
                    String api = String.Concat(item.Api," ");
                    Console.WriteLine(String.Concat(idOrganization,NickOrganization,Username,Password,SecurityToken,production,api));
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

        public static Organization chooseCodeOrganization(string organizationId){
            
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
                    String Password = viewBarInConsoleForScreen(getRowPassword(item.Password,'*')); 
                    String SecurityToken = String.Concat(getRowPassword(item.SecurityToken,'*')," ");
                    String production = String.Concat(getEnvironment(item.Production)," ");
                    String api = String.Concat(item.Api," ");
                    Console.WriteLine(String.Concat(nameOrganization,Username,Password,SecurityToken,production,api));
                }
            }

            try
            {
                ConsoleHelper.WriteQuestionLine(">>> Code Organization:Please enter for new Environment:"); 
                ConsoleHelper.WriteDocLine(organizationId);
               
                Organization enviroment = new Organization();

                foreach(KeyValuePair<int, Organization> item in m_organizations)
                {
                  if(item.Value.Nick == organizationId){
                     enviroment = item.Value;
                  }   
                }

               if(enviroment!=null && enviroment.Nick!=""){ 
                 return enviroment;
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

         public static OrganizationDeploy chooseCodeOrganizationDeploy(Organization organization){
            Dictionary<int,OrganizationDeploy> m_organizationsDeploy = new Dictionary<int,OrganizationDeploy>();
            
            bool isHaveOrganizationDeploy = organization.DeploySettings!=null && organization.DeploySettings.Count>0;
            
            if(isHaveOrganizationDeploy){
              ConsoleHelper.WriteQuestionLine("Choose a deployment configuration for your organization:");
              String rowTitle = getRowForScreen(Constants.propertiesDeployOrganization);
              ConsoleHelper.WriteDocLine(rowTitle);
              foreach (var item in organization.DeploySettings)
                {
                    m_organizationsDeploy.Add(item.Id,item);
                    String nameOrganization = viewBarInConsoleForScreen(item.Id.ToString());
                    String DeployNick = viewBarInConsoleForScreen(item.DeployNick);
                    Console.WriteLine(String.Concat(nameOrganization,DeployNick));
                }
            }

            try
            {
               int id;
               if(isHaveOrganizationDeploy){
                  ConsoleHelper.WriteQuestionLine(">>> Code Organization Deploy:Please enter for new Deploy Settings:"); 
                  id = Int32.Parse(Console.ReadLine());
               }else{
                   return null;
               }

               if(m_organizationsDeploy.ContainsKey(id)){
                   return (m_organizationsDeploy[id]);
               }else{
                   ConsoleHelper.WriteWarningLine("Not Found Deploy Settings");
                   return null;
               }
            }
            catch (System.Exception)
            { 
                ConsoleHelper.WriteErrorLine("Not Found Deploy Settings");
                return null;
            }            
        }

        public static OrganizationDeploy chooseCodeOrganizationDeploy(Organization organization,string organizationDeployType){
            Dictionary<int,OrganizationDeploy> m_organizationsDeploy = new Dictionary<int,OrganizationDeploy>();
            
            bool isHaveOrganizationDeploy = organization.DeploySettings!=null && organization.DeploySettings.Count>0;
            
            if(isHaveOrganizationDeploy){
              ConsoleHelper.WriteQuestionLine("Choose a deployment configuration for your organization:");
              String rowTitle = getRowForScreen(Constants.propertiesDeployOrganization);
              ConsoleHelper.WriteDocLine(rowTitle);
              foreach (var item in organization.DeploySettings)
                {
                    m_organizationsDeploy.Add(item.Id,item);
                    String nameOrganization = viewBarInConsoleForScreen(item.Id.ToString());
                    String DeployNick = viewBarInConsoleForScreen(item.DeployNick);
                    Console.WriteLine(String.Concat(nameOrganization,DeployNick));
                }
            }

            try
            {
               int id;
               if(isHaveOrganizationDeploy){
                  ConsoleHelper.WriteQuestionLine(">>> Code Organization Deploy:Please enter for new Deploy Settings:"); 
                  id = Int32.Parse(organizationDeployType);
               }else{
                   return null;
               }

               if(m_organizationsDeploy.ContainsKey(id)){
                   return (m_organizationsDeploy[id]);
               }else{
                   ConsoleHelper.WriteWarningLine("Not Found Deploy Settings");
                   return null;
               }
            }
            catch (System.Exception)
            { 
                ConsoleHelper.WriteErrorLine("Not Found Deploy Settings");
                return null;
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

        public static PackageManifest chooseCodePackageManifest(string branchName,string pathRepository){
            return createPackageManifest(branchName, pathRepository);
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
            ConsoleHelper.WriteQuestionLine(Constants.LANG_PLEASEENTERNICK);
            String nick = Console.ReadLine();

            ConsoleHelper.WriteQuestionLine(Constants.LANG_PLEASEENTERUSERNAME);
            String username = Console.ReadLine();

            ConsoleHelper.WriteQuestionLine(Constants.LANG_PLEASEENTERPASSWORD);
            String password = Console.ReadLine();

            ConsoleHelper.WriteQuestionLine(Constants.LANG_PLEASEENTERTOKEN);
            String token = Console.ReadLine();

            ConsoleHelper.WriteQuestionLine(Constants.LANG_PLEASEENTERAPI);
            String api = Console.ReadLine();

            ConsoleHelper.WriteQuestionLine(Constants.LANG_PLEASEENTERPRODUCTION);
            
            string production = (Console.ReadLine()=="y") ? "true" : "false";

            Config m_config = getConfig();
            
            Organization vaOrganization = createOrganization(nick, username, password,token,production,api, m_config);

            m_config.Organization.Add(vaOrganization);

            ManageXMLConfig.doWrite(m_config);

            return vaOrganization;
        }

        public static void addOrganizationDeploy(Organization organization){
           Config m_config = getConfig(); 
           Dictionary<int,Organization> m_organizations = new Dictionary<int,Organization>();
           bool isHaveOrganization = m_config.Organization!=null && m_config.Organization.Count>0;

           foreach (var item in m_config.Organization)
           {
                if(item.Id == organization.Id){
                  item.DeploySettings = organization.DeploySettings; 
                }
           }

           ManageXMLConfig.doWrite(m_config);
        }

         private static Organization createOrganization(string nick, string userName, string password,string token,string production,string api, Config m_config)
        {
            return new Organization()
            {
                Username = userName,
                Password = password,
                Nick = nick,
                SecurityToken = token,
                Production = production,
                Api = api,
                Id = m_config.Organization.Count + 1,
                DeploySettings = new List<OrganizationDeploy>(),
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

        public static PackageManifest createPackageManifest(string branchName, string pathRepository)
        {
            string pathPackage = pathRepository + @"//package.xml";  
            
            string pathtarget =  Environment.CurrentDirectory + @"//package//"+branchName +@"//"+ GuidService.createGuid();
            ManageFileDirectory.createPackageDirectory(pathtarget);

            return new PackageManifest()
            {
                PackageFile = pathPackage,
                RepositorySource = pathRepository,
                DirectoryTarget = pathtarget
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

        private static string getEnvironment(string enviroment){
            return (enviroment=="true") ? "Production" : "Sandbox";
        }

        private static string getRowPassword(string input, char target)
        {
            StringBuilder sb = new StringBuilder(input.Length);
            for(int i = 0; i < input.Length; i++)
            {
                sb.Append(target);
            }
            
            return sb.ToString();
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