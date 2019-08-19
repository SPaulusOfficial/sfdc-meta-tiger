using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class MetaAppMenu : MetaBase {

		public MetaAppMenu(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.AppMenu;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".appMenu"));
		}	

		public override void doMerge(){}
		
	}

}
