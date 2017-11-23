using Microsoft.Extensions.DependencyInjection;
using TesteFitcard.Repositorio.Interfaces;
using TesteFitcard.Repositorio.Repositorios;
using TesteFitcard.Servico.Entidades.Interfaces;
using TesteFitcard.Servico.Entidades.Servicos;
using TesteFitcard.Servico.ServicosDiversos.Interfaces;
using TesteFitcard.Servico.ServicosDiversos.Servicos;

namespace TesteFitcard.Servico
{
    /// <summary>
    /// Classe que implementa a injeção de dependência.
    /// </summary>
    public class InjecaoDependencia
    {

        /// <summary>
        /// Adiciona a injeção de dependência entre os repositorios e suas interfaces.
        /// </summary>
        /// <param name="services"></param>
        public static void InjecaoDependenciaRepositorios(ref IServiceCollection services)
        {
            services.AddSingleton<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddSingleton<IEstabelecimentoRepositorio, EstabelecimentoRepositorio>();
        }

        /// <summary>
        /// Adiciona a injeção de dependência entre os serviços e suas interfaces.
        /// </summary>
        /// <param name="services"></param>
        public static void InjecaoDependenciaservicos(ref IServiceCollection services)
        {
            services.AddSingleton<ICategoriaServico, CategoriaServico>();           
            services.AddSingleton<IEstabelecimentoServico, EstabelecimentoServico>();

            // Serviços externos
            services.AddSingleton<ICorreiosServico, CorreiosServico>();
        }
    }
}
