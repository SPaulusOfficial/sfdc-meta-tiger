using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Salesforce_Package.XML;

namespace Salesforce_Package.Metadata{
    class metaValidationRule:metaCustomObjectBase {
        
		public metaValidationRule(){
			this.m_list = new List<String>();
			this.m_metaName = DirectoryContants.ValidationRule;
			this.m_mapMetaObject = new Dictionary<String,String>();
		} 
		
		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){			
			Dictionary<string, List<ValidationRules>> dictionaryFields = this.buildMap(directoryPath+"\\"+metaname+".object",this.m_list,this.m_metaName);									
			CustomObject m_CustomObject_clean =  ManageXMLCustomObject.creteNewObject();			
			m_CustomObject_clean.ValidationRules = dictionaryFields[metaname];
			ManageXMLCustomObject.doWrite(m_CustomObject_clean,directoryTargetFilePath+"\\",metaname+".object");													
		}

		public Dictionary<string, List<ValidationRules>> buildMap(String path,List<String> m_list,String metaname){         
				Dictionary<string, List<ValidationRules>> mapCustomMeta = new Dictionary<string, List<ValidationRules>>();
				CustomObject customObject = ManageXMLCustomObject.Deserialize(path);

				foreach(String metafile in m_list){                
						String [] customMetaSplit = metafile.Split("."); 
						String m_nameObject = customMetaSplit[0];
						String customInMeta = customMetaSplit[1];
						foreach(ValidationRules meta in customObject.ValidationRules){                                                                                             
								if (!mapCustomMeta.ContainsKey(m_nameObject)){                        
										mapCustomMeta.Add(m_nameObject, new List<ValidationRules>());
								}           
								if(meta.FullName==customInMeta){
									mapCustomMeta[m_nameObject].Add(meta);                                       
								}                      
						}
				} 

				if(mapCustomMeta.Count==0){
						throw new Exception("Erro não foi encontrado nenhum valor");
				}

				return mapCustomMeta;
		}
		
	}

}
