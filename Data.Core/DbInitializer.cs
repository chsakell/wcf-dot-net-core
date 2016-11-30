using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Core
{
    public class DbInitializer : CreateDatabaseIfNotExists<DIContext>
    {
        protected override void Seed(DIContext context)
        {
            base.Seed(context);

            context.BlogSet.Add(new Business.Entities.Blog
            {
                Name = "chsakell's blog",
                URL = "http://chsakell.com",
                Owner = "Christos Sakellarios"
            });

            context.ArticleSet.Add(new Business.Entities.Article
            {
                Title = "Real-time applications using ASP.NET Core, SignalR & Angular",
                Contents = "Real-time web applications are apps that push user experience to the limits while trying to immediately reflect data changes to a great number of connected clients..",
                Author = "Christos Sakellarios",
                URL = "http://wp.me/p3mRWu-1b2",
                BlogID = 1
            });

            context.ArticleSet.Add(new Business.Entities.Article
            {
                Title = "Cross-platform Single Page Applications with ASP.NET Core, Angular 2 & TypeScript",
                Contents = "ASP.NET Core 1.0 and Angular 2 are probably the hottest new frameworks in terms of both of them are entirely re-written from scratch..",
                Author = "Christos Sakellarios",
                URL = "http://wp.me/p3mRWu-11L",
                BlogID = 1
            });

            context.ArticleSet.Add(new Business.Entities.Article
            {
                Title = "Angular CRUD ops, Modals, Animations, Pagination, DateTimePicker, Directives and much more..",
                Contents = "Angular 2 and TypeScript have fetched client-side development to the next level but till recently most of web developers hesitated to start a production SPA with those two..",
                Author = "Christos Sakellarios",
                URL = "http://wp.me/p3mRWu-199",
                BlogID = 1
            });

            context.ArticleSet.Add(new Business.Entities.Article
            {
                Title = "WCF Dependency Injection",
                Contents = "Dependency injection is a software design pattern that implements..",
                Author = "Christos Sakellarios",
                URL = "https://chsakell.com/2015/07/03/dependency-injection-in-wcf/",
                BlogID = 1
            });

            context.SaveChanges();
        }
    }
}
