using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Salesforce_Package.Metadata{
    abstract class metaBase: IMetadata {
        
		public List<String> m_list;    
		
		public String m_metaName;
		
        public void isValidThenAdd(String metaName,String metaFile){
			if(m_metaName.Equals(metaName)){
				m_list.Add(metaFile);
			}
		}

		public void doCopy(String sourcePath,String targetPath){			
			foreach(String metaname in m_list){
				String directoryPath = "\\"+DirectoryContants.renameDirectoryMetaData(m_metaName);
				String directoryFilePath = (sourcePath+directoryPath);
				String directoryTargetFilePath = (targetPath+directoryPath);
				this.buildCopy(metaname,directoryFilePath,directoryTargetFilePath);								
			}			
		}

		public abstract void buildCopy(String metaname,String directoryFilePath,String directoryTargetFilePath);


    }
		
}
