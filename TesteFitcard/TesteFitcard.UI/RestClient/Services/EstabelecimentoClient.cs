using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteFitcard.DominioViewModel.Entidades;
using TesteFitcard.UI.RestClient.Interfaces;

namespace TesteFitcard.UI.RestClient.Services
{
    /// <summary>
    /// Servico de interação com a entidade Estabelecimento.
    /// </summary>
    public class EstabelecimentoClient : BaseClient<EstabelecimentoViewModel>, IEstabelecimentoClient
    {
        /// <summary>
        /// Método construtor.
        /// </summary>
        public EstabelecimentoClient()
        {

        }
    }
}
