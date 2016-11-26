using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract(Namespace = "http://www.chsakell.com/dotnetcorewcfproxies")]
    public class Article
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Contents { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public string URL { get; set; }
        [DataMember]
        public int BlogID { get; set; }
    }
}
