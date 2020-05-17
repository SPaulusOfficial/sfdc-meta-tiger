using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.Xml.Config;

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
				String directoryPath = String.Concat(@"/",MetaDirectory.getDirectory(m_metaname));
				String directoryFilePath = String.Concat(sourcePath,directoryPath);
				String directoryTargetFilePath = String.Concat(targetPath,directoryPath);
				this.buildCopy(metaname,directoryFilePath,directoryTargetFilePath);								
			}			
		}

		public void doAddon(String sourcePath,String targetPath,Organization organization){			
			foreach(String metaname in m_list){
				String directoryPath = String.Concat(@"/",MetaDirectory.getDirectory(m_metaname));
				String directoryFilePath = String.Concat(sourcePath,directoryPath);
				String directoryTargetFilePath = String.Concat(targetPath,directoryPath);
				this.runAddon(metaname,directoryFilePath,directoryTargetFilePath,organization);								
			}			
		}

		public abstract void buildCopy(String metaname,String directoryFilePath,String directoryTargetFilePath);

		public abstract void doMerge();

		public virtual void runAddon(String metaname,String directoryPath,String directoryTargetFilePath,Organization organization){}

    }
		
}
