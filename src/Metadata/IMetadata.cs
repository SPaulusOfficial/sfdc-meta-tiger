using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.Xml.Config;

namespace MetaTiger.Metadata
{
    interface IMetadata {		
    			        
		void isValidThenAdd(String metaname,String MetaFile);

		void doCopy(String sourcePath,String targetPath);

		void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath);

		void doMerge();
		
		void doAddon(String sourcePath,String targetPath,Organization organization);

		void runAddon(String metaname,String directoryPath,String directoryTargetFilePath,Organization organization);
		
	}
	
}
