using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class metaWaveXmd:MetaBase {
		
		public metaWaveXmd(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.WaveXmd;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".xmd");		
		}	

		public override void doMerge(){}
		
	}


	
}
