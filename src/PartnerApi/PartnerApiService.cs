using SFDC.Partner;

namespace Salesforce_Package.PartnerApi{

    public class PartnerApiService{
        
        public static PartnerLoginResponse login(PartnerLoginRequest request){
            return PartnerLoginService.login(request); 
        }

    }

}