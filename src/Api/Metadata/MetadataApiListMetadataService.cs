using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SFDC.Metadata;
using MetaTiger;

namespace MetaTiger.Api.Metadata{

    public class MetadataApiListMetadataService{

        public static listMetadataResponse response;
        
        public static listMetadataResponse listMetadata(MetadataApiClient metadataClient,String strType){
          run(metadataClient,strType).Wait();
          return response;
        }

        static async Task<SFDC.Metadata.listMetadataResponse> run(MetadataApiClient metadataClient,String strType)
        {
            var client = metadataClient.Client;
            var sessionHeader = metadataClient.SessionHeader;
            var callOptions = metadataClient.CallOptions;
            listMetadataResponse lstMetaResponse = new listMetadataResponse();
            ListMetadataQuery q = new ListMetadataQuery();
            q.type = strType;
            
            response =  await client.listMetadataAsync(sessionHeader, callOptions, new []{ q} , 45);
            
            return lstMetaResponse;
        }

    }

}