using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Salesforce_Package.Metadata;

namespace Salesforce_Package
{
    class Program
    {
        static void Main(string[] args)
        {
            var mapPackage = new Dictionary<string, List<string>>();
            Console.WriteLine("############################");
            Console.WriteLine("#    PACKAGE MANIFEST      #");
            Console.WriteLine("############################");

            Console.WriteLine(">>> Please enter the path of the Package.xml path");
            
            String path = Console.ReadLine();

            Console.WriteLine(">>> Please enter the path of the repository where the files are:");

            String pathFiles = Console.ReadLine();

            if(!ManageDirectory.validateDirectory(pathFiles)){
                Console.WriteLine(">>> Path not found:" + pathFiles);
                return;
            }

            mapPackage = ManageXMLPackage.buildMap(path);
            
            String pathDir = "C:\\";
            pathDir = pathDir + "\\package";            

            List<IMetadata> metaDatas = stageCreateDirectorys(mapPackage, pathDir);
            stageValidateMetadata(mapPackage, metaDatas);
            stageCopyMetadata(pathFiles, pathDir, metaDatas);
            stageCopyPackageFinal(path, pathDir);

            Console.WriteLine(">> Finalize the process...");
        }

        private static void stageCopyPackageFinal(string path, string pathDir)
        {
            Console.WriteLine(">> Copying package...");            

            ManageCopy.doCopy(path.Replace("package.xml", ""), pathDir, "package.xml");            
        }

        private static void stageCopyMetadata(string pathFiles, string pathDir, List<IMetadata> metaDatas)
        {
            Console.WriteLine(">> Copying metadata...");
            foreach (IMetadata m_metadata in metaDatas)
            {
                m_metadata.doCopy(pathFiles, pathDir);
            }
        }

        private static void stageValidateMetadata(Dictionary<string, List<string>> mapPackage, List<IMetadata> metaDatas)
        {
            Console.WriteLine(">> Validating metadata...");

            foreach (var type in mapPackage)
            {
                foreach (var member in type.Value)
                {
                    foreach (IMetadata m_metadata in metaDatas)
                    {
                        m_metadata.isValidThenAdd(type.Key, member);
                    }
                }
            }
        }

        private static List<IMetadata> stageCreateDirectorys(Dictionary<string, List<string>> mapPackage, string pathDir)
        {
            Console.WriteLine(">> Creating directories...");

            ManageDirectory manageDirectory = new ManageDirectory();
            List<IMetadata> metaDatas = manageDirectory.buildDirectorys(mapPackage, pathDir);
            return metaDatas;
        }
                
    }


    
}
