
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace MetaTiger.Xml.Config
{
	[Serializable()]
	[XmlRoot(ElementName="MetaTigerAction")]
	public class MetaTigerAction {
		[XmlElement(ElementName="Priority")]
		public String Priority { get; set; }
		[XmlElement(ElementName="Command")]
		public String Command { get; set; }	
	}

}
