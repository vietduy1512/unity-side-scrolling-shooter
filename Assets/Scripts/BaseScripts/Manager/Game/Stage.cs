using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

public class Stage {
    [XmlAttribute("name")]
    public string Name;
    [XmlAttribute("score")]
    public string Score;
}