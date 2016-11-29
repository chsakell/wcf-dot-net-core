using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Core.App.Controllers
{
    public class HomeController : Controller
    {
        #region Connected Service clients
        Connected.Service.BlogService.IBlogService _blogHttpClient;
        Connected.Service.ArticleService.IArticleService _articleNetTcpClient;
        #endregion

        #region External Clients
        External.Lib.IBlogService _blogHttpClientExt;
        External.Lib.IArticleService _articleNetTcpClientExt;
        #endregion

        #region Constructor
        public HomeController(Connected.Service.BlogService.IBlogService blogHttpClient,
            Connected.Service.ArticleService.IArticleService articleNetTcpClient)
        {
            _blogHttpClient = blogHttpClient;
            _articleNetTcpClient = articleNetTcpClient;

            _blogHttpClientExt = new External.Lib.BlogServiceClientExt(new BasicHttpBinding(), 
                new EndpointAddress("http://localhost:8090/BlogHttpService"));
            _articleNetTcpClientExt = new External.Lib.ArticleServiceClientExt(new NetTcpBinding(), 
                new EndpointAddress("net.tcp://localhost:8080/ArticleNetTcpService"));
        }
        #endregion

        #region Actions
        // GET: /<controller>/
        public IActionResult Index()
        {
            Connected.Service.BlogService.Blog _blog = GetBlog();
            ViewBag.Blog = _blog;
            var firstBlog = GetBlog(1);

            //Connected.Service.ArticleService.Article[] _articles = GetArticles();
            External.Lib.Article[] _articles = GetArticlesExt();

            // Close External Clients
            CloseWcfClients();

            return View(_articles);
        }
        #endregion

        #region Connected Service methods

        private Connected.Service.BlogService.Blog GetBlog()
        {
            return _blogHttpClient.GetByIdAsync(1).Result;
        }

        private Connected.Service.ArticleService.Article[] GetArticles()
        {
            return _articleNetTcpClient.GetAllAsync().Result;
        }

        #endregion

        #region External Clients methods

        private External.Lib.Article[] GetArticlesExt()
        {
            return _articleNetTcpClientExt.GetAllAsync().Result;
        }

        private External.Lib.Blog GetBlog(int id)
        {
            return _blogHttpClientExt.GetByIdAsync(id).Result;
        }

        #endregion  

        /// <summary>
        /// Always make sure to close clients
        /// </summary>
        void CloseWcfClients()
        {
            _blogHttpClientExt.CloseAsync();
            _articleNetTcpClientExt.CloseAsync();
        }
    }
}
