using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaQuickAction:MetaBase {
        

		public metaQuickAction(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.QuickAction;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".quickAction"));
		}	

		public override void doMerge(){}
		
	}
	
}
