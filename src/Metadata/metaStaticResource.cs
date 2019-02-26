using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Salesforce_Package.Manage;

namespace Salesforce_Package.Metadata
{
    class MetaStaticResource:MetaBase {
        

		public MetaStaticResource(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.StaticResource;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".resource");			
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".resource-meta.xml");			
		}	

		public override void doMerge(){}
		
	}


	
}
