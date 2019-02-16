using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Salesforce_Package.Metadata{
    class metaFlow:metaBase {
        

		public metaFlow(){
			this.m_list = new List<String>();
			this.m_metaName = DirectoryContants.Flow;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".flow");
		}	
		
	}
	
}
