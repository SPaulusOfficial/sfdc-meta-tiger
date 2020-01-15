using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MetaTiger.Xml.Workflow;
using MetaTiger.ManageFile;

namespace MetaTiger.ManageFileXML
{
    public class ManageXMLWorkflowMerge 
    {
        private static ManageXMLWorkflowMerge instance;
        private Dictionary<String,Workflow> m_workflows;
 
        private ManageXMLWorkflowMerge() { 
            this.m_workflows = new Dictionary<String,Workflow>();
        }
 
        public static ManageXMLWorkflowMerge getInstance()
        {
            if (instance == null)
                lock (typeof(ManageXMLWorkflowMerge))
                    if (instance == null) instance = new ManageXMLWorkflowMerge();

            return instance;
        }
        
        public Workflow getInstanceObject(String metaWorkflow){
           if (!m_workflows.ContainsKey(metaWorkflow)){
                m_workflows.Add(metaWorkflow, new Workflow());
            }
            return m_workflows[metaWorkflow];
        }

        public void defaultParameters(string sourcePath){
            String mergeDirectory = String.Concat(sourcePath,@"/",MetaDirectory.getDirectory(MetaConstants.Workflow));
            foreach(KeyValuePair<string, Workflow> m_object in m_workflows)
            {    
              String filename = String.Concat(m_object.Key,".workflow");
              Workflow customObject =  ManageXMLWorkflow.Deserialize(String.Concat(mergeDirectory,@"/",filename));
              /*m_object.Value.Label = customObject.Label;
              m_object.Value.PluralLabel = customObject.PluralLabel;
              m_object.Value.NameField = customObject.NameField;
              m_object.Value.Gender = customObject.Gender;
              m_object.Value.DeploymentStatus = customObject.DeploymentStatus;
              m_object.Value.DeploymentStatus = customObject.DeploymentStatus;
              m_object.Value.SharingModel = customObject.SharingModel;
              m_object.Value.ExternalSharingModel = customObject.ExternalSharingModel;
              m_object.Value.CompactLayoutAssignment = customObject.CompactLayoutAssignment;*/
            }  
        }

        public void writeAllInstances(String targetPath){
            Boolean isHaveMetaInPackageXml = m_workflows.Count>0;
            String mergeDirectory;
            String directoryMain;
            if(isHaveMetaInPackageXml){

                mergeDirectory = String.Concat(targetPath,@"/","_",MetaDirectory.getDirectory(MetaConstants.Workflow));
                directoryMain = String.Concat(targetPath,@"/",MetaDirectory.getDirectory(MetaConstants.Workflow)); 

               
                foreach(KeyValuePair<string, Workflow> m_workflow in m_workflows)
                {
                    String directoryForObject = "";
                    

                    String filename = String.Concat(m_workflow.Key,".workflow");

                    if(ManageFileExists.verifyFileInDirectory(String.Concat(directoryMain,@"/",filename))){
                      directoryForObject = directoryMain;
                    }else{
                      directoryForObject = directoryMain;  
                    }

                     ManageFileDirectory.createPackageDirectory(directoryForObject);


                    ManageXMLWorkflow.doWrite(m_workflow.Value,String.Concat(directoryForObject,@"/"),filename);
                } 
            }
        }
    }	
}
