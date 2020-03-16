using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class MetaDocument : MetaBase {

		public MetaDocument(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.Document;
		}		

		public override void buildCopy(String metaname, String directoryPath, String directoryTargetFilePath) {
			String [] findFolder = metaname.Split("/");
			String [] filename = metaname.Split(".");

			ManageFileDirectory.createPackageDirectory(directoryTargetFilePath + @"/" + findFolder[0]);

			ManageFileCopy.doCopy(directoryPath, directoryTargetFilePath, metaname+".document");
			ManageFileCopy.doCopy(directoryPath, directoryTargetFilePath, metaname+".document-meta.xml");
		}	

		public override void doMerge(){}
		
	}

}