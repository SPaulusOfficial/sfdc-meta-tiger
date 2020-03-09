using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class MetaApprovalProcess : MetaBase {

		public MetaApprovalProcess(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.ApprovalProcess;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".approvalProcess"));
		}	

		public override void doMerge(){}
		
	}

}
