using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class MetaMilestoneType:MetaBase {
        
		public MetaMilestoneType(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.MilestoneType;
		} 
		
		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".milestoneType"));				
		}

		public override void doMerge(){}
	}


	
}
