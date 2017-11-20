using TesteFitcard.DominioViewModel.Entidades;
using TesteFitcard.UI.RestClient.Interfaces;

namespace TesteFitcard.UI.RestClient.Services
{
    /// <summary>
    /// Servico de interação com a entidade Categoria.
    /// </summary>
    public class CategoriaClient : BaseClient<CategoriaViewModel>, ICategoriaClient
    {
        /// <summary>
        /// Método construtor.
        /// </summary>
        public CategoriaClient()
        {

        }
    }
}
