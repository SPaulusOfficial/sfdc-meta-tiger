using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class MetaLayout:MetaBase {
        
		public MetaLayout(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.Layout;
		} 
		
		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".layout");				
		}

		public override void doMerge(){}
	}


	
}
