using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Salesforce_Package.Metadata{
    class metaFlowDefinition:metaBase {
        

		public metaFlowDefinition(){
			this.m_list = new List<String>();
			this.m_metaName = DirectoryContants.FlowDefinition;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".flowDefinition");
		}	
		
	}
	
}
