using System;
using System.Collections.Generic;
using SFDC.Metadata;
using MetaTiger.ManageFileXML;
using MetaTiger.PartnerApi;
using MetaTiger.Xml;
using MetaTiger.Xml.Config;
using MetaTiger.Xml.Package;
using System.Threading;
using System.IO;
using System.IO.Compression;
using MetaTiger.Helper;

namespace MetaTiger.Api.Metadata{

     public class MetadataApiGetAllPackage:MetadataApiPackageBase{


        public void getAllPackage(Organization Organization,MetadataApiClientResponse response){
            run(Organization,response);
        }

         
        public override bool doFilter(FileProperties f){
            return true;
        }

     }

}