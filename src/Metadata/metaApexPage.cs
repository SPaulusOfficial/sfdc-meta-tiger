using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class MetaApexPage:MetaBase {
        

		public MetaApexPage(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.ApexPage;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".page"));
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".page-meta.xml"));
		}	

		public override void doMerge(){}
		
	}
	
}
