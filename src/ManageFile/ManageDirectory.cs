using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MetaTiger.Metadata;
using MetaTiger.Helper;

namespace MetaTiger.ManageFile
{
    class ManageFileDirectory {
        
		public static void createPackageDirectory(String path)
        {
            try 
            {                 
                if (Directory.Exists(@path)) 
                {
                    ConsoleHelper.WriteWarningLine("That path exists already:" + path);
                    return;
                }
                
                DirectoryInfo di = Directory.CreateDirectory(@path);                 
            } 
            catch (Exception e) 
            {
                String errorException = String.Format("The process failed: {0}",e.ToString());
                ConsoleHelper.WriteErrorLine(errorException);
            }             
        }      

        public static Boolean validateDirectory(String path){
            return (Directory.Exists(@path));            
        }  

        public static List<IMetadata> buildDirectorys(Dictionary<string, List<string>> mapPackage, string pathDir)
        {
            List<IMetadata> metaDatas = new List<IMetadata>();
            createPackageDirectory(pathDir);
            foreach (var type in mapPackage)
            {
                try{
                    String tempDirectory = String.Concat(pathDir,@"/", MetaDirectory.getDirectory(type.Key));
                    createPackageDirectory(tempDirectory);
                    IMetadata metadataWork = MetaDataFactory.getMetadata(type.Key);
                    metaDatas.Add(metadataWork);
                }catch (System.Exception e)
                {
                    ConsoleHelper.WriteWarningLine("Error found:" + e.Message);               
                }
           
            }

            return metaDatas;
        }
		
	}

    


	
}
