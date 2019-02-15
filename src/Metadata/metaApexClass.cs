using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Salesforce_Package.Metadata{
    class metaApexClass : metaBase {

		public metaApexClass(){
			this.m_list = new List<String>();
			this.m_metaName = DirectoryContants.ApexClass;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".cls");
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".cls-meta.xml");
		}	
		
	}

}
