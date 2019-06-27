using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class MetaCustomTab:MetaBase {        		

		public MetaCustomTab(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.CustomTab;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".tab");											
		}

		public override void doMerge(){}

	}
	
}
