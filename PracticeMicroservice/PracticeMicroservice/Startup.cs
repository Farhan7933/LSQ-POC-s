using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Runtime;

namespace PracticeMicroservice
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
            services.AddControllers();

            var credentials = new BasicAWSCredentials("ASIA6QDQG6WBAQ4PSVNZ", "NF1NE3mztjp7jd0YV2qLYtVKJXahsjoUqvg2pkn8");
            var config = new AmazonDynamoDBConfig()
            {
                RegionEndpoint = Amazon.RegionEndpoint.APSoutheast1
            };
            var client = new AmazonDynamoDBClient(credentials, config);

            services.AddSingleton<IAmazonDynamoDB>(client);
            services.AddTransient<IDynamoDBContext, DynamoDBContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
