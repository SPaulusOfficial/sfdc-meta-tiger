using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MetaTiger.Metadata{
    abstract class MetaBase: IMetadata {
        
		public List<String> m_list;    
		
		public String m_metaname;
		
    public void isValidThenAdd(String metaname,String MetaFile){
			if(m_metaname.Equals(metaname)){
				m_list.Add(MetaFile);
			}
		}

		public void doCopy(String sourcePath,String targetPath){			
			foreach(String metaname in m_list){
				String directoryPath = String.Concat("\\",MetaDirectory.getDirectory(m_metaname));
				String directoryFilePath = String.Concat(sourcePath,directoryPath);
				String directoryTargetFilePath = String.Concat(targetPath,directoryPath);
				this.buildCopy(metaname,directoryFilePath,directoryTargetFilePath);								
			}			
		}

		public abstract void buildCopy(String metaname,String directoryFilePath,String directoryTargetFilePath);

		public abstract void doMerge();

    }
		
}
