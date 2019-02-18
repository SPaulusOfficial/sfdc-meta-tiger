using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Salesforce_Package.Manage;

namespace Salesforce_Package.Metadata{
    class MetaApexPage:MetaBase {
        

		public MetaApexPage(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.ApexPage;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".page"));
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".page-meta.xml"));
		}	
		
	}
	
}
