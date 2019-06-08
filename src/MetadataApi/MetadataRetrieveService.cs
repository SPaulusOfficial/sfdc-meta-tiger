using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SFDC.Metadata;
using Salesforce_Package;
using Salesforce_Package.ManageXML;

namespace Salesforce_Package.MetadataApi{

    public class MetadataRetrieveService{

        public static String asyncId;
        
        public static String retrieve(MetadataClient metadataClient,Package package){
          run(metadataClient,package).Wait();
          return asyncId;
        }

        static async Task<String> run(MetadataClient metadataClient,Package package)
        {
            var client = metadataClient.Client;
            var sessionHeader = metadataClient.SessionHeader;
            var callOptions = metadataClient.CallOptions;
            RetrieveRequest request = new RetrieveRequest();

            ConsoleHelper.WriteDocLine("##########lalala############");
            foreach(PackageTypeMembers mtype in package.types){
              ConsoleHelper.WriteDocLine(mtype.name);
              foreach(String member in mtype.members){
                ConsoleHelper.WriteDocLine(member);
              }
            }
            ConsoleHelper.WriteDocLine("######################");
          

            request.unpackaged = package;
            retrieveResponse resultResponse =  await client.retrieveAsync(sessionHeader, callOptions, request);
            asyncId = resultResponse.result.id;
            return resultResponse.result.id;
        }

    }

}