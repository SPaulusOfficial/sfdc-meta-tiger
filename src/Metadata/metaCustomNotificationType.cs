using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class metaCustomNotificationType:MetaBase {        		

		public metaCustomNotificationType(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.CustomNotificationType;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".notiftype");											
		}

		public override void doMerge(){}

	}
	
}
