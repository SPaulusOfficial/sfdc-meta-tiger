using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaTerritory2Model : MetaBase {

		public metaTerritory2Model(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.Territory2Model;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			String bar = "\\";
			directoryPath = String.Concat(directoryPath,bar,metaname,bar);
			directoryTargetFilePath = String.Concat(directoryTargetFilePath,bar,metaname,bar);
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".territory2Model"));
		}	

		public override void doMerge(){}
		
	}

}
