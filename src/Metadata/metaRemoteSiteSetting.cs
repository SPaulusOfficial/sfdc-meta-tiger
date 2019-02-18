﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Salesforce_Package.Manage;

namespace Salesforce_Package.Metadata
{
    class MetaRemoteSiteSetting : MetaBase {

		public MetaRemoteSiteSetting(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.RemoteSiteSetting;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".remoteSite");			
		}	
		
	}


	
}
