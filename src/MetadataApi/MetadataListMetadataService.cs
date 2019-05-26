using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SFDC.MetadataService;

namespace Salesforce_Package.MetadataApi{

    public class MetadataListMetadataService{
        
        public static void listMetadata(MetadataClient metadataClient){
          ListMetadataQuery(metadataClient).Wait();
        }

        static async Task<SFDC.MetadataService.listMetadataResponse> ListMetadataQuery(MetadataClient metadataClient)
        {
            var client = metadataClient.Client;
            var sessionHeader = metadataClient.SessionHeader;
            var callOptions = metadataClient.CallOptions;
            ListMetadataQuery q = new ListMetadataQuery();
            q.type = "CustomObject";
            listMetadataResponse lstMetaResponse =  await client.listMetadataAsync(sessionHeader, callOptions, new []{ q} , 45.0);
            foreach (FileProperties f in lstMetaResponse.result)
            {
                Console.WriteLine("response with message: " + f.fileName);
                Console.WriteLine("response with message: " + f.fullName);
            }
            
            return lstMetaResponse;
        }

    }

}