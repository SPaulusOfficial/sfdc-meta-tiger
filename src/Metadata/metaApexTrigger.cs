using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Salesforce_Package.Manage;

namespace Salesforce_Package.Metadata{
    class MetaApexTrigger : MetaBase {

		public MetaApexTrigger(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.ApexTrigger;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".trigger"));
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".trigger-meta.xml"));
		}	

		public override void doMerge(){}
		
	}
	
}
