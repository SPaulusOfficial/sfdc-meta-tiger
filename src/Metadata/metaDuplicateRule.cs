using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaDuplicateRule:MetaBase {
        

		public metaDuplicateRule(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.DuplicateRule;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".duplicateRule"));
		}	

		public override void doMerge(){}
		
	}
	
}
