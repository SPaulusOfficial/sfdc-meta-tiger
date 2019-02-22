using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Salesforce_Package.Xml.CustomObject;
using Salesforce_Package.Manage;

namespace Salesforce_Package.ManageXML
{
    public class ManageXMLCustomObjectMerge 
    {
        private static ManageXMLCustomObjectMerge instance;
        private Dictionary<String,CustomObject> m_customObjects;
 
        private ManageXMLCustomObjectMerge() { 
            this.m_customObjects = new Dictionary<String,CustomObject>();
        }
 
        public static ManageXMLCustomObjectMerge getInstance()
        {
            if (instance == null)
                lock (typeof(ManageXMLCustomObjectMerge))
                    if (instance == null) instance = new ManageXMLCustomObjectMerge();

            return instance;
        }
        
        public CustomObject getInstanceObject(String metaObject){
           if (!m_customObjects.ContainsKey(metaObject)){
                m_customObjects.Add(metaObject, new CustomObject());
            }
            return m_customObjects[metaObject];
        }

        public void writeAllInstances(String targetPath){
            String mergeDirectory = String.Concat(targetPath,"\\","_",MetaDirectory.getDirectory(MetaConstants.CustomObject));
            ManageDirectory.createPackageDirectory(mergeDirectory);
            foreach(KeyValuePair<string, CustomObject> m_object in m_customObjects)
            {
                String filename = String.Concat(m_object.Key,".object");
                ManageXMLCustomObject.doWrite(m_object.Value,String.Concat(mergeDirectory,"\\"),filename);
            } 
        }
    }	
}
