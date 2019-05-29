using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Salesforce_Package.Xml.Package;
using Salesforce_Package.Manage;

namespace Salesforce_Package.ManageXML
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

        public static void doWrite(Package myObject){			
			
            ManageDirectory.createPackageDirectory(Environment.CurrentDirectory+"\\Package");
            String targetPath = Environment.CurrentDirectory+"\\Package\\";
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
