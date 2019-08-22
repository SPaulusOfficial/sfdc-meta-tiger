using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MetaTiger.Xml.Package;
using MetaTiger.ManageFile;

namespace MetaTiger.ManageFileXML
{
    class ManageXMLPackage{
                       
        public static Dictionary<string, List<string>> buildMap(String path){
            var mapPackage = new Dictionary<string, List<string>>();
            Package package = Deserialize(path);
            foreach(Types type in package.Types){
                if (!mapPackage.ContainsKey(type.Name)){
                    mapPackage.Add(type.Name, new List<String>());
                }
                foreach(String member in type.Members){
                    mapPackage[type.Name].Add(member.ToString());                          
                }                                         
            }
            return mapPackage;
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

        public static SFDC.Metadata.Package DeserializePackageApi(String path)
        {
            SFDC.Metadata.Package package = null;
            
            Dictionary<string, List<string>> m_dictionary = buildMap(path);

            package = new SFDC.Metadata.Package();

            List<SFDC.Metadata.PackageTypeMembers> lstPackageTypeMembers = new List<SFDC.Metadata.PackageTypeMembers>();

            foreach(String type in m_dictionary.Keys){
                SFDC.Metadata.PackageTypeMembers m_type = new SFDC.Metadata.PackageTypeMembers(){
                    name = type
                };
                lstPackageTypeMembers.Add(m_type);
            }

            package.types = lstPackageTypeMembers.ToArray();

            foreach(SFDC.Metadata.PackageTypeMembers packageTypeMember in package.types){
                String[] members = m_dictionary[packageTypeMember.name].ToArray();
                packageTypeMember.members = members;
            }
            
            return package;
        }

        public static void doWrite(Package myObject){			
			
            ManageFileDirectory.createPackageDirectory(Environment.CurrentDirectory+@"\Package");
            String targetPath = Environment.CurrentDirectory+@"\Package\";
            String fileName = "Package.xml";
            
            try{
				 				                
                System.Xml.Serialization.XmlSerializer writer = 
                new System.Xml.Serialization.XmlSerializer(typeof(Package));  
						
				System.IO.FileStream file = System.IO.File.Create(targetPath+fileName);  
                
				writer.Serialize(file, myObject);  
				file.Close();  
			}
			catch (Exception e)
			{			  
       		  Console.WriteLine("Could not create file:" + e.Message);
			}			
		}

	}


	
}
