﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Salesforce_Package
{
    class metaEmailTemplate:metaBase {
        
		public metaEmailTemplate(){
			this.m_list = new List<String>();
			this.m_metaName = DirectoryContants.EmailTemplate;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			String [] findFolderEmail = metaname.Split("/");
			ManageDirectory.cretePackageDirectory(directoryTargetFilePath+"\\"+findFolderEmail[0]);   				
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".email");				
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".email-meta.xml");		
		}
	}


	
}
