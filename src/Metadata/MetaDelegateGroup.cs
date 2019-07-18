using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class MetaDelegateGroup : MetaBase {

		public MetaDelegateGroup(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.DelegateGroup;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".delegateGroup"));
		}	

		public override void doMerge(){}
		
	}

}
