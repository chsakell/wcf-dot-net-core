using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace External.Lib
{
    public class ArticleServiceClientExt : ClientBase<IArticleService>, IArticleService
    {
        #region Constructors
        public ArticleServiceClientExt(string endpoint)
            : base(endpoint)
        { }

        public ArticleServiceClientExt(Binding binding, EndpointAddress address)
            : base(binding, address)
        { }
        #endregion

        #region IArticleServiceExt implementation

        Task IArticleService.AddAsync(Article article)
        {
            return Channel.AddAsync(article);
        }

        Task IArticleService.DeleteAsync(Article article)
        {
            return Channel.DeleteAsync(article);
        }

        Task<Article[]> IArticleService.GetAllAsync()
        {
            return Channel.GetAllAsync();
        }

        Task<Article> IArticleService.GetByIdAsync(int id)
        {
            return Channel.GetByIdAsync(id);
        }

        Task IArticleService.UpdateAsync(Article article)
        {
            return Channel.UpdateAsync(article);
        }

        #endregion
    }
}
