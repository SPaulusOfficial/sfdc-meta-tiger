using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaTerritory2Type : MetaBase {

		public metaTerritory2Type(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.Territory2Type;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".territory2Type"));
		}	

		public override void doMerge(){}
		
	}

}
