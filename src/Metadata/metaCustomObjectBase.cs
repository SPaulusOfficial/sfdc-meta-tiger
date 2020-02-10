using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.Helper;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    abstract class MetaCustomObjectBase:MetaBase,IMetadata {
    
			public String m_MetaObject = MetaConstants.CustomObject;
			public Dictionary<String,String> m_mapMetaObject;

			//Override methods
			void IMetadata.isValidThenAdd(String metaname,String MetaFile) 
			{ 
				this.isValidThenAdd(metaname,MetaFile); 
			} 

			void IMetadata.doCopy(String sourcePath,String targetPath){			
				this.doCopy(sourcePath,targetPath);
			}
			//End Override methods

			public new void isValidThenAdd(String metaname,String MetaFile){
				if(m_metaname.Equals(metaname)){
					this.m_list.Add(MetaFile);
					String [] customMetaSplit = MetaFile.Split("."); 
					String MetaObject = customMetaSplit[0];
					if (!m_mapMetaObject.ContainsKey(MetaObject)){
							m_mapMetaObject.Add(MetaObject, MetaObject);
					}
				}
			}

			public new void doCopy(String sourcePath,String targetPath){
				String objectPath = String.Concat(@"\",MetaDirectory.getDirectory(m_MetaObject));
				String directoryFilePath = String.Concat(sourcePath,objectPath);	
				String directoryPathMetaField = String.Concat(@"\",MetaDirectory.getDirectory(m_metaname));

				String directoryTargetObjectPath = String.Concat(targetPath,objectPath);
				String directoryTargetFilePath = String.Concat(targetPath,directoryPathMetaField);
				
				foreach(KeyValuePair<string, string> m_object in m_mapMetaObject){
					ManageFileCopy.doCopy(directoryFilePath,directoryTargetObjectPath,String.Concat(m_object.Key,".object"));
					this.buildCopy(m_object.Key,directoryFilePath,directoryTargetFilePath);
				}
			}

			public override void doMerge(){}
	}


	
}
