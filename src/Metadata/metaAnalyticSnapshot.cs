using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaAnalyticSnapshot:MetaBase {
        

		public metaAnalyticSnapshot(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.AnalyticSnapshot;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".analyticsnapshot"));
		}	

		public override void doMerge(){}
		
	}
	
}
