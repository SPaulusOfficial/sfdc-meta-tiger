using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class MetaApexComponent : MetaBase {

		public MetaApexComponent(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.ApexComponent;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".component"));
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".component-meta.xml"));
		}

		public override void doMerge(){}	
		
	}
	
}
