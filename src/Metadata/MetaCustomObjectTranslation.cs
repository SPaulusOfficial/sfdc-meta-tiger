using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class MetaCustomObjectTranslation:MetaBase {        		

		public MetaCustomObjectTranslation(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.CustomObjectTranslation;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".objectTranslation");											
		}

		public override void doMerge(){}

	}
	
}
