using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class MetaCustomPageWebLink:MetaBase {
        
		public MetaCustomPageWebLink(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.CustomPageWebLink;
		} 
		
		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".weblink"));				
		}

		public override void doMerge(){}
	}

	
	
}
