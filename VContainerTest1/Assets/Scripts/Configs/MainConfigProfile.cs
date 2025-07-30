using System.Xml.Serialization;

namespace Wolfdev.Configs
{
    public class MainConfigProfile
    {
        [XmlAttribute("name")]
        public XmlString Name { get; set; } = new(nameof(Name).ToLower(), "Default");

        [XmlElement("language")]
        public XmlString Language { get; set; } = new(nameof(Language).ToLower(), "en-US");

        [XmlElement("msicVolume")]
        public XmlFloat MusicVolume { get; set; } = new(nameof(MusicVolume).ToLower(), 0.7f);

        [XmlElement("soundVolume")]
        public XmlFloat SoundVolume { get; set; }= new(nameof(SoundVolume).ToLower(), 1.0f);
    }
}