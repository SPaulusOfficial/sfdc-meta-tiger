using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaAuthProvider:MetaBase {
        
		public metaAuthProvider(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.AuthProvider;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".authprovider"));
		}	

		public override void doMerge(){}
		
	}
	
}
