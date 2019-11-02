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

    public class MetadataApiDeployService{

        public static String asyncId;
        
        public static String deploy(MetadataApiClient metadataClient,MetadataApiDeployRequest request){
          run(metadataClient,request).Wait();
          return asyncId;
        }

        static async Task<String> run(MetadataApiClient metadataClient,MetadataApiDeployRequest request)
        {
            var client = metadataClient.Client;
            var sessionHeader = metadataClient.SessionHeader;
            var callOptions = metadataClient.CallOptions;

            var debuggingHeader = request.DebuggingHeader;
            var zipFile = request.ZipFile;
            var DeployOptions = request.DeployOptions;

            deployResponse resultResponse =  await client.deployAsync(sessionHeader,debuggingHeader, callOptions,zipFile, DeployOptions);
            asyncId = resultResponse.result.id;
            return resultResponse.result.id;
        }

    }

}