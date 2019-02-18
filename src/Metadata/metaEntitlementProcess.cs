using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Salesforce_Package.Manage;

namespace Salesforce_Package.Metadata
{
    class MetaEntitlementProcess:MetaBase {
        
		public MetaEntitlementProcess(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.EntitlementProcess;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".entitlementProcess");				
		}
		
	}


	
}
