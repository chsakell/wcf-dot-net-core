using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.App.Controllers
{
    public class HomeController : Controller
    {
        Connected.Service.BlogService.IBlogService _blogHttpClient;
        Connected.Service.ArticleService.IArticleService _articleNetTcpClient;
        public HomeController(Connected.Service.BlogService.IBlogService blogHttpClient,
            Connected.Service.ArticleService.IArticleService articleNetTcpClient)
        {
            _blogHttpClient = blogHttpClient;
            _articleNetTcpClient = articleNetTcpClient;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            Connected.Service.BlogService.Blog _blog = GetBlog();
            Connected.Service.ArticleService.Article[] _articles = GetArticles();
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
    }
}
