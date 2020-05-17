
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace MetaTiger.Xml.Config
{
	[Serializable()]
	[XmlRoot(ElementName="MetaTigerAddon")]
	public class MetaTigerAddon {
		[XmlElement(ElementName="Id")]
		public int Id { get; set; }
		[XmlElement(ElementName="Name")]
		public string Name { get; set; }

		[XmlElement(ElementName="FilePathName")]
		public string FilePathName { get; set; }

		[XmlElement(ElementName="MetaTigerAction")]
		public List<MetaTigerAction> Actions { get; set; }
		
		[XmlElement(ElementName="Metadata")]
		public string Metadata { get; set; }

		[XmlElement(ElementName="Enabled")]
		public bool Enabled { get; set; }
	}

}
