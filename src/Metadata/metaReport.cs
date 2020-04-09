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

			if(report.Length > 1){
				
				String folderTarget = directoryTargetFilePath+@"/";
				String folderRepository = directoryPath+@"/";
				String path = "";

				for (int i = 0; i < report.Length; i++)
				{
					if (i == report.Length - 1) { //Ultimo item - O arquivo
						//ManageFileCopy.doCopy(folderRepository+pathUp,folderTarget+pathUp,report[i]+"-meta.xml",true);
						ManageFileCopy.doCopy(folderRepository+path, folderTarget+path, report[i]+".report", true);
					} else {
						path = path +@"/"+ report[i]; // Cria as pastas necessárias
						ManageFileDirectory.createPackageDirectory(folderTarget+path);
					}
				}
			  
			}else{
				ManageFileDirectory.createPackageDirectory(directoryTargetFilePath);   				
				ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+"-meta.xml",true);	
			}

					
		}

		public override void doMerge(){}
	}


	
}
