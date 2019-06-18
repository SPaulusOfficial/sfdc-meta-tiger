using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaTerritory2 : MetaBase {

		public metaTerritory2(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.Territory2;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			String [] propertiesTerritory2 = metaname.Split(".");
			String subDirectoryTerritory2 = propertiesTerritory2[0];
			metaname = propertiesTerritory2[1];
			String territories = "territories";
			String bar = "\\";
			
			directoryPath = String.Concat(directoryPath,bar,subDirectoryTerritory2,bar,territories,bar);
			directoryTargetFilePath = String.Concat(directoryTargetFilePath,bar,subDirectoryTerritory2,bar,territories,bar);
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".territory2"));
		}	

		public override void doMerge(){}
		
	}

}
