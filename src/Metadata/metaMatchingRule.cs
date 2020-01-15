using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaMatchingRule:MetaBase {
        

		public metaMatchingRule(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.MatchingRule;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".matchingRule"));
		}	

		public override void doMerge(){}
		
	}
	
}
