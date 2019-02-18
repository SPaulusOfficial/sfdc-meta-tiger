using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Salesforce_Package.Manage;

namespace Salesforce_Package.Metadata
{
    class MetaWorkflow:MetaBase {
        
		public MetaWorkflow(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.Workflow;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".workflow"));				
		}
		
	}


	
}
