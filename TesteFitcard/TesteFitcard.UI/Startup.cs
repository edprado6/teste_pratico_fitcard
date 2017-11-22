using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TesteFitcard.UI.RestClient.Interfaces;
using TesteFitcard.UI.RestClient.Services;
using FluentValidation.AspNetCore;
using TesteFitcard.DominioViewModel.Validadores;

namespace TesteFitcard.UI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            InjecaoDependenciaServicosRest(ref services);
            Validadores(ref services);

            // Add framework services.
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        /// <summary>
        /// Adiciona a injeção de dependência entre os serviços e suas interfaces.
        /// </summary>
        /// <param name="services"></param>
        public static void InjecaoDependenciaServicosRest(ref IServiceCollection services)
        {
            services.AddSingleton<ICategoriaClient, CategoriaClient>();
            services.AddSingleton<IEstabelecimentoClient, EstabelecimentoClient>();
        }

        /// <summary>
        /// Instancia as classes de validação.
        /// </summary>
        /// <param name="services"></param>
        public static void Validadores(ref IServiceCollection services) {

            services.AddMvc().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<EstabelecimentoViewModelValidador>());
            services.AddMvc().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CategoriaViewModelValidador>());
        }
    }
}
