using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.Xml.Workflow;
using MetaTiger.ManageFileXML;

namespace MetaTiger.Metadata{
    class MetaWorkflowFieldUpdate:MetaWorkflowBase {
        
		Dictionary<string, List<FieldUpdates>> m_dictionaryObject;

		public MetaWorkflowFieldUpdate(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.WorkflowFieldUpdate;
			this.m_mapMetaObject = new Dictionary<String,String>();
			this.m_dictionaryObject = new Dictionary<string, List<FieldUpdates>>();
		} 
		
		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){			
			String pathDirectoryFileCustomObject = String.Concat(directoryPath,@"/",metaname,".workflow");
			this.buildMap(pathDirectoryFileCustomObject,this.m_list,this.m_metaname);									
			Workflow m_CustomObject_clean =  ManageXMLWorkflow.createNewObject();			
			m_CustomObject_clean.FieldUpdates = m_dictionaryObject[metaname];
			ManageXMLWorkflow.doWrite(m_CustomObject_clean,String.Concat(directoryTargetFilePath,@"/"),String.Concat(metaname,".workflow"));													
		}


		public Dictionary<string, List<FieldUpdates>> buildMap(String path,List<String> m_list,String metaname){         
				Workflow customObject = ManageXMLWorkflow.Deserialize(path);

				foreach(String Metafile in m_list){                
						String [] customMetaSplit = Metafile.Split("."); 
						String m_nameObject = customMetaSplit[0];
						String customInMeta = customMetaSplit[1];
						foreach(FieldUpdates Meta in customObject.FieldUpdates){                                                                                             
								if (!m_dictionaryObject.ContainsKey(m_nameObject)){                        
										m_dictionaryObject.Add(m_nameObject, new List<FieldUpdates>());
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
			foreach(KeyValuePair<string, List<FieldUpdates>> dictionaryObject in m_dictionaryObject)
			{
				ManageXMLWorkflowMerge m_merge = ManageXMLWorkflowMerge.getInstance();
				Workflow m_mergeObject = m_merge.getInstanceObject(dictionaryObject.Key);
				m_mergeObject.FieldUpdates = dictionaryObject.Value;
			}
			
		}
		
	}

}
