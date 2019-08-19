using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaSharingRules : MetaBase {

		public metaSharingRules(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.SharingRules;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".sharingRules"));
		}	

		public override void doMerge(){}
		
	}

}
