using SFDC.Partner;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Salesforce_Package.PartnerApi{

    public class PartnerLoginResponse{
        
        private string serverUrl;
        private string sessionId;
        private string userId;

        public string ServerUrl { get => serverUrl; set => serverUrl = value; }
        public string SessionId { get => sessionId; set => sessionId = value; }
        public string UserId { get => userId; set => userId = value; }
    
    }

}