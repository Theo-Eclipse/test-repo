using System.Xml.Serialization;

namespace Wolfdev.Configs
{
    public class XmlString
    {
        [XmlAttribute("name")] 
        public string Name { get; set; }

        [XmlAttribute("value")] 
        public string Value { get; set; }

        public XmlString() { }

        public XmlString(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}