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

namespace API.Gateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var endpointConfiguration = new EndpointConfiguration("API.Gateway");
            var transport = endpointConfiguration.UseTransport<LearningTransport>();
            var routing = transport.Routing();
            routing.RouteToEndpoint(
                typeof(CreateEnrollment), "EnrollmentService");

            var endpointInstance = Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult();
            services.AddSingleton<IMessageSession>(endpointInstance);
            services.AddMvc();
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
