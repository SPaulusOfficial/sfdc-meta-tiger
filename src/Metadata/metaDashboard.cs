using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.Helper;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class metaDashboard:MetaBase {
        

		public metaDashboard(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.Dashboard;			
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			String [] dashboard = metaname.Split("/");

			if(dashboard.Length > 0){
				
				String folderTarget = directoryTargetFilePath+@"/";
				String folderRepository = directoryPath+@"/";
				String path = "";
				String pathUp = "";

				for (int i = 0; i < dashboard.Length; i++)
				{
				    pathUp = path;
					path = path +@"/"+ dashboard[i];
					
					if(i + 1 < dashboard.Length){
					  	ManageFileDirectory.createPackageDirectory(folderTarget+path);   
					}
					ManageFileCopy.doCopy(folderRepository+pathUp,folderTarget+pathUp,dashboard[i]+"-meta.xml",true);
					ManageFileCopy.doCopy(folderRepository+pathUp,folderTarget+pathUp,dashboard[i]+".dashboard",true);
				}
			  
			}else{
				ManageFileDirectory.createPackageDirectory(directoryTargetFilePath);   				
				ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+"-meta.xml",true);	
			}

					
		}

		public override void doMerge(){}
	}


	
}
