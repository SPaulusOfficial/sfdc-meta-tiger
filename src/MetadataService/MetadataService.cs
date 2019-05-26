using SFDC.MetadataService;
using Salesforce_Package.PartnerApi;

namespace Salesforce_Package.MetadataApi{

    public class MetadataService{
        
        private static MetadataClientResponse getMetadataClient(MetadataClientRequest request){
             PartnerLoginRequest requestPattern = new PartnerLoginRequest{
                Username = request.Username,
                Password = request.Password,
                SecurityToken = request.SecurityToken,
            };
            PartnerLoginResponse responsePartner = PartnerService.login(requestPattern);
            return MetadataClientService.getMetadataClient(responsePartner.UserId,responsePartner.SessionId,responsePartner.ServerUrl); 
        }

        public static void listMetadata(){
             MetadataClientRequest request = new MetadataClientRequest();
             request.Username = "bruno_smith10@hotmail.com";
             request.Password ="Netero40#####";
             request.SecurityToken = "wPC63Ccnu6hKydagrwkXT0Rax";
             MetadataClientResponse response  = getMetadataClient(request);
             MetadataListMetadataService.listMetadata(response.Metadataclient);
        } 

    }

}