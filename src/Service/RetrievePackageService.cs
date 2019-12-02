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
    class RetrievePackageService {
        public static void retrieveAllPackage(){
             Organization m_organization = ConfigService.chooseCodeOrganization();
             ConsoleHelper.WriteQuestionLine(Constants.LANG_PLEASEENTERPATHPACKAGE);
             string pathPackage = Console.ReadLine();
             MetadataApiService.retrieveMetadata(m_organization, pathPackage);
             ConsoleHelper.WriteDoneLine(">> Finalize the process...");
        }
    }
}