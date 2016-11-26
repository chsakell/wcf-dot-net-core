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
                HostServices();
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

        static void HostServices()
        {
            using (var container = InitBuilder().Build())
            {
                // Create two different URIs to serve as the base address
                // One for http requests and another for net.tcp
                Uri httpUrl = new Uri("http://localhost:8090/BlogHttpService");
                Uri netTcpUrl = new Uri("net.tcp://localhost:8080/ArticleNetTcpService");

                //Create ServiceHost to host the service in the console application
                httpHost = new ServiceHost(typeof(BlogService), httpUrl);
                netTcpHost = new ServiceHost(typeof(ArticleService), netTcpUrl);

                // Enable metadata exchange - you need this so others can create proxies
                // to consume your WCF service
                ServiceMetadataBehavior httpServiceMetaBehavior = new ServiceMetadataBehavior();
                ServiceMetadataBehavior netTcpServiceMetaBehavior = new ServiceMetadataBehavior();
                httpHost.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
                httpHost.Description.Behaviors.Add(
                    new ServiceDebugBehavior { IncludeExceptionDetailInFaults = true });

                httpServiceMetaBehavior.HttpGetEnabled = true;
                httpHost.Description.Behaviors.Add(httpServiceMetaBehavior);
                netTcpHost.Description.Behaviors.Add(netTcpServiceMetaBehavior);

                netTcpHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");

                // Set dependency injection
                httpHost.AddDependencyInjectionBehavior<IBlogService>(container);
                netTcpHost.AddDependencyInjectionBehavior<IArticleService>(container);

                // Start the Services
                httpHost.Open();
                netTcpHost.Open();

                Console.WriteLine("IBlogService Service is host at " + DateTime.Now.ToString());
                Console.WriteLine("IArticleService Service is host at " + DateTime.Now.ToString());
                Console.WriteLine();

                Console.WriteLine("Press any key to terminate..");
                Console.ReadKey();

                if (httpHost != null && httpHost.State == CommunicationState.Opened)
                    httpHost.Close();

                if (netTcpHost != null && netTcpHost.State == CommunicationState.Opened)
                    netTcpHost.Close();
            }
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

            netTcpHost.Description.Behaviors.Add(serviceMetaBehavior);

            netTcpHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");

            // Set dependency injection
            netTcpHost.AddDependencyInjectionBehavior<IArticleService>(container);

            // Start the Service
            netTcpHost.Open();

            Console.WriteLine("IArticleService Service is host at " + DateTime.Now.ToString());
            Console.WriteLine();
        }
    }
}
