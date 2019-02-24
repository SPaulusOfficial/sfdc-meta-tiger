
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Salesforce_Package.Xml.Config
{
	[Serializable()]
	[XmlRoot(ElementName="PackageManifest")]
	public class PackageManifest {
		[XmlElement(ElementName="Id")]
		public int Id { get; set; }
		[XmlElement(ElementName="DirectoryTarget")]
		public string DirectoryTarget { get; set; }
		[XmlElement(ElementName="RepositorySource")]
		public string RepositorySource { get; set; }
		[XmlElement(ElementName="PackageFile")]
		public string PackageFile { get; set; }
	}

}
