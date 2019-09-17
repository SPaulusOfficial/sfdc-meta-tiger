using SFDC.Partner;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System;

namespace MetaTiger.PartnerApi{

    public class PartnerLoginRequest{
        
        private string username;
        private string password;
        private string securityToken;
        private string api;
        private bool production; 

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string SecurityToken { get => securityToken; set => securityToken = value; }
        public string Api { get => api; set => api = value; }
        public bool Production { get => production; set => production = value; }
    }

}