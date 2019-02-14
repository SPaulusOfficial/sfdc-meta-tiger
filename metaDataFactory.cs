using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Salesforce_Package
{
    class metaDataFactory {
        
        public static IMetadata getMetadata(String metadata){
            
            IMetadata metaData  = null;

            if(metadata.Equals(DirectoryContants.ApexClass)){
                metaData =  new metaApexClass();                
            
            } else if(metadata.Equals(DirectoryContants.ApexPage)){
                metaData =  new metaApexPage();                
            
            } else if(metadata.Equals(DirectoryContants.CustomMetadata)){
                metaData =  new metaCustomMetadata();
            
            } else if(metadata.Equals(DirectoryContants.CustomObject)){
                metaData =  new metaCustomObject();
            
            } else if(metadata.Equals(DirectoryContants.EmailTemplate)){
                metaData =  new metaEmailTemplate();
            
            } else if(metadata.Equals(DirectoryContants.Layout)){
                metaData =  new metaLayout();
            
            } else if(metadata.Equals(DirectoryContants.PermissionSet)){
                metaData =  new metaPermissionSet();
            
            } else if(metadata.Equals(DirectoryContants.Profile)){
                metaData =  new metaProfiles();
            
            } else if(metadata.Equals(DirectoryContants.StaticResource)){
                metaData =  new metaStaticResource();        
                    
            }  else if(metadata.Equals(DirectoryContants.CustomField)){
                metaData =  new metaCustomField();                            
            }            
            else if(metadata == null){                
                throw new System.Exception("Metadata not found: " + metadata);                                
            }

            return metaData;
                       
        }
		
      
      
		
	}


	
}
