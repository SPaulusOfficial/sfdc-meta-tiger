﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.Xml.Workflow;
using MetaTiger.ManageFileXML;

namespace MetaTiger.Metadata{
    class MetaWorkflowTask:MetaWorkflowBase {
        
		Dictionary<string, List<Tasks>> m_dictionaryObject;

		public MetaWorkflowTask(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.WorkflowTask;
			this.m_mapMetaObject = new Dictionary<String,String>();
			this.m_dictionaryObject = new Dictionary<string, List<Tasks>>();
		} 
		
		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){			
			String pathDirectoryFileCustomObject = String.Concat(directoryPath,@"/",metaname,".workflow");
			this.buildMap(pathDirectoryFileCustomObject,this.m_list,this.m_metaname);									
			Workflow m_CustomObject_clean =  ManageXMLWorkflow.createNewObject();			
			m_CustomObject_clean.Tasks = m_dictionaryObject[metaname];
			ManageXMLWorkflow.doWrite(m_CustomObject_clean,String.Concat(directoryTargetFilePath,@"/"),String.Concat(metaname,".workflow"));													
		}


		public Dictionary<string, List<Tasks>> buildMap(String path,List<String> m_list,String metaname){         
				Workflow customObject = ManageXMLWorkflow.Deserialize(path);

				foreach(String Metafile in m_list){                
						String [] customMetaSplit = Metafile.Split("."); 
						String m_nameObject = customMetaSplit[0];
						String customInMeta = customMetaSplit[1];
						foreach(Tasks Meta in customObject.Tasks){                                                                                             
								if (!m_dictionaryObject.ContainsKey(m_nameObject)){                        
										m_dictionaryObject.Add(m_nameObject, new List<Tasks>());
								}           
								if(Meta.FullName==customInMeta){
									m_dictionaryObject[m_nameObject].Add(Meta);                                       
								}                      
						}
				} 

				if(m_dictionaryObject.Count==0){
						throw new Exception("Erro não foi encontrado nenhum valor");
				}

				return m_dictionaryObject;
		}

		public override void doMerge(){
			foreach(KeyValuePair<string, List<Tasks>> dictionaryObject in m_dictionaryObject)
			{
				ManageXMLWorkflowMerge m_merge = ManageXMLWorkflowMerge.getInstance();
				Workflow m_mergeObject = m_merge.getInstanceObject(dictionaryObject.Key);
				m_mergeObject.Tasks = dictionaryObject.Value;
			}
			
		}
		
	}

}
