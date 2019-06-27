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

     public class MetadataApiGetAllPackageLastModifiedByName:MetadataApiPackageBase{

        public List<string> myusers;


        public void getAllPackage(Organization Organization,MetadataApiClientResponse response,List<string> nameuser){
            myusers = nameuser;
            run(Organization,response);
        }

         
        public override bool doFilter(FileProperties f){
           DateTime dt1970 = new DateTime(1970, 1, 1);
           return myusers.Contains(f.lastModifiedByName) && f.lastModifiedDate!=dt1970; 
        }

     }

}