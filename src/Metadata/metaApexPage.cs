using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Salesforce_Package.Metadata{
    class metaApexPage:metaBase {
        

		public metaApexPage(){
			this.m_list = new List<String>();
			this.m_metaName = DirectoryContants.ApexPage;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".page");
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".page-meta.xml");
		}	
		
	}
	
}
