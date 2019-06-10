using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class MetaFlowDefinition:MetaBase {
        

		public MetaFlowDefinition(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.FlowDefinition;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".flowDefinition");
		}	

			public override void doMerge(){}
		
	}
	
}
