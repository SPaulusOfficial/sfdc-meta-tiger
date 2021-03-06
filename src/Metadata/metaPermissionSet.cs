﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class MetaPermissionSet:MetaBase {
        
		public MetaPermissionSet(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.PermissionSet;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".permissionset");				
		}

		public override void doMerge(){}
		
	}


	
}
