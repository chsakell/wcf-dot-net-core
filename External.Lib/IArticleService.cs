using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace External.Lib
{
    public interface IArticleService
    {

        [OperationContract]
        Task AddAsync(Article article);

        [OperationContract]
        Task UpdateAsync(Article article);

        [OperationContract]
        Task DeleteAsync(Article article);

        [OperationContract]
        Task<Article> GetByIdAsync(int id);

        [OperationContract]
        Task<Article[]> GetAllAsync();
    }

    [DataContract]
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
