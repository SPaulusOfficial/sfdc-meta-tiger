using SFDC.Partner;

namespace Salesforce_Package.PartnerApi{

    public class PartnerService{
        
        public static PartnerLoginResponse login(PartnerLoginRequest request){
            return PartnerLoginService.login(request); 
        }

    }

}