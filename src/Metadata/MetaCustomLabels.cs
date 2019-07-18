using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class MetaCustomLabels : MetaBase {

		public MetaCustomLabels(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.CustomLabels;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".labels"));
		}	

		public override void doMerge(){}
		
	}

}
