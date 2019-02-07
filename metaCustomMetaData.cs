using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Salesforce_Package
{
    class metaCustomMetadata:metaBase {
        
		public metaCustomMetadata(){
			this.m_list = new List<String>();
			this.m_metaName = DirectoryContants.CustomMetadata;
		} 
		
		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".md");				
		}
	}


	
}
