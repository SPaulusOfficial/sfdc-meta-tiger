using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaPathAssistant:MetaBase {
        

		public metaPathAssistant(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.PathAssistant;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".pathAssistant"));
		}	

		public override void doMerge(){}
		
	}
	
}
