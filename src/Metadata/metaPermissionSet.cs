using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Salesforce_Package.Manage;

namespace Salesforce_Package.Metadata
{
    class MetaPermissionSet:MetaBase {
        
		public MetaPermissionSet(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.PermissionSet;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".permissionset");				
		}
		
	}


	
}
