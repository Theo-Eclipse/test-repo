using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Wolfdev.Configs.API;

namespace Wolfdev.Configs
{
    [XmlRoot("MainConfig")]
    public class MainConfig : Config<MainConfig>
    {
        [XmlElement("profile")] 
        public string Profile {get; set; } = "Default";

        [XmlArray("profiles")]
        [XmlArrayItem("profile")]
        public List<MainConfigProfile> Profiles { get; set; } = new()
        {
            new MainConfigProfile()
        };
    }
}