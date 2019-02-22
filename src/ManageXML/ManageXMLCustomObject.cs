using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Salesforce_Package.Xml.CustomObject;

namespace Salesforce_Package.ManageXML
{
    class ManageXMLCustomObject {
                   
        public static CustomObject Deserialize(String path)
        {
            CustomObject customobject = null;
            
            XmlSerializer serializer = new XmlSerializer(typeof(CustomObject));
            
            using(StreamReader reader = new StreamReader(@path))
            {
                return customobject = (CustomObject)serializer.Deserialize(reader);
            }                       
        }

        public static CustomObject createNewObject(){
			return new CustomObject();
		}

        public static void doWrite(CustomObject myObject, String targetPath, String fileName){			
			try{
				 				                
                System.Xml.Serialization.XmlSerializer writer = 
                new System.Xml.Serialization.XmlSerializer(typeof(CustomObject));  
						
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
