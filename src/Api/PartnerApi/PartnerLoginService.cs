using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SFDC.Partner;
using System.ServiceModel;
using System;
using MetaTiger.Helper;

namespace MetaTiger.PartnerApi{

    public class PartnerLoginService{
        
        static SoapClient sc;
        static PartnerLoginResponse response;

        public static PartnerLoginResponse login(PartnerLoginRequest request){
            string typeEnviroment = request.Production ? "login" : "test";
            string Api = request.Api;
            string Url = request.Url;
            string endPointService = Url!=null ? String.Concat(Url,"/services/Soap/u/",Api) : String.Concat("https://",typeEnviroment,".salesforce.com/services/Soap/u/",Api);
            ConsoleHelper.WriteWarningLine(endPointService);
            EndpointAddress apiAddress = new EndpointAddress(endPointService);
            sc = new SoapClient(SFDC.Partner.SoapClient.EndpointConfiguration.Soap, apiAddress);
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