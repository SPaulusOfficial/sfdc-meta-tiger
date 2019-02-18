using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Salesforce_Package.Metadata;
using Salesforce_Package.Manage;
using Salesforce_Package.ManageXML;

namespace Salesforce_Package
{
    class Program
    {
        static void Main(string[] args)
        {
            var mapPackage = new Dictionary<string, List<string>>();
            Console.WriteLine("");
            ConsoleHelper.WriteDocLine("###################################################");
            ConsoleHelper.WriteDocLine("#   Salesforce - PACKAGE MANIFEST - Version 3.0   #");
            ConsoleHelper.WriteDocLine("#           Generate files of Repository          #");
            ConsoleHelper.WriteDocLine("#         Author:Bruno Smith Lopes Ribeiro        #");
            ConsoleHelper.WriteDocLine("#        E-mail:bruno_smith10@hotmail.com         #");
            ConsoleHelper.WriteDocLine("###################################################");
            Console.WriteLine("");
            ConsoleHelper.WriteQuestionLine(">>> Please enter the path of the Package.xml:");
            
            String path = Console.ReadLine();

            ConsoleHelper.WriteQuestionLine(">>> Please enter the path of the repository where the files are:");

            String pathFiles = Console.ReadLine();

            if(!ManageDirectory.validateDirectory(pathFiles)){
                ConsoleHelper.WriteErrorLine(">>> Path not found:" + pathFiles);
                return;
            }

            mapPackage = ManageXMLPackage.buildMap(path);
            
            String pathDir = "C:\\";
            pathDir = pathDir + "\\package";            

            List<IMetadata> MetaDatas = stageCreateDirectorys(mapPackage, pathDir);
            stageValidateMetadata(mapPackage, MetaDatas);
            stageCopyMetadata(pathFiles, pathDir, MetaDatas);
            stageCopyPackageFinal(path, pathDir);

            ConsoleHelper.WriteDoneLine(">> Finalize the process...");
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
