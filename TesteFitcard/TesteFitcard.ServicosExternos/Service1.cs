using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TesteFitcard.ServicosExternos.WSCorreios;

namespace TesteFitcard.ServicosExternos
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "Service1" no arquivo de código e configuração ao mesmo tempo.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public consultaCEPResponse BuscaEndereco(string cep)
        {

            AtendeClienteClient _WsCorreiosSigep = new AtendeClienteClient();
            return _WsCorreiosSigep.consultaCEPAsync(cep).Result;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
