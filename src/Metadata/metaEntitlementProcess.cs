using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class MetaEntitlementProcess:MetaBase {
        
		public MetaEntitlementProcess(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.EntitlementProcess;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".entitlementProcess");				
		}

		public override void doMerge(){}
		
	}


	
}
