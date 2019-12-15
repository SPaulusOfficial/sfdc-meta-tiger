using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MetaTiger.Xml.Config;
using MetaTiger.ManageFile;

namespace MetaTiger.ManageFileXML
{
    class ManageXMLConfig{

        public Config config;

        public ManageXMLConfig(){
            config = Deserialize();
        }

        public static Config Deserialize()
        {
            String path = Environment.CurrentDirectory+@"/config/config.xml";

            Config m_config = new Config();
            m_config.PackageManifest = new List<PackageManifest>();
            m_config.GeneralDirectoryTarget = @"C:/package";
            
            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            try
            {
                using(StreamReader reader = new StreamReader(@path))
                {
                    m_config = (Config)serializer.Deserialize(reader);
                }
            }
            catch (System.Exception)
            {
                doWrite(m_config);
                return m_config;
            }

            return m_config;
        }

        public static void doWrite(Config myObject){			
			
            ManageFileDirectory.createPackageDirectory(Environment.CurrentDirectory+@"/config");
            String targetPath = Environment.CurrentDirectory+@"/config/";
            String fileName = "config.xml";
            
            try{
				 				                
                System.Xml.Serialization.XmlSerializer writer = 
                new System.Xml.Serialization.XmlSerializer(typeof(Config));  
						
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
