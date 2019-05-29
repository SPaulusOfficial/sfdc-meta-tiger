
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Salesforce_Package.Xml.Config
{
	[Serializable()]
	[XmlRoot(ElementName="Config")]
	public class Config {
		[XmlElement(ElementName="GeneralDirectoryTarget")]
		public string GeneralDirectoryTarget { get; set; }
		[XmlElement(ElementName="PackageManifest")]
		public List<PackageManifest> PackageManifest { get; set; }
		[XmlElement(ElementName="Organization")]
		public List<Organization> Organization { get; set; }
		[XmlElement(ElementName="VersionNumber")]
		public string VersionNumber { get; set; }
	}


}
