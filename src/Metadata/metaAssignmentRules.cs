using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class metaAssignmentRules:MetaBase {        		

		public metaAssignmentRules(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.AssignmentRules;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".assignmentRules");											
		}

		public override void doMerge(){}

	}
	
}
