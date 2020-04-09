using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.Helper;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class metaReport:MetaBase {
        

		public metaReport(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.Report;			
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			String [] report = metaname.Split("/");

			if(report.Length > 0){
				
				String folderTarget = directoryTargetFilePath+@"/";
				String folderRepository = directoryPath+@"/";
				String path = "";
				String pathUp = "";

				for (int i = 0; i < report.Length; i++)
				{
				    pathUp = path;
					path = path +@"/"+ report[i];

					if(i + 1 < report.Length){
						ManageFileDirectory.createPackageDirectory(folderTarget+path);
					}
					ManageFileCopy.doCopy(folderRepository+pathUp,folderTarget+pathUp,report[i]+"-meta.xml",true);
					ManageFileCopy.doCopy(folderRepository+pathUp,folderTarget+pathUp,report[i]+".report",true);
				}
			  
			}else{
				ManageFileDirectory.createPackageDirectory(directoryTargetFilePath);   				
				ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+"-meta.xml",true);	
			}

					
		}

		public override void doMerge(){}
	}


	
}
