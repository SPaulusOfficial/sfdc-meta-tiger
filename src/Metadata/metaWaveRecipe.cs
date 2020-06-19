﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.ManageFile;

namespace MetaTiger.Metadata
{
    class metaWaveRecipe:MetaBase {
		
		public metaWaveRecipe(){
			this.m_list = new List<String>();
			this.m_metaname = MetaConstants.WaveRecipe;
		} 

		public override void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath){		
			ManageFileCopy.doCopy(directoryPath,directoryTargetFilePath,metaname+".wdpr");		
		}	

		public override void doMerge(){}
		
	}


	
}
