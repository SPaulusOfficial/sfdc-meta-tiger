using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Salesforce_Package.Metadata;

namespace Salesforce_Package
{
    class ManageDirectory {
        
		public void createPackageDirectory(String path)
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

        public List<IMetadata> buildDirectorys(Dictionary<string, List<string>> mapPackage, string pathDir)
        {
            List<IMetadata> metaDatas = new List<IMetadata>();
            this.createPackageDirectory(pathDir);
            foreach (var type in mapPackage)
            {
                try{
                    String tempDirectory = pathDir + "\\" + DirectoryContants.renameDirectoryMetaData(type.Key);
                    this.createPackageDirectory(tempDirectory);
                    metaDatas.Add(metaDataFactory.getMetadata(type.Key));  
                }catch (System.Exception e)
                {
                    ConsoleHelper.WriteWarningLine("Error found:" + e.Message);               
                }
           
            }

            return metaDatas;
        }
		
	}

    


	
}
