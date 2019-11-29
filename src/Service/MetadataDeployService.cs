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
using SFDC.Metadata;

namespace MetaTiger.Metadata{
    class MetadataDeployService {
        
        public static void deployPackage(){
             Organization m_organization = MetadataConfigService.chooseCodeOrganization();
             MetadataApiDeployRequest request = generateDeployRequest(m_organization);
             MetadataApiService.deployMetadata(m_organization, request);
             ConsoleHelper.WriteDoneLine(">> Finalize the process...");
        }

        public static void deployPackage(string organizationId,string organizationdeploytype,string directoryTarget){
             Organization m_organization = MetadataConfigService.chooseCodeOrganization(organizationId);
             MetadataApiDeployRequest request = generateDeployRequest(m_organization,organizationdeploytype,directoryTarget);
             MetadataApiService.deployMetadata(m_organization, request);
             ConsoleHelper.WriteDoneLine(">> Finalize the process...");
        }

        public static MetadataApiDeployRequest generateDeployRequest(Organization m_organization,string organizationdeploytype,string directoryTarget){
            MetadataApiDeployRequest request = new MetadataApiDeployRequest();
            OrganizationDeploy organizationDeploy;
            bool isHaveDeploySettings = m_organization.DeploySettings!=null && m_organization.DeploySettings.Count>0;

            if(isHaveDeploySettings){
             organizationDeploy = MetadataConfigService.chooseCodeOrganizationDeploy(m_organization,organizationdeploytype); 
             if(organizationDeploy==null){
               organizationDeploy = createOrganizationDeploy(m_organization.DeploySettings.Count,m_organization);
             }
            }else{
             organizationDeploy = createOrganizationDeploy(0,m_organization);
            }

            request.DebuggingHeader = organizationDeploy.DebuggingHeader;
            request.DeployOptions = organizationDeploy.DeployOptions;

            ConsoleHelper.WriteDocLine(">> Deployment Directory Entry");
            request.ZipFile = getZipFile(directoryTarget);
            return request;
        }

        public static MetadataApiDeployRequest generateDeployRequest(Organization m_organization){
            MetadataApiDeployRequest request = new MetadataApiDeployRequest();
            OrganizationDeploy organizationDeploy;
            bool isHaveDeploySettings = m_organization.DeploySettings!=null && m_organization.DeploySettings.Count>0;

            if(isHaveDeploySettings){
             organizationDeploy = MetadataConfigService.chooseCodeOrganizationDeploy(m_organization); 
             if(organizationDeploy==null){
               organizationDeploy = createOrganizationDeploy(m_organization.DeploySettings.Count,m_organization);
             }
            }else{
             organizationDeploy = createOrganizationDeploy(0,m_organization);
            }

            request.DebuggingHeader = organizationDeploy.DebuggingHeader;
            request.DeployOptions = organizationDeploy.DeployOptions;

            ConsoleHelper.WriteDocLine(">> Deployment Directory Entry");
            request.ZipFile = getZipFile();
            return request;
        }

        public static OrganizationDeploy createOrganizationDeploy(int id,Organization m_organization){
             OrganizationDeploy organizationDeploy = new OrganizationDeploy();
             organizationDeploy.Id = id+1;
             ConsoleHelper.WriteQuestionLine(">> Deploy Nick Entry ");
             organizationDeploy.DeployNick = Console.ReadLine();
             
             ConsoleHelper.WriteDocLine(">> Debugging Header Entry ");
             organizationDeploy.DebuggingHeader = generateDebuggingHeader();
             
             ConsoleHelper.WriteDocLine(">> Deploy Options Entry ");
             organizationDeploy.DeployOptions = generateDeployOptions(m_organization);
             
             m_organization.DeploySettings.Add(organizationDeploy);
             MetadataConfigService.addOrganizationDeploy(m_organization);

             return organizationDeploy;
        }

        public static DebuggingHeader generateDebuggingHeader(){
            DebuggingHeader debugHeader = new DebuggingHeader();   
            List<LogInfo> logInfoList = generateLogInfo();
            debugHeader.categories = logInfoList.ToArray();         
            return debugHeader;
        }

        public static List<LogInfo> generateLogInfo(){
            List<LogInfo> logInfoList = new List<LogInfo>(); 
            Dictionary<string, LogCategory> categories = new Dictionary<string, LogCategory>();
            
            ConsoleHelper.WriteQuestionLine("Do you want to choose a single level for all logs?");
            string singleLevel = (Console.ReadLine()=="y") ? "true" : "false";
            bool allChoice = (singleLevel=="true") ? true : false;
            
            if(allChoice){
                categories.Add("All", LogCategory.All);    
            }else{
                categories.Add("Db", LogCategory.Db);
                categories.Add("Workflow", LogCategory.Workflow);
                categories.Add("Validation", LogCategory.Validation);
                categories.Add("Callout", LogCategory.Callout);
                categories.Add("Apex_code", LogCategory.Apex_code);
                categories.Add("Apex_profiling", LogCategory.Apex_profiling);
                categories.Add("Visualforce", LogCategory.Visualforce);
                categories.Add("Wave", LogCategory.Wave);
                categories.Add("Nba", LogCategory.Nba);   
            }

            Dictionary<string, LogCategoryLevel> categoriesLevel = new Dictionary<string, LogCategoryLevel>();
            categoriesLevel.Add("None",LogCategoryLevel.None);
            categoriesLevel.Add("Error",LogCategoryLevel.Error);
            categoriesLevel.Add("Warn",LogCategoryLevel.Warn);
            categoriesLevel.Add("Info",LogCategoryLevel.Info);
            categoriesLevel.Add("Debug",LogCategoryLevel.Debug);
            categoriesLevel.Add("Fine",LogCategoryLevel.Fine);
            categoriesLevel.Add("Finer",LogCategoryLevel.Finer);
            categoriesLevel.Add("Finest",LogCategoryLevel.Finest);          
            

            foreach(KeyValuePair<string, LogCategory> category in categories){
                LogInfo info = new LogInfo(); 
                
                info.category = category.Value;

                ConsoleHelper.WriteQuestionLine("Choose a level for category for Log: " + category.Key + " ? 0-NONE|1-ERROR|2-WARN|3-INFO|4-DEBUG|5-FINE|6-FINER|7-FINEST");
                
                int numberLevel = Convert.ToInt32(Console.ReadLine()); 

                switch (numberLevel)
                {
                    case 0:
                        info.level = categoriesLevel["None"];
                        break;
                    case 1:
                        info.level = categoriesLevel["Error"];
                        break;
                    case 2:
                        info.level = categoriesLevel["Warn"];
                        break;
                    case 3:
                        info.level = categoriesLevel["Info"];
                        break;
                    case 4:
                        info.level = categoriesLevel["Debug"];
                        break;
                    case 5:
                        info.level = categoriesLevel["Fine"];
                        break;
                    case 6:
                        info.level = categoriesLevel["Finer"];
                        break;
                    case 7:
                        info.level = categoriesLevel["Finest"];
                        break;        
                    default:
                        info.level = categoriesLevel["None"];
                        break;
                }
                logInfoList.Add(info);
            }
           

            return logInfoList;
        }

        public static TestLevel generateTestLevel(){
            TestLevel testLevel;
            Dictionary<string, TestLevel> typesTest = new Dictionary<string, TestLevel>();
            
            typesTest.Add("NoTestRun", TestLevel.NoTestRun);
            typesTest.Add("RunSpecifiedTests", TestLevel.RunSpecifiedTests);
            typesTest.Add("RunLocalTests", TestLevel.RunLocalTests);
            typesTest.Add("RunAllTestsInOrg", TestLevel.RunAllTestsInOrg);
            
            ConsoleHelper.WriteQuestionLine("Choose a level for Test ? 0-NoTestRun|1-RunSpecifiedTests|2-RunLocalTests|3-RunAllTestsInOrg");
                
            int numberLevel = Convert.ToInt32(Console.ReadLine()); 

                switch (numberLevel)
                {
                    case 0:
                        testLevel = typesTest["NoTestRun"];
                        break;
                    case 1:
                        testLevel = typesTest["RunSpecifiedTests"];
                        break;
                    case 2:
                        testLevel = typesTest["RunLocalTests"];
                        break;
                    case 3:
                        testLevel = typesTest["RunAllTestsInOrg"];
                        break;
                    default:
                        testLevel = typesTest["RunLocalTests"];
                        break;
                }

            return testLevel;
        }

        public static String[] generateRunTests(){
            List<string> classTests = new List<string>();
            string className;
            bool isHaveClass;

            do{
               ConsoleHelper.WriteQuestionLine(">> Enter with name of test class... (blank will go to the next step!)");
               className = Console.ReadLine();  
               isHaveClass = (className!=null && className!= "");
               if(isHaveClass)
               classTests.Add(className);
             }while (isHaveClass);

             return classTests.ToArray();
        }

        public static DeployOptions generateDeployOptions(Organization m_organization){
            DeployOptions deployOptions = new DeployOptions();
            deployOptions.allowMissingFiles = false;
            deployOptions.autoUpdatePackage = false;
            deployOptions.checkOnly = false;
            deployOptions.ignoreWarnings = false;
            deployOptions.performRetrieve = false;
            deployOptions.purgeOnDelete = false;
            deployOptions.rollbackOnError = true;
            deployOptions.testLevel = TestLevel.RunLocalTests;

            if(m_organization.Production != "true"){
                ConsoleHelper.WriteQuestionLine("Do you want to enable allowMissingFiles ?");
                string allowMissingFiles = (Console.ReadLine()=="y") ? "true" : "false";
                deployOptions.allowMissingFiles = (allowMissingFiles=="y") ? true : false;

                ConsoleHelper.WriteQuestionLine("Do you want to enable autoUpdatePackage ?");
                string autoUpdatePackage = (Console.ReadLine()=="y") ? "true" : "false";
                deployOptions.autoUpdatePackage = (autoUpdatePackage=="y") ? true : false;
            }
           
            ConsoleHelper.WriteQuestionLine("Do you want to enable checkOnly ?");
            string checkOnly = (Console.ReadLine()=="y") ? "true" : "false";
            deployOptions.checkOnly = (checkOnly=="y") ? true : false;

            ConsoleHelper.WriteQuestionLine("Do you want to enable ignoreWarnings ?");
            string ignoreWarnings = (Console.ReadLine()=="y") ? "true" : "false";
            deployOptions.ignoreWarnings = (ignoreWarnings=="y") ? true : false;

            //ConsoleHelper.WriteQuestionLine("Do you want to enable performRetrieve ?");
            //string performRetrieve = (Console.ReadLine()=="y") ? "true" : "false";
            //deployOptions.performRetrieve = (performRetrieve=="y") ? true : false;

            ConsoleHelper.WriteQuestionLine("Do you want to enable purgeOnDelete ?");
            string purgeOnDelete = (Console.ReadLine()=="y") ? "true" : "false";
            deployOptions.purgeOnDelete = (purgeOnDelete=="y") ? true : false;

            if(m_organization.Production != "true"){
                ConsoleHelper.WriteQuestionLine("Do you want to enable rollbackOnError ?");
                string rollbackOnError = (Console.ReadLine()=="y") ? "true" : "false";
                deployOptions.rollbackOnError = (rollbackOnError=="y") ? true : false;
            }
             
            deployOptions.testLevel = generateTestLevel();

            if(deployOptions.testLevel == TestLevel.RunSpecifiedTests){
              deployOptions.runTests = generateRunTests();
            }

            ConsoleHelper.WriteQuestionLine("Do you want to enable singlePackage ?");
            string singlePackage = (Console.ReadLine()=="y") ? "true" : "false";
            deployOptions.singlePackage = (singlePackage=="y") ? true : false;

            return deployOptions;
        }

        public static byte[] getZipFile(){
            ConsoleHelper.WriteQuestionLine("Please enter the path directory package:");
            string path = Console.ReadLine();
            byte[] zipFile = ManageFileZip.createZipFile(path,false);
            return zipFile;
        }

         public static byte[] getZipFile(string directoryTarget){
            ConsoleHelper.WriteQuestionLine("Please enter the path directory package:");
            ConsoleHelper.WriteDocLine(directoryTarget);
            string path = directoryTarget;
            byte[] zipFile = ManageFileZip.createZipFile(path,true);
            return zipFile;
        }

    }

}