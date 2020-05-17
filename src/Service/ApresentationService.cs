using System;
using System.Collections.Generic;
using System.IO;
using MetaTiger.Metadata;
using MetaTiger.Helper;

namespace MetaTiger.Service
{

    class ApresentationService {
        
        public static void run(){
            int action;
            do{
                Console.WriteLine("");
                ConsoleHelper.WriteDocLine("###################################################");
                ConsoleHelper.WriteDocLine("#                META-TIGER                       #");
                ConsoleHelper.WriteDocLine("#                Version 7.0                      #");
                ConsoleHelper.WriteDocLine("#       Author:Bruno Smith Lopes Ribeiro          #");
                ConsoleHelper.WriteDocLine("#       E-mail:bruno_smith10@hotmail.com          #");
                ConsoleHelper.WriteDocLine("###################################################");
                ConsoleHelper.WriteQuestionLine("1 - Get All Package.xml");
                ConsoleHelper.WriteQuestionLine("2 - Generate Package With Files of Repository");
                ConsoleHelper.WriteQuestionLine("3 - Retrieve Files in Package");
                ConsoleHelper.WriteQuestionLine("4 - Get All Package.xml With User Last Modified");
                ConsoleHelper.WriteQuestionLine("5 - Get All Package.xml With User Created");
                ConsoleHelper.WriteQuestionLine("6 - Deploy Package in Salesforce");
                ConsoleHelper.WriteQuestionLine("7 - Exit Metatiger");
                ConsoleHelper.WriteQuestionLine("Please choose option:");
                
                try{
                  action = Convert.ToInt32(Console.ReadLine());        
                }catch{
                  ConsoleHelper.WriteQuestionLine("Please select an option!!");
                  action = 0;
                }
                
                switch (action)
                {
                        case 1: GetAllPackageService.getAllPackage();
                                break;
                        case 2: GeneratePackageRepository.generatePackageRepository();
                                break;
                        case 3: RetrievePackageService.retrieveAllPackage();
                                break;
                        case 4: MetadataPackageService.getAllPackageWithNameLastModified();
                                break;
                        case 5: MetadataPackageService.getAllPackageWithNameCreated();
                                break;
                        case 6: DeployService.deployPackage();
                                break;
                        default:
                                break;
                }
            }while(action!=7);
        }

        public static void run(string[] args) {

                int exitCode = 0; // Exit OK

                string branchName = args[0];
                string pathRepository = args[1];
                string idOrganizationTypeDeploy = args[2];
                string directoryTarget = "";

                if (!branchName.Contains("__")) {
                        ConsoleHelper.WriteErrorLine("Error: Organization branch name invalid!");
                        exitCode = 1; // Error Code

                } else {
                        try {
                                directoryTarget = GeneratePackageRepository.generatePackageRepository(branchName, pathRepository);
                                string idOrganization = branchName.Split("__")[1];
                                DeployService.deployPackage(idOrganization, idOrganizationTypeDeploy, directoryTarget);

                        } catch (Exception e) {
                                ConsoleHelper.WriteErrorLine( "Error: " + (e.Message.Contains("XML") ? "package.xml - " + e.Message : e.Message) );
                                exitCode = 1; // Error Code

                        } finally {
                                if (directoryTarget != "") {
                                        DirectoryInfo di = new DirectoryInfo(directoryTarget);
                                        ManageDeleteFile.DeletingDirectory(di);
                                }
                        }
                }

                Environment.Exit(exitCode);
        }

    }

}