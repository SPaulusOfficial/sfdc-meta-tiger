using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.Xml.Workflow;
using MetaTiger.ManageFileXML;

namespace MetaTiger.Metadata{
    class MetaWorkflowRule:MetaWorkflowBase {
        
		public MetaWorkflowRule(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.WorkflowRule;
			this.m_mapMetaObject = new Dictionary<String,String>();
		} 
		
		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){			
			String pathDirectoryFileCustomObject = String.Concat(directoryPath,@"\",metaname,".workflow");
			Dictionary<string, List<Rules>> dictionaryMeta = this.buildMap(pathDirectoryFileCustomObject,this.m_list,this.m_metaname);									
			Workflow m_CustomObject_clean =  ManageXMLWorkflow.createNewObject();			
			m_CustomObject_clean.Rules = dictionaryMeta[metaname];
			ManageXMLWorkflow.doWrite(m_CustomObject_clean,String.Concat(directoryTargetFilePath,@"\"),String.Concat(metaname,".workflow"));													
		}

		public Dictionary<string, List<Rules>> buildMap(String path,List<String> m_list,String metaname){         
				Dictionary<string, List<Rules>> mapCustomMeta = new Dictionary<string, List<Rules>>();
				Workflow customObject = ManageXMLWorkflow.Deserialize(path);

				foreach(String Metafile in m_list){                
						String [] customMetaSplit = Metafile.Split("."); 
						String m_nameObject = customMetaSplit[0];
						String customInMeta = customMetaSplit[1];
						foreach(Rules Meta in customObject.Rules){                                                                                             
								if (!mapCustomMeta.ContainsKey(m_nameObject)){                        
										mapCustomMeta.Add(m_nameObject, new List<Rules>());
								}           
								if(Meta.FullName==customInMeta){
									mapCustomMeta[m_nameObject].Add(Meta);                                       
								}                      
						}
				} 

				if(mapCustomMeta.Count==0){
						throw new Exception("Erro não foi encontrado nenhum valor");
				}

				return mapCustomMeta;
		}

			public override void doMerge(){}
		
	}

}
