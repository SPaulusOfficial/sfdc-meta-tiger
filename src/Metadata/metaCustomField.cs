using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.Xml.CustomObject;
using MetaTiger.ManageFileXML;

namespace MetaTiger.Metadata{
    class MetaCustomField:MetaCustomObjectBase {

		Dictionary<string, List<Fields>> m_dictionaryObject;
        
		public MetaCustomField(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.CustomField;
			this.m_mapMetaObject = new Dictionary<String,String>();
			this.m_dictionaryObject = new Dictionary<string, List<Fields>>();
		} 
		
		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){			
			String pathDirectoryFileCustomObject = String.Concat(directoryPath,@"/",metaname,".object");
			this.buildMap(pathDirectoryFileCustomObject,this.m_list,this.m_metaname);	
			CustomObject m_CustomObject_clean =  ManageXMLCustomObject.createNewObject();										
			m_CustomObject_clean.Fields = m_dictionaryObject[metaname];
			ManageXMLCustomObject.doWrite(m_CustomObject_clean,String.Concat(directoryTargetFilePath,@"/"),String.Concat(metaname,".object"));
		}

		public void buildMap(String path,List<String> m_list,String metaname){         
				CustomObject customObject = ManageXMLCustomObject.Deserialize(path);

				foreach(String Metafile in m_list){                
						String [] customMetaSplit = Metafile.Split("."); 
						String m_nameObject = customMetaSplit[0];
						String customInMeta = customMetaSplit[1];
						foreach(Fields Meta in customObject.Fields){                                                                                             
								if (!m_dictionaryObject.ContainsKey(m_nameObject)){                        
										m_dictionaryObject.Add(m_nameObject, new List<Fields>());
								}           
								if(Meta.FullName==customInMeta){
									m_dictionaryObject[m_nameObject].Add(Meta);                                       
								}                      
						}
				} 

				if(m_dictionaryObject.Count==0){
						throw new Exception("Erro não foi encontrado nenhum valor");
				}

		}
		
		public override void doMerge(){
			foreach(KeyValuePair<string, List<Fields>> dictionaryObject in m_dictionaryObject)
			{
				 ManageXMLCustomObjectMerge m_merge = ManageXMLCustomObjectMerge.getInstance();
				 CustomObject m_mergeObject = m_merge.getInstanceObject(dictionaryObject.Key);
				 m_mergeObject.Fields = dictionaryObject.Value;
			}
		}


	}

}
