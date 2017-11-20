using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace TesteFitcard.WebApi
{
    public partial class Startup
    {
        /// <summary>
        /// Registra o gerador Swagger, definindo um ou mais documentos Swagger
        /// </summary>
        /// <param name="services"></param>
        private void AdicionarSwagger(ref IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = Resource.VersaoApi,
                    Title = Resource.TituloApi,
                    Description = Resource.DescricaoApi,
                    TermsOfService = "None",
                    Contact = new Contact { Name = Resource.NomeDesenvolvedor, Email = Resource.ContatoDesenvolvedor },
                    //License = new License { Name = "Use under LICX", Url = "https://example.com/license" }
                });
            });
        }

        /// <summary>
        /// Configura Swagger.
        /// </summary>
        /// <param name="app"></param>
        private void ConfigureSwagger(ref IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", Resource.TituloApi);
            });
        }
    }
}

