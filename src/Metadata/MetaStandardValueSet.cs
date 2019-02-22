using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Salesforce_Package.Manage;

namespace Salesforce_Package.Metadata
{
    class MetaStandardValueSet:MetaBase {
        
		public MetaStandardValueSet(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.StandardValueSet;
		} 
		
		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".standardValueSet"));				
		}

		public override void doMerge(){}
	}


	
}
