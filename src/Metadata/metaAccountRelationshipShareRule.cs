﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaAccountRelationshipShareRule:MetaBase {
        

		public metaAccountRelationshipShareRule(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.AccountRelationshipShareRule;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".accountRelationshipShareRules"));
		}	

		public override void doMerge(){}
		
	}
	
}
