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
		
		public override void runAddon(String metaname,String directoryPath,String directoryTargetFilePath,Organization organization){
			 List<MetaTigerAddon> addons = new List<MetaTigerAddon>();
			 if(!runAddons){
				runAddons = true;

				bool isHaveOrganization = organization!=null;
				
				if(isHaveOrganization){
					addons = ConfigService.getAddonsOrganization(MetaConstants.ApexClass,organization);
				}else{
					addons = ConfigService.getAddonsDefault(MetaConstants.ApexClass);
				}

				bool isHaveAddons = addons!=null;

				if(isHaveAddons){
				  foreach(MetaTigerAddon addon in addons){
					isPMD(metaname,directoryPath,directoryTargetFilePath,addon);
				  }	
				}

			}
		}

		private void isPMD(String metaname,String directoryPath,String directoryTargetFilePath,MetaTigerAddon addon){
			if(addon.Name == "PMD"){
			  foreach(MetaTigerAction action in addon.Actions){
					string commandFile = action.Command.Replace("{filepath}", directoryTargetFilePath);
					ConsoleHelper.WriteWarningLine(directoryTargetFilePath);
					string response = ShellHelper.Bash(commandFile,addon.FilePathName);
					response = response.Replace(directoryTargetFilePath,"");
					response = response.Replace("/","");
					string directoryTargetFilePathReply = directoryTargetFilePath.inverseBarLeft();
					directoryTargetFilePathReply = directoryTargetFilePathReply.inverseBarRight();
					response = response.Replace(directoryTargetFilePathReply,"");
					response = response.escapeForEmpty();
					response = response.Trim();
					if(response.isNullOrEmpty()){
						ConsoleHelper.WriteWarningLine(response);
					}
				}
			}
		}


	}

}
