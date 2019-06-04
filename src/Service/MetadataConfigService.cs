using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Salesforce_Package.Metadata;
using Salesforce_Package.Manage;
using Salesforce_Package.ManageXML;
using Salesforce_Package.Xml.Config;
using Salesforce_Package.MetadataApi;

namespace Salesforce_Package.Metadata{
    class MetadataConfigService {
        
        public static Config getConfig(){
            return ReadConfig();
        }

        public static PackageManifest chooseCodePackageManifest(){
            Dictionary<int, PackageManifest> m_packages;

            ConsoleHelper.WriteQuestionLine(">>> Choose code package manifest save in Config:");

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
            ConsoleHelper.WriteQuestionLine(">>> Please enter the path of the Package.xml:");
            String pathPackage = Console.ReadLine();

            ConsoleHelper.WriteQuestionLine(">>> Please enter the path of the repository where the files are:");
            String pathRepository = Console.ReadLine();

            Config m_config = getConfig();
            
            PackageManifest myManifest = createPackageManifest(pathPackage, pathRepository, m_config);

            m_config.PackageManifest.Add(myManifest);

            ManageXMLConfig.doWrite(m_config);

            return myManifest;
        }

        private static PackageManifest createPackageManifest(string pathPackage, string pathRepository, Config m_config)
        {
            return new PackageManifest()
            {
                PackageFile = pathPackage,
                RepositorySource = pathRepository,
                Id = m_config.PackageManifest.Count + 1,
                DirectoryTarget =  m_config.GeneralDirectoryTarget
            };
        }

        private static PackageManifest selectedCodePackageManifest(Dictionary<int, PackageManifest> m_packages,Config m_config)
        {
            ConsoleHelper.WriteQuestionLine(">>> Code Package:");
            int id = Int32.Parse(Console.ReadLine());

            Boolean isHaveKey = m_packages.ContainsKey(id);

            if (isHaveKey){
                PackageManifest selectedManifest = m_packages[id];
                selectedManifest.DirectoryTarget = selectedManifest.DirectoryTarget!=null ? selectedManifest.DirectoryTarget : m_config.GeneralDirectoryTarget;
                return (selectedManifest);
            }else{
                ConsoleHelper.WriteWarningLine("Not Found PackageManifest");
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
            string rowTitle = getRowTitle();
            ConsoleHelper.WriteDocLine(rowTitle);

            foreach (var item in m_config.PackageManifest)
            {
                m_packages.Add(item.Id, item);

                string rowLine = getRowLine(item);

                Console.WriteLine(rowLine);
            }
        }

        private static string getRowTitle(){
            List<String> rowPropertiesTitle = new List<String>();
            rowPropertiesTitle.Add(viewBarInConsole("Id"));
            rowPropertiesTitle.Add(viewBarInConsole("Package"));
            rowPropertiesTitle.Add(viewBarInConsole("RepositoryPath"));
            rowPropertiesTitle.Add(String.Concat("DirectoryTarget", " "));
            String rowTitle = String.Concat(rowPropertiesTitle);
            return rowTitle;
        }

        private static string getRowLine(PackageManifest item)
        {
            List<String> rowPropertiesLine = new List<String>();
            rowPropertiesLine.Add(viewBarInConsole(item.Id.ToString()));
            rowPropertiesLine.Add(viewBarInConsole(item.PackageFile));
            rowPropertiesLine.Add(viewBarInConsole(item.RepositorySource));
            rowPropertiesLine.Add(String.Concat(item.DirectoryTarget, " "));

            String rowLine = String.Concat(rowPropertiesLine);
            return rowLine;
        }

        public static String viewBarInConsole(String paStr){
           return String.Concat(paStr," | ");
       }

    }
}