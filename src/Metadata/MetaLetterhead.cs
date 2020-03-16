using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class MetaLetterhead : MetaBase {

		public MetaLetterhead(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.Letterhead;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".letter"));
		}	

		public override void doMerge(){}
		
	}

}