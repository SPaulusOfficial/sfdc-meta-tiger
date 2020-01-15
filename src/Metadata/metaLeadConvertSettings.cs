using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaLeadConvertSettings:MetaBase {
        

		public metaLeadConvertSettings(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.LeadConvertSettings;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".LeadConvertSetting"));
		}	

		public override void doMerge(){}
		
	}
	
}
