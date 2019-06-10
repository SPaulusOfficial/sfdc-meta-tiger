using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class MetaStaticResource:MetaBase {
        

		public MetaStaticResource(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.StaticResource;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".resource");			
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".resource-meta.xml");			
		}	

		public override void doMerge(){}
		
	}


	
}
