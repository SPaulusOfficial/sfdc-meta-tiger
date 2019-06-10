using SFDC.Metadata;

namespace MetaTiger.Api.Metadata{

    public class MetadataApiClient{

      private MetadataPortTypeClient client;
    
      private SessionHeader sessionHeader;
      
      private CallOptions callOptions;

      public MetadataPortTypeClient Client { get => client; set => client = value; }
      public SessionHeader SessionHeader { get => sessionHeader; set => sessionHeader = value; }
      public CallOptions CallOptions { get => callOptions; set => callOptions = value; }
    }

}