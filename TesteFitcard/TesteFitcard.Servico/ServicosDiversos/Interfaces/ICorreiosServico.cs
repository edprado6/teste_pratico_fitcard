using System;
using System.Collections.Generic;
using System.Text;
using WSCorreios;

namespace TesteFitcard.Servico.ServicosDiversos.Interfaces
{
    public interface ICorreiosServico
    {
        /// <summary>
        /// Busca um endereço a partir de um CEP.
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        consultaCEPResponse BuscaEndereco(string cep);
    }
}
