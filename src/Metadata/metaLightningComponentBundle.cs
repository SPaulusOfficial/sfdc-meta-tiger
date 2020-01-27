using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata{
    class metaLightningComponentBundle : MetaBase {

		public metaLightningComponentBundle(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.LightningComponentBundle;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			String pathComponent = String.Concat(@"/",metaname); 
			directoryPath = String.Concat(directoryPath,pathComponent);
			directoryTargetFilePath = String.Concat(directoryTargetFilePath,pathComponent);

			List<String> components = new List<String>(){
				".css",".html",".js",".js-meta.xml"
			};

			foreach(String component in components){
			  ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,component),true);	
			}
			
		}	

		public override void doMerge(){}
		
	}

}
