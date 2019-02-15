﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Salesforce_Package.Metadata{
    class metaApexComponent : metaBase {

		public metaApexComponent(){
			this.m_list = new List<String>();
			this.m_metaName = DirectoryContants.ApexComponent;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".component");
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".component-meta.xml");
		}	
		
	}
	
}