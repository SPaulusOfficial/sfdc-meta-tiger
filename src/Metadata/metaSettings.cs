using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class MetaSettings:MetaBase {
        

		public MetaSettings(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.Settings;			
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){			
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".settings");						
		}

			public override void doMerge(){}
	}


	
}
