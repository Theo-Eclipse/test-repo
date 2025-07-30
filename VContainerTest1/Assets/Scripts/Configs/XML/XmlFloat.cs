using System.Xml.Serialization;

namespace Wolfdev.Configs
{
    public class XmlFloat
    {
        [XmlAttribute("name")] 
        public string Name { get; set; }

        [XmlAttribute("value")] 
        public float Value { get; set; }

        public XmlFloat() { }

        public XmlFloat(string name, float value)
        {
            Name = name;
            Value = value;
        }
    }
}