using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SFDC.Metadata;
using Salesforce_Package;

namespace Salesforce_Package.MetadataApi{

    public class MetadataListMetadataApiService{

        public static listMetadataResponse response;
        
        public static listMetadataResponse listMetadata(MetadataClient metadataClient,String strType){
          ListMetadataQuery(metadataClient,strType).Wait();
          return response;
        }

        static async Task<SFDC.Metadata.listMetadataResponse> ListMetadataQuery(MetadataClient metadataClient,String strType)
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