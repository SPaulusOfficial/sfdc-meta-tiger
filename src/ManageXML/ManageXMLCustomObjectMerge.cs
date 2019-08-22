using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MetaTiger.Xml.CustomObject;
using MetaTiger.ManageFile;

namespace MetaTiger.ManageFileXML
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

        public void defaultParameters(string sourcePath){
            String mergeDirectory = String.Concat(sourcePath,@"\",MetaDirectory.getDirectory(MetaConstants.CustomObject));
            foreach(KeyValuePair<string, CustomObject> m_object in m_customObjects)
            {    
              String filename = String.Concat(m_object.Key,".object");
              CustomObject customObject =  ManageXMLCustomObject.Deserialize(String.Concat(mergeDirectory,@"\",filename));
              m_object.Value.Label = customObject.Label;
              m_object.Value.PluralLabel = customObject.PluralLabel;
              m_object.Value.NameField = customObject.NameField;
              m_object.Value.Gender = customObject.Gender;
              m_object.Value.DeploymentStatus = customObject.DeploymentStatus;
              m_object.Value.DeploymentStatus = customObject.DeploymentStatus;
              m_object.Value.SharingModel = customObject.SharingModel;
              m_object.Value.ExternalSharingModel = customObject.ExternalSharingModel;
              m_object.Value.CompactLayoutAssignment = customObject.CompactLayoutAssignment;
            }  
        }

        public void writeAllInstances(String targetPath){
            Boolean isHaveObjectInPackageXml = m_customObjects.Count>0;
            
            if(isHaveObjectInPackageXml){
                String mergeDirectory = String.Concat(targetPath,@"\","_",MetaDirectory.getDirectory(MetaConstants.CustomObject));
                ManageFileDirectory.createPackageDirectory(mergeDirectory);
                foreach(KeyValuePair<string, CustomObject> m_object in m_customObjects)
                {
                    String filename = String.Concat(m_object.Key,".object");
                    ManageXMLCustomObject.doWrite(m_object.Value,String.Concat(mergeDirectory,@"\"),filename);
                } 
            }
        }
    }	
}
