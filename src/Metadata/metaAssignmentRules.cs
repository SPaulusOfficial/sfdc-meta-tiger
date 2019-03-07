using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Salesforce_Package.Manage;

namespace Salesforce_Package.Metadata
{
    class metaAssignmentRules:MetaBase {        		

		public metaAssignmentRules(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.AssignmentRules;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".assignmentRules");											
		}

		public override void doMerge(){}

	}
	
}
