using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Salesforce_Package
{
    class metaProfiles:metaBase {        		

		public metaProfiles(){
			this.m_list = new List<String>();
			this.m_metaName = DirectoryContants.Profile;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".profile");											
		}

	}

	
}
