using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class MetaWorkflow:MetaBase {
        
		public MetaWorkflow(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.Workflow;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".workflow"));				
		}

		public override void doMerge(){}
		
	}


	
}
