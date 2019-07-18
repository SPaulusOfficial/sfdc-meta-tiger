using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaAuraDefinitionBundle : MetaBase {

		public metaAuraDefinitionBundle(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.AuraDefinitionBundle;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			String pathComponent = String.Concat("\\",metaname); 
			directoryPath = String.Concat(directoryPath,pathComponent);
			directoryTargetFilePath = String.Concat(directoryTargetFilePath,pathComponent);
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".auradoc"));
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".cmp"));
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".cmp-meta.xml"));
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".css"));
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".design"));
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".svg"));
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,"Controller.js"));
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,"Helper.js"));
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,"Renderer.js"));
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".evt"));
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".evt-meta.xml"));
		}	

		public override void doMerge(){}
		
	}

}
