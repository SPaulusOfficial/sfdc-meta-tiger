using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class metaWaveDashboard:MetaBase {
		
		public metaWaveDashboard(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.WaveDashboard;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".wdash");
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".wdash-meta.xml");			
		}	

		public override void doMerge(){}
		
	}


	
}
