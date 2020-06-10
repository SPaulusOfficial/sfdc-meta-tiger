using SFDC.Metadata;

namespace MetaTiger.Api.Metadata{

    public class MetadataApiClientRequest{
        
        private string username;
        private string password;
        private string securityToken;
        private string api;
        private string url;
        private bool production;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Url { get => url; set => url = value; }
        public string SecurityToken { get => securityToken; set => securityToken = value; }
        public string Api { get => api; set => api = value; }
        public bool Production { get => production; set => production = value; }
    }

}