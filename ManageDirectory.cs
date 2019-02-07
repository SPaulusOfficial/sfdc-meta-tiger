using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Salesforce_Package
{
    class ManageDirectory {
        
		public static void cretePackageDirectory(String path)
        {
            try 
            {                 
                if (Directory.Exists(@path)) 
                {
                    Console.WriteLine("That path exists already:" + path);
                    return;
                }
                
                DirectoryInfo di = Directory.CreateDirectory(@path);                 
            } 
            catch (Exception e) 
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }             
        }
		
	}


	
}
