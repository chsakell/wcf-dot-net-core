using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public HomeController(Connected.Service.BlogService.IBlogService blogHttpClient,
            Connected.Service.ArticleService.IArticleService articleNetTcpClient,
            External.Lib.IBlogService blogHttpClientExt,
            External.Lib.IArticleService articleNetTcpClientExt)
        {
            _blogHttpClient = blogHttpClient;
            _articleNetTcpClient = articleNetTcpClient;

            _blogHttpClientExt = blogHttpClientExt;
            _articleNetTcpClientExt = articleNetTcpClientExt;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            Connected.Service.BlogService.Blog _blog = GetBlog();
            ViewBag.Blog = _blog;
            var firstBlog = GetBlog(1);

            //Connected.Service.ArticleService.Article[] _articles = GetArticles();
            External.Lib.Article[] _articles = GetArticlesExt();
            return View(_articles);
        }

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
    }
}
