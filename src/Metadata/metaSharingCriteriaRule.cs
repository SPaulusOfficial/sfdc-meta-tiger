using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.Helper;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaSharingCriteriaRule : MetaBase {

		public metaSharingCriteriaRule(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.SharingCriteriaRule;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			
			String m_nameObject = "";
			try
			{
			   String [] customMetaSplit = metaname.Split("."); 
			   m_nameObject = customMetaSplit[0];
			 
			}
			catch (System.Exception)
			{
			   ConsoleHelper.WriteErrorLine("Not Found Sharing Criteria Rule, incorrente name in package:" + metaname);	
			}
			
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(m_nameObject,".sharingRules"));
		}	

		public override void doMerge(){}
		
	}

}
