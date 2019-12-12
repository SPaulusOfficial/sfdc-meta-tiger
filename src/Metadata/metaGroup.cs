using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class MetaGroup : MetaBase {

		public MetaGroup(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.Group;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".group"));
		}

		public override void doMerge(){}	
		
	}
	
}
