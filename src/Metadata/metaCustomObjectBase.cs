using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Salesforce_Package.Metadata
{
    abstract class metaCustomObjectBase:metaBase,IMetadata {
    
			public String m_metaObject = DirectoryContants.CustomObject;
			public Dictionary<String,String> m_mapMetaObject;

			//Override methods
			void IMetadata.isValidThenAdd(String metaName,String metaFile) 
			{ 
				this.isValidThenAdd(metaName,metaFile); 
			} 

			void IMetadata.doCopy(String sourcePath,String targetPath){			
				this.doCopy(sourcePath,targetPath);
			}
			//End Override methods

			public new void isValidThenAdd(String metaName,String metaFile){
				if(m_metaName.Equals(metaName)){
					this.m_list.Add(metaFile);
					String [] customMetaSplit = metaFile.Split("."); 
					String metaObject = customMetaSplit[0];
					if (!m_mapMetaObject.ContainsKey(metaObject)){
							m_mapMetaObject.Add(metaObject, metaObject);
					}
				}
			}

			public new void doCopy(String sourcePath,String targetPath){
				String directoryPath = "\\"+DirectoryContants.renameDirectoryMetaData(m_metaObject);
				String directoryPathMetaField = "\\"+DirectoryContants.renameDirectoryMetaData(this.m_metaName);
				String directoryFilePath = (sourcePath+directoryPath);
				String directoryTargetFilePath = (targetPath+directoryPathMetaField);						
				foreach(KeyValuePair<string, string> m_object in m_mapMetaObject){
					this.buildCopy(m_object.Key,directoryFilePath,directoryTargetFilePath);
				}
			}
		
	}


	
}
