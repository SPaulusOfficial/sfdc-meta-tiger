using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class MetaEmailTemplate:MetaBase {
        

		public MetaEmailTemplate(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.EmailTemplate;			
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			String [] findFolderEmail = metaname.Split("/");
			ManageFileDirectory.createPackageDirectory(directoryTargetFilePath+"\\"+findFolderEmail[0]);   				
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".email");				
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".email-meta.xml");		
		}

		public override void doMerge(){}
	}


	
}
