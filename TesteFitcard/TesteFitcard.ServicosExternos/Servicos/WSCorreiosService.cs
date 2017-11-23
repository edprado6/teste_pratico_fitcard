using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFitcard.ServicosExternos.WSCorreios;

namespace TesteFitcard.ServicosExternos.Servicos
{
    public class WSCorreiosService
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
