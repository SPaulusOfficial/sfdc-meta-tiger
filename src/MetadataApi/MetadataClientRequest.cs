using SFDC.MetadataService;

namespace Salesforce_Package.MetadataApi{

    public class MetadataClientRequest{
        
        private string username;
        private string password;
        private string securityToken;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string SecurityToken { get => securityToken; set => securityToken = value; }
    }

}