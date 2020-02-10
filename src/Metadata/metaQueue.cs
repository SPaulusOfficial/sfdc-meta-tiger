using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class MetaQueue:MetaBase {
        

		public MetaQueue(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.Queue;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".queue");
		}	
		
			public override void doMerge(){}
	}
	
}
