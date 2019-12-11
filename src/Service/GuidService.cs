using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MetaTiger.Metadata;
using MetaTiger.ManageFile;
using MetaTiger.ManageFileXML;
using MetaTiger.Xml.Config;
using MetaTiger.Api.Metadata;
using MetaTiger.Helper;

class GuidService
{

    public static String createGuid(){
        Guid g = Guid.NewGuid();
        return g.ToString();
    }
    
}