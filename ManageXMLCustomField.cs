using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Salesforce_Package.XML;

namespace Salesforce_Package
{
    class ManageXMLCustomField {
                       
        public static Dictionary<string, List<Fields>> buildMap(String path,List<String> m_list){         
            Dictionary<string, List<Fields>> mapCustomField = new Dictionary<string, List<Fields>>();
            CustomObject customObject = Deserialize(path); 

            foreach(String metafile in m_list){                
                String [] customFieldSplit = metafile.Split("."); 
                String m_nameObject = customFieldSplit[0];
                String customField = customFieldSplit[1];
                foreach(Fields field in customObject.Fields){                                                                                             
                    if (!mapCustomField.ContainsKey(m_nameObject)){                        
                        mapCustomField.Add(m_nameObject, new List<Fields>());
                    }           
                    if(field.FullName==customField){
                      mapCustomField[m_nameObject].Add(field);                                       
                    }                      
                }
            } 

            if(mapCustomField.Count==0){
                throw new Exception("Erro não foi encontrado nenhum valor");
            }

            return mapCustomField;
        }

        public static CustomObject Deserialize(String path)
        {
            CustomObject customobject = null;
            
            XmlSerializer serializer = new XmlSerializer(typeof(CustomObject));
            
            using(StreamReader reader = new StreamReader(@path))
            {
                return customobject = (CustomObject)serializer.Deserialize(reader);
            }                       
        }

        public static CustomObject creteNewObject(){
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
