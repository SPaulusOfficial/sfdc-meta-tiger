using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class metaWaveDataSet:MetaBase {
		
		public metaWaveDataSet(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.WaveDataset;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".wds");		
		}	

		public override void doMerge(){}
		
	}


	
}
