using SFDC.Metadata;
using System.Web;
using System.ServiceModel;

namespace Salesforce_Package.MetadataApi{

    public class MetadataClientService{
        
        public static MetadataClientResponse getMetadataClient(string userId,string sessionId,string ServerUrl){
          
            
            BasicHttpBinding binding = new BasicHttpBinding{
                Name = "metadata"
            };
            
            binding.Security.Mode = BasicHttpSecurityMode.Transport;
            binding.MaxReceivedMessageSize = 20000000;

            EndpointAddress endpoint = new EndpointAddress(ServerUrl);
            SessionHeader sessionHeader = new SessionHeader { sessionId = sessionId };    
            CallOptions callOptions = new CallOptions{client = userId};

            MetadataClient mdclient = new MetadataClient();
            mdclient.Client = new MetadataPortTypeClient(binding,endpoint);
            mdclient.SessionHeader = sessionHeader;
            mdclient.CallOptions = callOptions;

            return new MetadataClientResponse{Metadataclient = mdclient};;
        }

    }

}