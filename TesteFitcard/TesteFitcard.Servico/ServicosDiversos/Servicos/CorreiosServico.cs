using System;
using System.Collections.Generic;
using System.Text;
using TesteFitcard.Servico.ServicosDiversos.Interfaces;
using WSCorreios;

namespace TesteFitcard.Servico.ServicosDiversos.Servicos
{
    /// <summary>
    /// Classe reponsável pelos métodos que consomem os serviços dos Correios.
    /// </summary>
    public class CorreiosServico : ICorreiosServico
    {
        /// <summary>
        /// Retorna um endereço a partir de um CEP.
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        public consultaCEPResponse BuscaEndereco(string cep)
        {

            AtendeClienteClient _WsCorreiosSigep = new AtendeClienteClient();
            return _WsCorreiosSigep.consultaCEPAsync(cep).Result;
        }
    }
}
