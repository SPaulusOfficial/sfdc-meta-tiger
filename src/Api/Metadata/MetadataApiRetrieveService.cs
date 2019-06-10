using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SFDC.Metadata;
using MetaTiger;
using MetaTiger.ManageFileXML;

namespace MetaTiger.Api.Metadata{

    public class MetadataApiRetrieveService{

        public static String asyncId;
        
        public static String retrieve(MetadataApiClient metadataClient,Package package){
          run(metadataClient,package).Wait();
          return asyncId;
        }

        static async Task<String> run(MetadataApiClient metadataClient,Package package)
        {
            var client = metadataClient.Client;
            var sessionHeader = metadataClient.SessionHeader;
            var callOptions = metadataClient.CallOptions;
            RetrieveRequest request = new RetrieveRequest();
            request.unpackaged = package;
            retrieveResponse resultResponse =  await client.retrieveAsync(sessionHeader, callOptions, request);
            asyncId = resultResponse.result.id;
            return resultResponse.result.id;
        }

    }

}