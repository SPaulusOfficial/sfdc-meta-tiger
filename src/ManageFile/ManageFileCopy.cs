using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using MetaTiger.Helper;

namespace MetaTiger.ManageFile
{
    class ManageFileCopy {
        

		public static void run(string sourcePath,string fileName, string targetPath){
			string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
			string destFile = System.IO.Path.Combine(targetPath, fileName);
			
			if (!System.IO.Directory.Exists(targetPath))
			{
				System.IO.Directory.CreateDirectory(targetPath);
			}
			
			System.IO.File.Copy(sourceFile, destFile, true);
		}

		public static void doCopy(String sourcePath, String targetPath, String fileName){			
			try{
				run(sourcePath,fileName, targetPath);
			}
			catch (System.IO.FileNotFoundException e)
			{			  
       		  ConsoleHelper.WriteErrorLine(String.Concat("Not found file in directory:",e.Message));
			}			
		}

		public static void doCopy(String sourcePath, String targetPath, String fileName,bool exception){			
			try{
				run(sourcePath,fileName, targetPath);
			}
			catch (System.IO.FileNotFoundException e)
			{			  
		      if(!exception){
				ConsoleHelper.WriteErrorLine(String.Concat("Not found file in directory:",e.Message));
			  }
			}			
		}
		
	}


	
}
