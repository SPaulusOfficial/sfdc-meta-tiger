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

    public class MetadataApiCheckRetrieveService{

        public static checkRetrieveStatusResponse response;
        
        public static checkRetrieveStatusResponse checkRetrieveStatus(MetadataApiClient metadataClient,String asyncResultId){
          run(metadataClient,asyncResultId).Wait();
          return response;
        }

        static async Task<checkRetrieveStatusResponse> run(MetadataApiClient metadataClient,String asyncResultId){
            var client = metadataClient.Client;
            var sessionHeader = metadataClient.SessionHeader;
            var callOptions = metadataClient.CallOptions;
            checkRetrieveStatusResponse result =  await client.checkRetrieveStatusAsync(sessionHeader, callOptions, asyncResultId,true);
            response = result;
            return result;
        }

    }

}