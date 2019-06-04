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
                        getAllPackage();
                        break;
                case 2: MetadataPackageService.generatePackageRepository();
                        break;
                default:
                        break;
            }
           
           
        }

        public static void getAllPackage(){
             Organization m_organization = chooseCodeOrganization();
             MetadataApiService.getAllPackage(m_organization);
             ConsoleHelper.WriteDoneLine(">> Finalize the process...");
        }


        public static Organization chooseCodeOrganization(){
            ConsoleHelper.WriteQuestionLine(">>> Choose code organization save in Config:");
            Config m_config = ManageXMLConfig.Deserialize();
            Dictionary<int,Organization> m_organizations = new Dictionary<int,Organization>();
            if(m_config.PackageManifest.Count>0){
              ConsoleHelper.WriteDocLine("Id | UserName | Password | SecurityToken");
              foreach (var item in m_config.Organization)
                {
                    m_organizations.Add(item.Id,item);
                    String nameOrganization = String.Concat(item.Id," | ");
                    String Username = String.Concat(item.Username," | ");
                    String Password = String.Concat(item.Password," | ");
                    String SecurityToken = String.Concat(item.SecurityToken," ");
                    Console.WriteLine(String.Concat(nameOrganization,Username,Password,SecurityToken));
                }
            }

            try
            {
               ConsoleHelper.WriteQuestionLine(">>> Code Organization:"); 
               int id = Int32.Parse(Console.ReadLine());

               if(m_organizations.ContainsKey(id)){
                   return (m_organizations[id]);
               }else{
                   ConsoleHelper.WriteWarningLine("Not Found Organization");
                   return new Organization();
               }
            }
            catch (System.Exception)
            { 
                return new Organization();
                throw;
            }

            
        }
                
    }


    
}
