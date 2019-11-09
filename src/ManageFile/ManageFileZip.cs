using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MetaTiger.Metadata;
using MetaTiger.Helper;
using System.IO.Compression;

namespace MetaTiger.ManageFile
{
    class ManageFileZip {
        
		public static byte[] createZipFile(String path)
        {
            byte[] filePackageZip = new byte[1];
            try 
            {  
               String pathPackage = Environment.CurrentDirectory + @"\package";
               String pathZip = pathPackage + @"\deploy.zip";
               
               ManageFileDirectory.createPackageDirectory(pathPackage);

               if(File.Exists(pathZip)){
                 System.IO.File.Delete(pathZip);
               }
               
               ZipFile.CreateFromDirectory(path, pathZip, CompressionLevel.Fastest, true);
               filePackageZip = System.IO.File.ReadAllBytes(pathZip);
            }catch(Exception e){
                String errorException = String.Format("The process failed: {0}",e.ToString());
                ConsoleHelper.WriteErrorLine(errorException);
            }

            return filePackageZip;
        }
		
	}
	
}
