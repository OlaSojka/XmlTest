using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace XmlTest
{
    public class Question
    {
        [System.Xml.Serialization.XmlAttribute("ID")]
        public int Id;

        [System.Xml.Serialization.XmlElement("isConclusion")]
        public bool isConclusion;

        [System.Xml.Serialization.XmlElement("yes")]
        public int yes;

        [System.Xml.Serialization.XmlElement("no")]
        public int no;

        [System.Xml.Serialization.XmlElement("content")]
        public string content;

        public Question(int id, bool isConclusion, int yes, int no, string content)
        {
            Id = id;
            this.isConclusion = isConclusion;
            this.yes = yes;
            this.no = no;
            this.content = content;
        }
    }

    public class Source
    {
        [System.Xml.Serialization.XmlElement("linkDescription")]
        public string linkDesccription;

        [System.Xml.Serialization.XmlElement("link")]
        public string link;
    }

    [System.Xml.Serialization.XmlRoot("expertSystem")]
    public class ExpertSystem
    {
        [System.Xml.Serialization.XmlElement("title")]
        public string title;

        [System.Xml.Serialization.XmlElement("description")]
        public string description;

        [XmlArray("questions")]
        [XmlArrayItem("question", typeof(Question))]
        public List<Question> questions;

        [XmlArray("sources")]
        [XmlArrayItem("source", typeof(Source))]
        public List<Source> sources;


        public ExpertSystem()
        {
            this.title = "";
            this.description = "";
            this.questions = new List<Question>();
            this.sources = new List<Source>();
        }
    }
}
