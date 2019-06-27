using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class MetaCustomMetadata:MetaBase {
        
		public MetaCustomMetadata(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.CustomMetadata;
		} 
		
		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".md"));				
		}

		public override void doMerge(){}
	
	}



}
