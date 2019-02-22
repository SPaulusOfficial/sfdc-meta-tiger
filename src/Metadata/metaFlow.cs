using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Salesforce_Package.Manage;

namespace Salesforce_Package.Metadata{
    class MetaFlow:MetaBase {
        

		public MetaFlow(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.Flow;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".flow");
		}	
		
			public override void doMerge(){}
	}
	
}
