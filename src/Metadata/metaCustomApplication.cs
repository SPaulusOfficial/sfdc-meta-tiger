using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaCustomApplication : MetaBase {

		public metaCustomApplication(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.CustomApplication;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".app"));
		}	

		public override void doMerge(){}
		
	}

}
