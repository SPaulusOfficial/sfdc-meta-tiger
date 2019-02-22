using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Salesforce_Package.Manage;

namespace Salesforce_Package.Metadata
{
    class MetaEmailTemplate:MetaBase {
        

		public MetaEmailTemplate(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.EmailTemplate;			
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			String [] findFolderEmail = metaname.Split("/");
			ManageDirectory.createPackageDirectory(directoryTargetFilePath+"\\"+findFolderEmail[0]);   				
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".email");				
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".email-meta.xml");		
		}

		public override void doMerge(){}
	}


	
}
