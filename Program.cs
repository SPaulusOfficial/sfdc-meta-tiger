using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Salesforce_Package
{
    class Program
    {
        static void Main(string[] args)
        {
            var mapPackage = new Dictionary<string, List<string>>();
            Console.WriteLine("########################");
            Console.WriteLine("#####PACKAGE MANIFEST#######");
            Console.WriteLine("########################");

            Console.WriteLine(">>> Please enter the path of the Package.xml path");
            //EXEMPLO: C:\Users\B111925\Documents\workspace\DEV05\package.xml
            String path = Console.ReadLine();

            Console.WriteLine(">>> Please enter the path of the repository where the files are:");
            //EXEMPLO: C:\CI
            String pathFiles = Console.ReadLine();

            //Deserializando XML encontrado
            mapPackage = ManageXMLPackage.buildMap(path);

            //Mudar para um caminho mais fácil da aplicação
            String pathDir = "C:\\";
            pathDir = pathDir + "\\package";
            //Começar a criar os pastas do package
            Console.WriteLine(">> Criando diretórios...");

            ManageDirectory manageDirectory = new ManageDirectory();
            List<IMetadata> metaDatas = manageDirectory.buildDirectorys(mapPackage, pathDir);
            
            Console.WriteLine(">> Copiando arquivos...");

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

            foreach (IMetadata m_metadata in metaDatas)
            {
                m_metadata.doCopy(pathFiles, pathDir);
            }
        
            ManageCopy.doCopy(path.Replace("package.xml", ""), pathDir, "package.xml");

        }
                
    }

    
}
