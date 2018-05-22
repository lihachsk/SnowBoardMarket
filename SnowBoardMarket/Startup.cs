using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SnowBoardMarket.Helpers;
using SnowBoardMarket.Models;

namespace SnowBoardMarket
{
    public class Startup
    {
        private readonly IHostingEnvironment _environment;

        private readonly ILoggerFactory _loggerFactory;

        public IConfigurationRoot Configuration { get; }

        protected bool IsDevelopment { get; }

        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            _environment = env;

            _loggerFactory = loggerFactory;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                //builder.AddUserSecrets();
                this.IsDevelopment = env.IsDevelopment();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            X509Certificate2 cert = new X509Certificate2(Convert.FromBase64String("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"), "idsrv3test"); ;
            services.AddMvc(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    /*ReactHotModuleReplacement = true,
                    ConfigFile = "./webpack.config.js",
                    ProjectPath = "./wwwroot/dist"*/
                });
            }
            // подключаем URL Rewriting
            var options = new RewriteOptions().Add(new RewriterHelper()).AddRedirectToHttps();
            app.UseRewriter(options);

            app.UseStaticFiles();

            app.UseMvc(router =>
            {
                router.MapRoute("default", "{controller}/{action}/{Id?}");
                router.MapSpaFallbackRoute("spa-fallback", new { controller = "Home", action = "Index" });
            });
        }

        private X509Certificate2 GetSigningCertificate(string certificateThumb)
        {
            using (var certStore = new X509Store(StoreName.My, StoreLocation.CurrentUser))
            {
                certStore.Open(OpenFlags.ReadOnly);
                var certCollection = certStore.Certificates.Find(
                                           X509FindType.FindByThumbprint,
                                           certificateThumb,
                                           false);
                // Get the first cert with the thumbprint
                if (certCollection.Count > 0)
                {
                    return certCollection[0];
                }
            }

            return null;
        }
    }
}
