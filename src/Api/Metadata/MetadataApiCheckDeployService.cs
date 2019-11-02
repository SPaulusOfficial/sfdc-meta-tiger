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

    public class MetadataApiCheckDeployService{

        public static checkDeployStatusResponse response;
        
        public static checkDeployStatusResponse checkDeployStatus(MetadataApiClient metadataClient,String asyncResultId){
          run(metadataClient,asyncResultId).Wait();
          return response;
        }

        static async Task<checkDeployStatusResponse> run(MetadataApiClient metadataClient,String asyncResultId){
            var client = metadataClient.Client;
            var sessionHeader = metadataClient.SessionHeader;
            var callOptions = metadataClient.CallOptions;
            checkDeployStatusResponse result =  await client.checkDeployStatusAsync(sessionHeader, callOptions, asyncResultId,true);
            response = result;
            return result;
        }

    }

}