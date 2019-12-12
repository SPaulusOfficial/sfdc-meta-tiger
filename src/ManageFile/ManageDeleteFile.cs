using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MetaTiger.Metadata;
using MetaTiger.Helper;

public class ManageDeleteFile{
    public static void DeletingFiles(System.IO.DirectoryInfo directory)
    {
        //delete files:
        foreach (System.IO.FileInfo file in directory.GetFiles()) 
            file.Delete();
        //delete directories in this directory:
        foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories())
            directory.Delete(true);
    }

    
    public static void DeletingDirectory(System.IO.DirectoryInfo directory)
    {
        try {
            directory.Delete(true);
        } catch (Exception) 
        {
            Console.WriteLine("The Delete operation failed as expected.");
        } 
    }
}

