using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Salesforce_Package.Metadata{
    class metaApexTrigger : metaBase {

		public metaApexTrigger(){
			this.m_list = new List<String>();
			this.m_metaName = DirectoryContants.ApexTrigger;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".trigger");
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".trigger-meta.xml");
		}	
		
	}
	
}
