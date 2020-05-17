using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace MetaTiger.Xml.Config
{
	[Serializable()]
	[XmlRoot(ElementName="Organization")]
	public class Organization {
		[XmlElement(ElementName="Id")]
		public int Id { get; set; }
		[XmlElement(ElementName="Nick")]
		public string Nick { get; set; }
		[XmlElement(ElementName="Username")]
		public string Username { get; set; }
		[XmlElement(ElementName="Password")]
		public string Password { get; set; }
		[XmlElement(ElementName="SecurityToken")]
		public string SecurityToken { get; set; }
		[XmlElement(ElementName="Production")]
		public string Production { get; set; }
		[XmlElement(ElementName="Api")]
		public string Api { get; set; }
		[XmlElement(ElementName="DeploySettings")]
		public List<OrganizationDeploy> DeploySettings { get; set; }
		[XmlElement(ElementName="MetaTigerAddon")]
		public List<MetaTigerAddon> Addon { get; set; }
	}

}
