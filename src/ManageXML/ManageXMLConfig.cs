using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Salesforce_Package.Xml.Config;

namespace Salesforce_Package.ManageXML
{
    class ManageXMLConfig{

        public Config config;

        public ManageXMLConfig(){
            config = Deserialize();
        }

        public static Config Deserialize()
        {
            String path = Environment.CurrentDirectory+"\\Config\\config.xml";

            Config m_config = null;
            
            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            
            using(StreamReader reader = new StreamReader(@path))
            {
                m_config = (Config)serializer.Deserialize(reader);
            }
            
            return m_config;
        }
	}


	
}
