using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaContentAsset : MetaBase {

		public metaContentAsset(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.ContentAsset;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".asset"));
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".asset-meta.xml"));
		}	

		public override void doMerge(){}
		
	}

}
