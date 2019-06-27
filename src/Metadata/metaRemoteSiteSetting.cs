using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class MetaRemoteSiteSetting : MetaBase {

		public MetaRemoteSiteSetting(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.RemoteSiteSetting;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".remoteSite");			
		}	

			public override void doMerge(){}
		
	}


	
}
