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
        External.Lib.IArticleService _articleNetTcpClientExt;
        #endregion
        public HomeController(Connected.Service.BlogService.IBlogService blogHttpClient,
            Connected.Service.ArticleService.IArticleService articleNetTcpClient,
            External.Lib.IArticleService articleNetTcpClientExt)
        {
            _blogHttpClient = blogHttpClient;
            _articleNetTcpClient = articleNetTcpClient;

            _articleNetTcpClientExt = articleNetTcpClientExt;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            Connected.Service.BlogService.Blog _blog = GetBlog();
            ViewBag.Blog = _blog;

            //Connected.Service.ArticleService.Article[] _articles = GetArticles();
            External.Lib.Article[] _articles = GetArticlesExt();
            return View(_articles);
        }

        private Connected.Service.BlogService.Blog GetBlog()
        {
            return _blogHttpClient.GetByIdAsync(1).Result;
        }

        private Connected.Service.ArticleService.Article[] GetArticles()
        {
            return _articleNetTcpClient.GetAllAsync().Result;
        }

        private External.Lib.Article[] GetArticlesExt()
        {
            return _articleNetTcpClientExt.GetAllAsync().Result;
        }
    }
}
