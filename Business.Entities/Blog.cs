using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    [DataContract(Namespace = "http://www.chsakell.com/dotnetcorewcfproxies")]
    public class Blog
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string URL { get; set; }
        [DataMember]
        public string Owner { get; set; }
    }
}
