using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class MetaWebLink:MetaBase {
        
		public MetaWebLink(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.WebLink;
		} 
		
		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".weblink"));				
		}

		public override void doMerge(){}
	}

	
	
}
