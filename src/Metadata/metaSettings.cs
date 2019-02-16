using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Salesforce_Package.Metadata
{
    class metaSettings:metaBase {
        

		public metaSettings(){
			this.m_list = new List<String>();
			this.m_metaName = DirectoryContants.Settings;			
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){			
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".settings");						
		}
	}


	
}
