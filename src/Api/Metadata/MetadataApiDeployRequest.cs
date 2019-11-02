using SFDC.Metadata;

namespace MetaTiger.Api.Metadata{

    public class MetadataApiDeployRequest{
        
        private DebuggingHeader debuggingHeader;
        private byte[] zipFile;
        private DeployOptions deployOptions;

        public DebuggingHeader DebuggingHeader { get => debuggingHeader; set => debuggingHeader = value; }
        public byte[] ZipFile { get => zipFile; set => zipFile = value; }
        public DeployOptions DeployOptions { get => deployOptions; set => deployOptions = value; }

    }

}