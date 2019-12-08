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
    class GetAllPackageService {
        public static void getAllPackage(){
             Organization m_organization = ConfigService.chooseCodeOrganization();
             MetadataApiService.getAllPackage(m_organization);
             ConsoleHelper.WriteDoneLine(">> Finalize the process...");
        }
    }
}