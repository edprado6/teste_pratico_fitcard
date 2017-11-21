using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MySQL.Data.EntityFrameworkCore.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TesteFitcard.DominioViewModel.Validadores;
using TesteFitcard.Servico;


namespace TesteFitcard.WebApi
{
    public partial class Startup
    {
        /// <summary>
        /// Inicialização
        /// </summary>
        /// <param name="env"></param>
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

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// 
        /// Esse método é chamado em tempo de execução. Use esse método para adicionar serviços ao container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            // Adicionando servicos do framework
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    // handle loops correctly
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                    // use standard name conversion of properties
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                    // include $id property in the output
                    //options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                });

            services.AddMvc().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<EstabelecimentoViewModelValidador>());
            services.AddMvc().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CategoriaViewModelValidador>());

            var sqlConnectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<Repositorio.Contexto>(options =>
                options.UseMySQL(
                    sqlConnectionString,
                    b => b.MigrationsAssembly("TesteFitcard.WebApi")
                )
            );
           
            services.AddAutoMapper();            
            AdicionarSwagger(ref services);
            InjecaoDependencia.InjecaoDependenciaRepositorios(ref services);
            InjecaoDependencia.InjecaoDependenciaservicos(ref services);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors("CorsPolicy");
                        
            app.UseMvc();

            app.UseStaticFiles();
            
            ConfigureSwagger(ref app);
        }
    }
}
