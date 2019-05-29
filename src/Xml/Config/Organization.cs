using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Salesforce_Package.Xml.Config
{
	[Serializable()]
	[XmlRoot(ElementName="Organization")]
	public class Organization {
		[XmlElement(ElementName="Id")]
		public int Id { get; set; }
		[XmlElement(ElementName="Username")]
		public string Username { get; set; }
		[XmlElement(ElementName="Password")]
		public string Password { get; set; }
		[XmlElement(ElementName="SecurityToken")]
		public string SecurityToken { get; set; }
	}

}
