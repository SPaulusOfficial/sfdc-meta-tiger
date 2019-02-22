using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Salesforce_Package.Manage;

namespace Salesforce_Package.Metadata
{
    class MetaMilestoneType:MetaBase {
        
		public MetaMilestoneType(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.MilestoneType;
		} 
		
		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".milestoneType"));				
		}

		public override void doMerge(){}
	}


	
}
