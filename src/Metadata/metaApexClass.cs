using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Salesforce_Package.Manage;

namespace Salesforce_Package.Metadata{
    class MetaApexClass : MetaBase {

		public MetaApexClass(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.ApexClass;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".cls"));
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".cls-meta.xml"));
		}	

		public override void doMerge(){}
		
	}

}
