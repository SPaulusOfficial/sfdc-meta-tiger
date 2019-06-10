using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class MetaProfiles:MetaBase {        		

		public MetaProfiles(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.Profile;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".profile");											
		}

		public override void doMerge(){}

	}
	
}
