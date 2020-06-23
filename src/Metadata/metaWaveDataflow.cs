using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class metaWaveDataflow:MetaBase {
		
		public metaWaveDataflow(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.WaveDataflow;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".wdf");
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".wdf-meta.xml");		
		}	

		public override void doMerge(){}
		
	}


	
}
