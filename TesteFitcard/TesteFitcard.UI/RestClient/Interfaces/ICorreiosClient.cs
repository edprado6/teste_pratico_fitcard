using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteFitcard.UI.RestClient.Interfaces
{
    public interface ICorreiosClient
    {
        /// <summary>
        /// Realiza uma chamada GET buscando um endereço a partir do CEP.
        /// </summary>       
        /// <param name="cep"></param>
        /// <returns></returns>
        dynamic BuscaEndereco(string cep);
    }
}
