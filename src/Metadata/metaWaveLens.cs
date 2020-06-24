using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class metaWaveLens:MetaBase {
		
		public metaWaveLens(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.WaveLens;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".wlens");		
		}	

		public override void doMerge(){}
		
	}


	
}
