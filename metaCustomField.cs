using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Salesforce_Package.XML;

namespace Salesforce_Package
{
    class metaCustomField:metaBase,IMetadata {
        
		String m_metaObject;
		Dictionary<String,String> m_mapMetaObject;

		public metaCustomField(){
			this.m_list = new List<String>();
			this.m_metaName = DirectoryContants.CustomField;
			this.m_metaObject = DirectoryContants.CustomObject;
			this.m_mapMetaObject = new Dictionary<String,String>();
		} 

		//Override methods
		void IMetadata.isValidThenAdd(String metaName,String metaFile) 
		{ 
			this.isValidThenAdd(metaName,metaFile); 
		} 

		void IMetadata.doCopy(String sourcePath,String targetPath){			
			this.doCopy(sourcePath,targetPath);
		}

		public new void isValidThenAdd(String metaName,String metaFile){
			if(m_metaName.Equals(metaName)){
				this.m_list.Add(metaFile);
				String [] customFieldSplit = metaFile.Split("."); 
				String metaObject = customFieldSplit[0];
				if (!m_mapMetaObject.ContainsKey(metaObject)){
                    m_mapMetaObject.Add(metaObject, metaObject);
                }
			}
		}
		//End Override methods

		public new void doCopy(String sourcePath,String targetPath){
			String directoryPath = "\\"+DirectoryContants.renameDirectoryMetaData(m_metaObject);
			String directoryPathCustomField = "\\"+DirectoryContants.renameDirectoryMetaData(this.m_metaName);
			String directoryFilePath = (sourcePath+directoryPath);
			String directoryTargetFilePath = (targetPath+directoryPathCustomField);						
			foreach(KeyValuePair<string, string> m_object in m_mapMetaObject){
				this.buildCopy(m_object.Key,directoryFilePath,directoryTargetFilePath);
			}
		}

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){			
			Dictionary<string, List<Fields>> dictionaryFields = ManageXMLCustomField.buildMap(directoryPath+"\\"+metaname+".object",this.m_list);									
			CustomObject m_CustomObject_clean =  ManageXMLCustomField.creteNewObject();			
			m_CustomObject_clean.Fields = dictionaryFields[metaname];
			ManageXMLCustomField.doWrite(m_CustomObject_clean,directoryTargetFilePath+"\\",metaname+".object");													
		}
		
	}


	
}
