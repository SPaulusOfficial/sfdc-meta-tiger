using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Salesforce_Package.Metadata
{
    interface IMetadata {		
    			        
		void isValidThenAdd(String metaName,String metaFile);

		void doCopy(String sourcePath,String targetPath);

		void buildCopy(String metaname,String directoryPath,String directoryTargetFilePath);
		
	}
	
}
