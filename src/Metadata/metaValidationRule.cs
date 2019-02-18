using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Salesforce_Package.Xml.CustomObject;
using Salesforce_Package.ManageXML;

namespace Salesforce_Package.Metadata{
    class MetaValidationRule:MetaCustomObjectBase {
        
		public MetaValidationRule(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.ValidationRule;
			this.m_mapMetaObject = new Dictionary<String,String>();
		} 
		
		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){			
			Dictionary<string, List<ValidationRules>> dictionaryFields = this.buildMap(directoryPath+"\\"+metaname+".object",this.m_list,this.m_metaname);									
			CustomObject m_CustomObject_clean =  ManageXMLCustomObject.creteNewObject();			
			m_CustomObject_clean.ValidationRules = dictionaryFields[metaname];
			ManageXMLCustomObject.doWrite(m_CustomObject_clean,directoryTargetFilePath+"\\",metaname+".object");													
		}

		public Dictionary<string, List<ValidationRules>> buildMap(String path,List<String> m_list,String metaname){         
				Dictionary<string, List<ValidationRules>> mapCustomMeta = new Dictionary<string, List<ValidationRules>>();
				CustomObject customObject = ManageXMLCustomObject.Deserialize(path);

				foreach(String Metafile in m_list){                
						String [] customMetaSplit = Metafile.Split("."); 
						String m_nameObject = customMetaSplit[0];
						String customInMeta = customMetaSplit[1];
						foreach(ValidationRules Meta in customObject.ValidationRules){                                                                                             
								if (!mapCustomMeta.ContainsKey(m_nameObject)){                        
										mapCustomMeta.Add(m_nameObject, new List<ValidationRules>());
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
		
	}

}
