using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.Helper;
using MetaTiger.ManageFile;
using MetaTiger.Xml.Config;

namespace MetaTiger.Metadata{
    class MetaApexClass : MetaBase {

		public MetaApexClass(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.ApexClass;
		}		

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".cls"));
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,String.Concat(metaname,".cls-meta.xml"));
		}	

		public override void doMerge(){}
		
		public override void runAddon(String metaname,String directoryPath,String directoryTargetFilePath){
			 Config config = ConfigService.getConfig();
			 string file = String.Concat(metaname,".cls");
			 string fileDirectory = String.Concat(@"\",MetaDirectory.getDirectory(m_metaname));
			 foreach(MetaTigerAddon addon in config.Addon){
				if(MetaConstants.ApexClass==addon.Metadata){
					foreach(MetaTigerAction action in addon.Actions){
						string commandFile = action.Command.Replace("{filepath}", String.Concat(directoryPath,@"\",file));
						string response = ShellHelper.Bash(commandFile,addon.FilePathName);
						string directoryPathreply = directoryPath.Replace(@"\","/");
						directoryPathreply = directoryPathreply.Replace("/","\\");
						response = response.Replace(directoryPathreply,"");
						response = response.Replace("\\","");
						response = response.Trim();
						if(response!="" && response!=null){
							ConsoleHelper.WriteWarningLine(response);
						}
					}
				}
			 }
		}


	}

}
