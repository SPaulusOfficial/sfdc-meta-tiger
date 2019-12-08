using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MetaTiger.Metadata;
using MetaTiger.ManageFile;
using MetaTiger.ManageFileXML;
using MetaTiger.Xml.Config;
using MetaTiger.Api.Metadata;
using MetaTiger.Helper;

namespace MetaTiger.Service{
    class MetadataPackageService {
        
        public static void getAllPackageWithNameLastModified(){
             Organization m_organization = ConfigService.chooseCodeOrganization();
             List<string> nameuserList,dates;
             
             nameuserList = getNamesForUsers();

             dates = getRangeDate();

             if(isHaveUsers(nameuserList)){
               MetadataApiService.getAllPackageLastModifiedByName(m_organization,nameuserList,dates);
               ConsoleHelper.WriteDoneLine(">> Finalize the process..."); 
             }
        }
        
        public static void getAllPackageWithNameCreated(){
             Organization m_organization = ConfigService.chooseCodeOrganization();
             List<string> nameuserList;
             List<string> dates;
             
             nameuserList = getNamesForUsers();
             dates = getRangeDate();

             if(isHaveUsers(nameuserList) && isHaveDates(dates)){
               MetadataApiService.getAllPackageCreatedByName(m_organization,nameuserList,dates);
               ConsoleHelper.WriteDoneLine(">> Finalize the process..."); 
             }
        }

        public static bool isHaveStringInArray(List<String> arrayString,String message){
           bool isHave = (arrayString.Count > 0);
            if(!isHave){
               ConsoleHelper.WriteErrorLine(message); 
            }
           return isHave;
        }

        public static bool isHaveUsers(List<string> nameuserList){
            return isHaveStringInArray(nameuserList,">> Not found users...");           
        }

        public static bool isHaveDates(List<string> dates){
            return isHaveStringInArray(dates,">> Not found dates...");
        }

        public static List<string> getNamesForUsers(){
            List<string> nameForUsers = new List<string>();
            string nameuser;
            bool isHaveName;

            do{
               ConsoleHelper.WriteQuestionLine(">> Enter with name of user... (blank will go to the next step!)");
               nameuser = Console.ReadLine();  
               isHaveName = (nameuser!=null && nameuser!= "");
               if(isHaveName)
               nameForUsers.Add(nameuser);
             }while (isHaveName);

             return nameForUsers;
        }

        public static List<string> getRangeDate(){
            List<string> dates = new List<string>();
            string beginDate,endDate;
            bool isHaveBeginDate,isHaveEndDate;

            ConsoleHelper.WriteQuestionLine(">> Enter begin date... (Required) DD/MM/YYYY");
            beginDate = Console.ReadLine(); 
            isHaveBeginDate = (beginDate!=null && beginDate!= "");
            if(isHaveBeginDate)
            dates.Add(beginDate);

            ConsoleHelper.WriteQuestionLine(">> Enter end date... (Required) DD/MM/YYYY");
            endDate = Console.ReadLine();  
            isHaveEndDate = (endDate!=null && endDate!= "");
            if(isHaveEndDate)
            dates.Add(endDate);

            return dates;
        }
    }

}