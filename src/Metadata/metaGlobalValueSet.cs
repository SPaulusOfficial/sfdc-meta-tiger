using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaGlobalValueSet : MetaBase {

		public metaGlobalValueSet(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.GlobalValueSet;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".globalValueSet"));
		}	

		public override void doMerge(){}
		
	}

}
