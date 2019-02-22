using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Salesforce_Package.Manage;

namespace Salesforce_Package.Metadata
{
    class MetaCustomObject:MetaBase {
        
		public MetaCustomObject(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.CustomObject;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".object"));				
		}

		public override void doMerge(){}
		
	}


	
}
