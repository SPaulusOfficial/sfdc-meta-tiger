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
        
		public static byte[] createZipFile(String path,Boolean IC)
        {
            byte[] filePackageZip = new byte[1];
            try 
            {  
               String pathPackage = "";

               if(IC){
                 pathPackage = path + @"//deploy";
               }else{
                 pathPackage = Environment.CurrentDirectory + @"//package";
               }

               String g = GuidService.createGuid();
               
               String pathZipDirectory = Environment.CurrentDirectory + @"//package//deploy//";
               String pathZip =pathZipDirectory + g +  ".zip";  

               ManageFileDirectory.createPackageDirectory(pathZipDirectory);   

               ZipFile.CreateFromDirectory(path, pathZip, CompressionLevel.Fastest, true);

               filePackageZip = System.IO.File.ReadAllBytes(pathZip);

               System.IO.File.Delete(pathZip);
               
            }catch(Exception e){
                String errorException = String.Format("The process failed: {0}",e.ToString());
                ConsoleHelper.WriteErrorLine(errorException);
            }

            return filePackageZip;
        }
		
	}
	
}
