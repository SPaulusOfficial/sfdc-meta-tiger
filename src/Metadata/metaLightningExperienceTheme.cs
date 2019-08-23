using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class metaLightningExperienceTheme:MetaBase {        		

		public metaLightningExperienceTheme(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.LightningExperienceTheme;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".lightningExperienceTheme");											
		}

		public override void doMerge(){}

	}
	
}
