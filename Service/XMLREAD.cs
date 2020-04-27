using System.Collections.Generic;
using System.Xml.Serialization;

namespace IntermechToSouz
{
    //[XmlRoot(ElementName = "relation")]
    //public class Relation
    //{
    //    [XmlAttribute(AttributeName = "elementtype")]
    //    public string Elementtype { get; set; }

    //    [XmlAttribute(AttributeName = "id")]
    //    public string Id { get; set; }

    //    [XmlAttribute(AttributeName = "ref")]
    //    public string Ref { get; set; }
    //}

    //[XmlRoot(ElementName = "occurrence")]
    //public class Occurrence
    //{
    //    [XmlAttribute(AttributeName = "elementtype")]
    //    public string Elementtype { get; set; }

    //    [XmlAttribute(AttributeName = "id")]
    //    public string Id { get; set; }

    //    [XmlAttribute(AttributeName = "ref")]
    //    public string Ref { get; set; }
    //}

    //[XmlRoot(ElementName = "art")]
    //public class Art
    //{
    //    [XmlAttribute(AttributeName = "id")]
    //    public string Id { get; set; }

    //    [XmlElement(ElementName = "relation")]
    //    public Relation Relation { get; set; }

    //    [XmlElement(ElementName = "occurrence")]
    //    public List<Occurrence> Occurrence { get; set; }
    //}

    [XmlRoot(ElementName = "formattribute")]
    public class Formattribute
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "parmtype")]
        public string Parmtype { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "form")]
    public class Form
    {
        [XmlElement(ElementName = "formattribute")]
        public List<Formattribute> Formattribute { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "intermech")]
    public class Intermech
    {
        //[XmlElement(ElementName = "art")]
        //public List<Art> Art { get; set; }

        [XmlAttribute(AttributeName = "exp_user")]
        public string Exp_user { get; set; }

        [XmlElement(ElementName = "form")]
        public List<Form> ListOfForms { get; set; }
    }
}