using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.Helper;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaMatchingRule:MetaBase {
        

		public metaMatchingRule(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.MatchingRule;
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
			   ConsoleHelper.WriteErrorLine("Not Found Matching Rule, incorrente name in package:" + metaname);	
			}
			
			  ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(m_nameObject,".matchingRule"));
			
			
		}	

		public override void doMerge(){}
		
	}
	
}
