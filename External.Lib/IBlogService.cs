using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace External.Lib
{
    [ServiceContract(Namespace = "http://www.chsakell.com/dotnetcorewcfproxies")]
    public interface IBlogService
    {
        [OperationContract]
        Task AddAsync(Blog blog);

        [OperationContract]
        Task UpdateAsync(Blog blog);

        [OperationContract]
        Task DeleteAsync(Blog blog);

        [OperationContract]
        Task<Blog> GetByIdAsync(int id);
    }

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
