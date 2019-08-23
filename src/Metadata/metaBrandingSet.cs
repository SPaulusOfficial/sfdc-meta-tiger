using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class metaBrandingSet:MetaBase {        		

		public metaBrandingSet(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.BrandingSet;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".brandingSet");											
		}

		public override void doMerge(){}

	}
	
}
