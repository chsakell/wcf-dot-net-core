using Autofac;
using Autofac.Integration.Wcf;
using Business.Services;
using Business.Services.Contracts;
using Data.Core.Infrastructure;
using Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Self.Host
{
    class Program
    {
        static ServiceHost httpHost, netTcpHost;
        static void Main(string[] args)
        {
            try
            {
                using (var container = InitBuilder().Build())
                {
                    Thread t1, t2;
                    t1 = new Thread(t => { HostHttpService(container); });
                    t2 = new Thread(t => { HostNetTcpService(container); });
                    t1.Start();
                    t2.Start();
                }

                Console.WriteLine("Press any key to terminate..");
                Console.ReadKey();

                if (httpHost != null && httpHost.State == CommunicationState.Opened)
                    httpHost.Close();

                if (netTcpHost != null && netTcpHost.State == CommunicationState.Opened)
                    netTcpHost.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static ContainerBuilder InitBuilder()
        {
            var builder = new ContainerBuilder();

            // register services
            builder.RegisterType<BlogService>().As<IBlogService>();
            builder.RegisterType<ArticleService>().As<IArticleService>();

            // register repositories and UnitOfWork
            builder.RegisterType<DbFactory>().As<IDbFactory>();
            builder.RegisterType<ArticleRepository>().As<IArticleRepository>();
            builder.RegisterType<BlogRepository>().As<IBlogRepository>();

            // build container
            return builder;
        }

        static void HostHttpService(IContainer container)
        {
            // Create two different URIs to serve as the base address
            // One for http requests and another for net.tcp
            Uri httpUrl = new Uri("http://localhost:8090/BlogHttpService");

            //Create ServiceHost to host the service in the console application
            httpHost = new ServiceHost(typeof(BlogService), httpUrl);

            // Enable metadata exchange - you need this so others can create proxies
            // to consume your WCF service
            ServiceMetadataBehavior serviceMetaBehavior = new ServiceMetadataBehavior();
            serviceMetaBehavior.HttpGetEnabled = true;
            httpHost.Description.Behaviors.Add(serviceMetaBehavior);

            // Set dependency injection
            httpHost.AddDependencyInjectionBehavior<IBlogService>(container);

            // Start the Service
            httpHost.Open();

            Console.WriteLine("IBlogService Service is host at " + DateTime.Now.ToString());
            Console.WriteLine();
        }

        static void HostNetTcpService(IContainer container)
        {
            // Create two different URIs to serve as the base address
            // One for http requests and another for net.tcp
            Uri netTcpUrl = new Uri("net.tcp://localhost:8080/ArticleNetTcpService");

            //Create ServiceHost to host the service in the console application
            netTcpHost = new ServiceHost(typeof(ArticleService), netTcpUrl);

            // Enable metadata exchange - you need this so others can create proxies
            // to consume your WCF service
            ServiceMetadataBehavior serviceMetaBehavior = new ServiceMetadataBehavior();
            //serviceMetaBehavior.HttpGetEnabled = true;
            netTcpHost.Description.Behaviors.Add(serviceMetaBehavior);

            // Set dependency injection
            netTcpHost.AddDependencyInjectionBehavior<IArticleService>(container);

            // Start the Service
            netTcpHost.Open();

            Console.WriteLine("IArticleService Service is host at " + DateTime.Now.ToString());
            Console.WriteLine();
        }
    }
}
