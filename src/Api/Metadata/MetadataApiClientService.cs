using SFDC.Metadata;
using System.Web;
using System.ServiceModel;

namespace MetaTiger.Api.Metadata{

    public class MetadataApiClientService{
        
        public static MetadataApiClientResponse getMetadataClient(string userId,string sessionId,string ServerUrl){
          
            
            BasicHttpBinding binding = new BasicHttpBinding{
                Name = "metadata"
            };
            
            binding.Security.Mode = BasicHttpSecurityMode.Transport;
            binding.MaxReceivedMessageSize = 500000000;

            EndpointAddress endpoint = new EndpointAddress(ServerUrl);
            SessionHeader sessionHeader = new SessionHeader { sessionId = sessionId };    
            CallOptions callOptions = new CallOptions{client = userId};

            MetadataApiClient mdclient = new MetadataApiClient();
            mdclient.Client = new MetadataPortTypeClient(binding,endpoint);
            mdclient.SessionHeader = sessionHeader;
            mdclient.CallOptions = callOptions;

            return new MetadataApiClientResponse{Metadataclient = mdclient};
        }

    }

}