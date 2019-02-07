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
            Package package = Deserialize(path);
            foreach(Types type in package.Types){
                if (!mapPackage.ContainsKey(type.Name)){
                    mapPackage.Add(type.Name, new List<String>());
                }
                foreach(String member in type.Members){
                    mapPackage[type.Name].Add(member.ToString());                          
                }                                         
            }

            //Pesquisando diretorio da local
            //string pathDir =System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            
            //Mudar para um caminho mais fácil da aplicação
            String pathDir = "C:\\";            
            pathDir = pathDir + "\\package";
            //Começar a criar os pastas do package
            Console.WriteLine(">> Criando diretórios..."); 
            
            ManageDirectory.cretePackageDirectory(pathDir);           
            foreach (var type in mapPackage){
              String tempDirectory = pathDir + "\\"+ DirectoryContants.renameDirectoryMetaData(type.Key);
              ManageDirectory.cretePackageDirectory(tempDirectory);              
            }

            metaApexClass classes = new metaApexClass();
            metaPermissionSet permissionSets = new metaPermissionSet();
            metaCustomMetadata customMetadata = new metaCustomMetadata();
            metaCustomObject customObject = new metaCustomObject();
            metaEmailTemplate emailTemplate = new metaEmailTemplate();
            metaLayout layouts = new metaLayout();
            metaApexPage pages = new metaApexPage();
            metaProfiles profiles = new metaProfiles();
            metaStaticResource staticresource = new metaStaticResource();

            List<IMetadata> metaDatas= new List<IMetadata>{classes,permissionSets,customMetadata,customObject,emailTemplate,
            layouts,pages,profiles,staticresource};

            Console.WriteLine(">> Copiando arquivos...");             

            foreach(var type in mapPackage){
                foreach(var member in type.Value){
                    foreach(IMetadata m_metadata in metaDatas){
                        m_metadata.isValidThenAdd(type.Key,member);
                    }                  
                }
            }
            
            foreach(IMetadata m_metadata in metaDatas){
                m_metadata.doCopy(pathFiles,pathDir);
            }    
         
            Console.WriteLine(path);
            Console.WriteLine(pathDir);
            ManageCopy.doCopy(path.Replace("package.xml",""),pathDir,"package.xml");


        }

        public static Package Deserialize(String path)
        {
            Package package = null;
            
            XmlSerializer serializer = new XmlSerializer(typeof(Package));
            
            using(StreamReader reader = new StreamReader(@path))
            {
                package = (Package)serializer.Deserialize(reader);
            }
            
            return package;
        }
    }

    
}
