using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Salesforce_Package.Xml.CustomObject;
using Salesforce_Package.ManageXML;

namespace Salesforce_Package.Metadata{
    class MetaCustomField:MetaCustomObjectBase {
        
		public MetaCustomField(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.CustomField;
			this.m_mapMetaObject = new Dictionary<String,String>();
		} 
		
		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){			
			String pathDirectoryFileCustomObject = String.Concat(directoryPath,"\\",metaname,".object");
			Dictionary<string, List<Fields>> dictionaryFields = this.buildMap(pathDirectoryFileCustomObject,this.m_list,this.m_metaname);									
			CustomObject m_CustomObject_clean =  ManageXMLCustomObject.creteNewObject();			
			m_CustomObject_clean.Fields = dictionaryFields[metaname];
			ManageXMLCustomObject.doWrite(m_CustomObject_clean,String.Concat(directoryTargetFilePath,"\\"),String.Concat(metaname,".object"));													
		}

		public Dictionary<string, List<Fields>> buildMap(String path,List<String> m_list,String metaname){         
				Dictionary<string, List<Fields>> mapCustomMeta = new Dictionary<string, List<Fields>>();
				CustomObject customObject = ManageXMLCustomObject.Deserialize(path);

				foreach(String Metafile in m_list){                
						String [] customMetaSplit = Metafile.Split("."); 
						String m_nameObject = customMetaSplit[0];
						String customInMeta = customMetaSplit[1];
						foreach(Fields Meta in customObject.Fields){                                                                                             
								if (!mapCustomMeta.ContainsKey(m_nameObject)){                        
										mapCustomMeta.Add(m_nameObject, new List<Fields>());
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
