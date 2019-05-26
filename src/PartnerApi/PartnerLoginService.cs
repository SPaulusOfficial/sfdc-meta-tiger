using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SFDC.Partner;

namespace Salesforce_Package.PartnerApi{

    public class PartnerLoginService{
        
        static SoapClient sc;
        static PartnerLoginResponse response;

        public static PartnerLoginResponse login(PartnerLoginRequest request){
            sc = new SoapClient();
            run(request).Wait();
            return response;
        }

        private static async Task<PartnerLoginResponse> run(PartnerLoginRequest request)
        {
            loginResponse lresp = await SfLogin(request);
            LoginResult lres = lresp.result;
            response = new PartnerLoginResponse{
                ServerUrl = lres.metadataServerUrl,
                SessionId = lres.sessionId,
                UserId = lres.userId
            };
            return response;
        }

        private static async Task<loginResponse> SfLogin(PartnerLoginRequest request)
        {
            loginResponse lr = await sc.loginAsync(null,null, request.Username, request.Password + request.SecurityToken);
            return lr;
        }

    }

}