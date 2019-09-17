using SFDC.Partner;
using MetaTiger.Api.Metadata;

namespace MetaTiger.PartnerApi{

    public class PartnerApiService{
        
        public static PartnerLoginResponse login(PartnerLoginRequest request){
            return PartnerLoginService.login(request); 
        }

        public static PartnerLoginRequest createPartnerLoginRequest(MetadataApiClientRequest request)
        {
            return new PartnerLoginRequest
            {
                Username = request.Username,
                Password = request.Password,
                SecurityToken = request.SecurityToken,
                Production = request.Production,
                Api = request.Api
            };
        }

    }

}