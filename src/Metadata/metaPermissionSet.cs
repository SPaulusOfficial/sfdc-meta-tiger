using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Salesforce_Package.Metadata
{
    class metaPermissionSet:metaBase {
        
		public metaPermissionSet(){
			this.m_list = new List<String>();
			this.m_metaName = DirectoryContants.PermissionSet;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".permissionset");				
		}
		
	}


	
}
