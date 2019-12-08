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
			String pathComponent = String.Concat(@"\",metaname); 
			directoryPath = String.Concat(directoryPath,pathComponent);
			directoryTargetFilePath = String.Concat(directoryTargetFilePath,pathComponent);

			List<String> components = new List<String>(){
				".cmp",".cmp-meta.xml",".auradoc",".css",".design",".svg","Controller.js","Helper.js",
				"Renderer.js",".evt",".evt-meta.xml"
			};

			foreach(String component in components){
			  ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,component),true);	
			}
			
		}	

		public override void doMerge(){}
		
	}

}
