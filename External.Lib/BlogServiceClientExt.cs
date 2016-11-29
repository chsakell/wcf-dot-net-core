using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace External.Lib
{
    public class BlogServiceClientExt : ClientBase<IBlogService>, IBlogService
    {
        #region Constructors
        public BlogServiceClientExt(string endpoint)
            : base(endpoint)
        { }

        public BlogServiceClientExt(Binding binding, EndpointAddress address)
            : base(binding, address)
        { }

        #endregion

        #region IBlogService implementation
        Task IBlogService.AddAsync(Blog blog)
        {
            return Channel.AddAsync(blog);
        }

        Task IBlogService.DeleteAsync(Blog blog)
        {
            return Channel.DeleteAsync(blog);
        }

        Task<Blog> IBlogService.GetByIdAsync(int id)
        {
            return Channel.GetByIdAsync(id);
        }

        Task IBlogService.UpdateAsync(Blog blog)
        {
            return Channel.UpdateAsync(blog);
        }

        Task IBlogService.OpenAsync()
        {
            return Task.Factory.FromAsync(((ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((ICommunicationObject)(this)).EndOpen));
        }

        Task IBlogService.CloseAsync()
        {
            return Task.Factory.FromAsync(((ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((ICommunicationObject)(this)).EndClose));
        }
        #endregion
    }
}
