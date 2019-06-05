using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Salesforce_Package.Metadata;
using Salesforce_Package.Manage;
using Salesforce_Package.ManageXML;
using Salesforce_Package.Xml.Config;
using Salesforce_Package.MetadataApi;

namespace Salesforce_Package
{
    class Program
    {

        static void Main(string[] args)
        {
           
            Console.WriteLine("");
            ConsoleHelper.WriteDocLine("###################################################");
            ConsoleHelper.WriteDocLine("#      Salesforce - All for One - Version 4.0     #");
            ConsoleHelper.WriteDocLine("#           Generate files of Repository          #");
            ConsoleHelper.WriteDocLine("#         Author:Bruno Smith Lopes Ribeiro        #");
            ConsoleHelper.WriteDocLine("#        E-mail:bruno_smith10@hotmail.com         #");
            ConsoleHelper.WriteDocLine("###################################################");
            ConsoleHelper.WriteQuestionLine("1 - Get All Package.xml");
            ConsoleHelper.WriteQuestionLine("2 - Generate Package With Files of Repository");
            int strAction = Convert.ToInt32(Console.ReadLine());

            switch (strAction)
            {
                case 1: 
                        MetadataPackageService.getAllPackage();
                        break;
                case 2: MetadataPackageService.generatePackageRepository();
                        break;
                default:
                        break;
            }
           
           
        }     
    }


    
}
