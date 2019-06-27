using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaFlexiPage : MetaBase {

		public metaFlexiPage(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.FlexiPage;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".flexipage"));
		}	

		public override void doMerge(){}
		
	}

}
