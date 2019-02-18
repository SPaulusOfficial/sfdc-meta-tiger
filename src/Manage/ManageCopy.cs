using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Salesforce_Package.Manage
{
    class ManageCopy {
        
		public static void doCopy(String sourcePath, String targetPath, String fileName){			
			try{
				string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
				string destFile = System.IO.Path.Combine(targetPath, fileName);
				
				if (!System.IO.Directory.Exists(targetPath))
				{
					System.IO.Directory.CreateDirectory(targetPath);
				}
				
				System.IO.File.Copy(sourceFile, destFile, true);	
			}
			catch (System.IO.FileNotFoundException e)
			{			  
       		  ConsoleHelper.WriteErrorLine(String.Concat("Not found file in directory:",e.Message));
			}			
		}
		
	}


	
}
