using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Salesforce_Package
{
    class metaStaticResource:metaBase {
        

		public metaStaticResource(){
			this.m_list = new List<String>();
			this.m_metaName = DirectoryContants.StaticResource;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".resource");			
		}	
		
	}


	
}
