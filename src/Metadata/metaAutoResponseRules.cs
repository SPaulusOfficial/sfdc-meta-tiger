using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaAutoResponseRules : MetaBase {

		public metaAutoResponseRules(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.AutoResponseRules;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".autoResponseRules"));
		}	

		public override void doMerge(){}
		
	}

}
