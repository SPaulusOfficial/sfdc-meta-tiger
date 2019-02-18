using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Salesforce_Package.Xml.Workflow;

namespace Salesforce_Package.ManageXML
{
    class ManageXMLWorkflow {
                       
        public static Workflow Deserialize(String path)
        {
            Workflow workflow = null;
            
            XmlSerializer serializer = new XmlSerializer(typeof(Workflow));
            
            using(StreamReader reader = new StreamReader(@path))
            {
                return workflow = (Workflow)serializer.Deserialize(reader);
            }                       
        }

        public static Workflow creteNewObject(){
			return new Workflow();
		}

        public static void doWrite(Workflow myObject, String targetPath, String fileName){			
			try{
				 				                
                System.Xml.Serialization.XmlSerializer writer = 
                new System.Xml.Serialization.XmlSerializer(typeof(Workflow));  
						
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
