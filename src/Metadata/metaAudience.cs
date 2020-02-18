using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaAudience:MetaBase {
        
		public metaAudience(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.Audience;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".audience"));
		}	

		public override void doMerge(){}
		
	}
	
}
