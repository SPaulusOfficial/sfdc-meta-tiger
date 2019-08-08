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
using System.Globalization;


namespace MetaTiger.Api.Metadata{

     public class MetadataApiGetAllPackageCreatedByName:MetadataApiPackageBase{

        public List<string> myusers;
        public List<string> dates;


        public void getAllPackage(Organization Organization,MetadataApiClientResponse response,List<string> nameuser,List<String> paDates){
            
            myusers = nameuser;
            dates = paDates;
            
            run(Organization,response);
        }

         
        public override bool doFilter(FileProperties f){
           DateTime dt1970 = new DateTime(1970, 1, 1);
           //range
           
           DateTime beginDate =DateTime.ParseExact(dates[0], "dd/MM/yyyy", CultureInfo.InvariantCulture);
           DateTime endDate =DateTime.ParseExact(dates[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);
           //DateTime beginDate  = new DateTime(2019, 7, 31, 0, 00, 00);
           //DateTime endDate = new DateTime(2019, 8, 1, 0, 00, 00);
           
           return myusers.Contains(f.createdByName) && f.createdDate!=dt1970 && (f.createdDate >= beginDate && f.createdDate >= endDate); 
        }

     }

}