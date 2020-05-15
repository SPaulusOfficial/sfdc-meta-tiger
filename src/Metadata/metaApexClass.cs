using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.Helper;
using MetaTiger.ManageFile;
using MetaTiger.Xml.Config;

namespace MetaTiger.Metadata{
    class MetaApexClass : MetaBase {

		private Boolean runAddons;

		public MetaApexClass(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.ApexClass;
			runAddons = false;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".cls"));
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".cls-meta.xml"));
		}	

		public override void doMerge(){}
		
		public override void runAddon(String metaname,String directoryPath,String directoryTargetFilePath){
			 if(!runAddons){
				runAddons = true;
				List<MetaTigerAddon> addons = ConfigService.getAddons(MetaConstants.ApexClass);
				foreach(MetaTigerAddon addon in addons){
					isPMD(metaname,directoryPath,directoryTargetFilePath,addon);
				}	
			}
		}

		private void isPMD(String metaname,String directoryPath,String directoryTargetFilePath,MetaTigerAddon addon){
			foreach(MetaTigerAction action in addon.Actions){
				string commandFile = action.Command.Replace("{filepath}", directoryPath);
				string response = ShellHelper.Bash(commandFile,addon.FilePathName);
				string directoryPathreply = directoryPath.inverseBarLeft();
				directoryPathreply = directoryPathreply.inverseBarRight();
				response = response.Replace(directoryPathreply,"");
				response = response.escapeForEmpty();
				response = response.Trim();
				if(response.isNullOrEmpty()){
					ConsoleHelper.WriteWarningLine(response);
				}
			}
				
		}


	}

}
