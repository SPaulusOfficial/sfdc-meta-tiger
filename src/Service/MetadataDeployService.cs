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
             MetadataApiDeployRequest request = generateDeployRequest();
             //MetadataApiService.deployMetadata(m_organization, request);
             ConsoleHelper.WriteDoneLine(">> Finalize the process...");
        }

        public static MetadataApiDeployRequest generateDeployRequest(){
            MetadataApiDeployRequest request = new MetadataApiDeployRequest();
            request.DebuggingHeader = generateDebuggingHeader();
            request.DeployOptions = generateDeployOptions();
            //request.ZipFile = getZipFile();
            return request;
        }

        public static DebuggingHeader generateDebuggingHeader(){
            DebuggingHeader debugHeader = new DebuggingHeader();
            //deprecated debugHeader.debugLevel = LogType.None;   
            List<LogInfo> logInfoList = generateLogInfo();
            debugHeader.categories = logInfoList.ToArray();         
            return debugHeader;
        }

        public static List<LogInfo> generateLogInfo(){
            List<LogInfo> logInfoList = new List<LogInfo>(); 
            Dictionary<string, LogCategory> categories = new Dictionary<string, LogCategory>();
            
            categories.Add("Db", LogCategory.Db);
            categories.Add("Workflow", LogCategory.Workflow);
            categories.Add("Validation", LogCategory.Validation);
            categories.Add("Callout", LogCategory.Callout);
            categories.Add("Apex_code", LogCategory.Apex_code);
            categories.Add("Apex_profiling", LogCategory.Apex_profiling);
            categories.Add("Visualforce", LogCategory.Visualforce);
            categories.Add("Wave", LogCategory.Wave);
            categories.Add("Nba", LogCategory.Nba);
            categories.Add("All", LogCategory.All);

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

                ConsoleHelper.WriteQuestionLine("Choose a level for category: " + category.Key + " ? 0-NONE|1-ERROR|2-WARN|3-INFO|4-DEBUG|5-FINE|6-FINER|7-FINEST");
                
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
            }
           

            return logInfoList;
        }

        public static DeployOptions generateDeployOptions(){
            DeployOptions deployOptions = new DeployOptions();
            return deployOptions;
        }

        /*public static byte[] getZipFile(){
            byte[] zipFile = byte[];
            return zipFile;
        }*/

    }

}