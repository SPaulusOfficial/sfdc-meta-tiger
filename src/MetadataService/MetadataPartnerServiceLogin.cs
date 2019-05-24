using SFDC.Partner;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Salesforce_Package.WebService.Partner{

    public class MetadataPartnerServiceLogin{
        
        static string userName = "bruno_smith10@hotmail.com";
        static string password = "Netero40#####";
        static string securityToken = "wPC63Ccnu6hKydagrwkXT0Rax";
        static SoapClient sc;
        static loginResponse lresp;
        static LoginResult lres;
        static LoginScopeHeader lsr = null;
        static string serverUrl;
        static string sessionId;
        static string userId;
        static string metadataServerUrl;

        public static void login(){
            sc = new SoapClient();
            Run().Wait();
        }

        private static async System.Threading.Tasks.Task Run()
        {
            lresp = await SfLogin();
            lres = lresp.result;
            serverUrl = lres.serverUrl;
            sessionId = lres.sessionId;
            userId = lres.userId;
            metadataServerUrl = lres.metadataServerUrl;
            ConsoleHelper.WriteQuestionLine(sessionId);
            ConsoleHelper.WriteQuestionLine("Break");
        }

        private static async Task<loginResponse> SfLogin()
        {
            loginResponse lr = await sc.loginAsync(null,null, userName, password + securityToken);
            return lr;
        }

    }

}