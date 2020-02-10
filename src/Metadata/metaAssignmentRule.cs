using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.Helper;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class metaAssignmentRule:MetaBase {        		

		public metaAssignmentRule(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.AssignmentRule;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			try{
				String [] customMetaSplit = metaname.Split("."); 
				String m_nameObject = customMetaSplit[0];
				String customInMeta = customMetaSplit[1];
				ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,m_nameObject+".assignmentRules");									
			}
			catch (System.Exception e)
			{
				ConsoleHelper.WriteErrorLine("Format Invalid " + e.Message);
			}
		
		}

		public override void doMerge(){}

	}
	
}
