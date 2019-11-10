using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using SFDC.Metadata;
namespace MetaTiger.Xml.Config
{
	[Serializable()]
	[XmlRoot(ElementName="OrganizationDeploy")]
	public class OrganizationDeploy {
		[XmlElement(ElementName="Id")]
		public int Id { get; set; }
		[XmlElement(ElementName="DeployNick")]
		public string DeployNick { get; set; }
		[XmlElement(ElementName="DebuggingHeader")]
		public DebuggingHeader DebuggingHeader {get;set;}
		[XmlElement(ElementName="DeployOptions")]
		public DeployOptions DeployOptions {get;set;}

	}

}
