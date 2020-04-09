using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.Xml.CustomObject;
using MetaTiger.ManageFileXML;

namespace MetaTiger.Metadata{
    class metaWebLink:MetaCustomObjectBase {

		Dictionary<string, List<WebLink>> m_dictionaryObject;

		public metaWebLink(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.WebLink;
			this.m_mapMetaObject = new Dictionary<String,String>();
			this.m_dictionaryObject = new Dictionary<string, List<WebLink>>();
		} 
		
		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){			
			this.buildMap(directoryPath+@"/"+metaname+".object",this.m_list,this.m_metaname);									
			CustomObject m_CustomObject_clean =  ManageXMLCustomObject.createNewObject();			
			m_CustomObject_clean.WebLinks = m_dictionaryObject[metaname];
			ManageXMLCustomObject.doWrite(m_CustomObject_clean,directoryTargetFilePath+@"/",metaname+".object");													
		}

		public void buildMap(String path,List<String> m_list,String metaname){         
				CustomObject customObject = ManageXMLCustomObject.Deserialize(path);

				foreach(String Metafile in m_list){                
						String [] customMetaSplit = Metafile.Split("."); 
						String m_nameObject = customMetaSplit[0];
						String customInMeta = customMetaSplit[1];
						foreach(WebLink Meta in customObject.WebLinks){                                                                                             
								if (!m_dictionaryObject.ContainsKey(m_nameObject)){                        
										m_dictionaryObject.Add(m_nameObject, new List<WebLink>());
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
			foreach(KeyValuePair<string, List<WebLink>> dictionaryObject in m_dictionaryObject)
			{
				 ManageXMLCustomObjectMerge m_merge = ManageXMLCustomObjectMerge.getInstance();
				 CustomObject m_mergeObject = m_merge.getInstanceObject(dictionaryObject.Key);
				 m_mergeObject.WebLinks = dictionaryObject.Value;
			}
		}
		
	}

}
