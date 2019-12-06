using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MetaTiger.Metadata;
using MetaTiger.Helper;

namespace MetaTiger.ManageFile
{
    class ManageFileExists {
        
		public static bool verifyFileInDirectory(String path)
    {
        return File.Exists(path); 
    }
		
	}
	
}