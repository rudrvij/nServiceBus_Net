using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NServiceBus;
using Prototype.Messages;
using Prototype.Document.Service.Repository;
using Autofac;
using NServiceBus.Logging;
using Autofac.Extensions.DependencyInjection;

namespace Prototype.Document.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var builder = new ContainerBuilder();

            builder.RegisterType<DocumentRepository>().As<IDocumentRepository>();
            builder.RegisterType<DocumentService>().As<IDocumentService>();

            builder.Register(c => LogManager.GetLogger("Document"))
            .As<ILog>()
            .SingleInstance();


            IEndpointInstance endpoint = null;
            builder.Register(c => endpoint)
                .As<IEndpointInstance>()
                .SingleInstance();

            builder.Register(c => endpoint).As<IMessageSession>().SingleInstance();

            builder.Populate(services);

            var container = builder.Build();

            var endpointConfiguration = new EndpointConfiguration("DocumentService");
            var transport = endpointConfiguration.UseTransport<LearningTransport>();
            endpointConfiguration.UseContainer<AutofacBuilder>(
               customizations: customizations =>
               {
                   customizations.ExistingLifetimeScope(container);
               });

            endpoint = Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult();
            //services.AddSingleton<IMessageSession>(endpoint);

            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
