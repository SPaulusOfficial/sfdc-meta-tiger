using System;
using System.Collections.Generic;
using System.IO;
using MetaTiger.Metadata;
using MetaTiger.Helper;

namespace MetaTiger
{
    class Program
    {

        static void Main(string[] args)
        {
           
            Console.WriteLine("");
            ConsoleHelper.WriteDocLine("###################################################");
            ConsoleHelper.WriteDocLine("#                META-TIGER                       #");
            ConsoleHelper.WriteDocLine("#                Version 5.0                      #");
            ConsoleHelper.WriteDocLine("#       Author:Bruno Smith Lopes Ribeiro          #");
            ConsoleHelper.WriteDocLine("#       E-mail:bruno_smith10@hotmail.com          #");
            ConsoleHelper.WriteDocLine("###################################################");
            ConsoleHelper.WriteQuestionLine("1 - Get All Package.xml");
            ConsoleHelper.WriteQuestionLine("2 - Generate Package With Files of Repository");
            ConsoleHelper.WriteQuestionLine("3 - Retrieve Files in Package");
            ConsoleHelper.WriteQuestionLine("4 - Get All Package.xml With User Last Modified");
            ConsoleHelper.WriteQuestionLine("5 - Get All Package.xml With User Created");
            ConsoleHelper.WriteQuestionLine("Please choose option:");
            int strAction = Convert.ToInt32(Console.ReadLine());

            switch (strAction)
            {
                case 1: 
                        MetadataPackageService.getAllPackage();
                        break;
                case 2: MetadataPackageService.generatePackageRepository();
                        break;
                case 3: MetadataPackageService.retrieveAllPackage();
                        break;
                case 4: 
                        MetadataPackageService.getAllPackageWithNameLastModified();
                        break;
                case 5: 
                        MetadataPackageService.getAllPackageWithNameCreated();
                        break;
                default:
                        break;
            }
           
           
        }     
    }


    
}
