using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class metaReportType:MetaBase {        		

		public metaReportType(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.ReportType;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".reportType");											
		}

		public override void doMerge(){}

	}
	
}
