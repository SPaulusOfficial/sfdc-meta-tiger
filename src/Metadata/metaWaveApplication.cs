using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class metaWaveApplication:MetaBase {
		
		public metaWaveApplication(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.WaveApplication;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".wapp");		
		}	

		public override void doMerge(){}
		
	}


	
}
