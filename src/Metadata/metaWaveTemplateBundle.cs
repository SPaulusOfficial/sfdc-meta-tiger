using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class metaWaveTemplateBundle:MetaBase {
		
		public metaWaveTemplateBundle(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.WaveTemplateBundle;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){	
			ManageFileDirectory.directoryCopy(String.Concat(directoryPath,@"/",metaname),String.Concat(directoryTargetFilePath,@"/",metaname),true);		
		}	

		public override void doMerge(){}
		
	}


	
}
