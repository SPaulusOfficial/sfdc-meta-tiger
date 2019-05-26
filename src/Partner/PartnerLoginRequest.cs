using SFDC.Partner;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Salesforce_Package.PartnerApi{

    public class PartnerLoginRequest{
        
        private string username;
        private string password;
        private string securityToken;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string SecurityToken { get => securityToken; set => securityToken = value; }
    }

}