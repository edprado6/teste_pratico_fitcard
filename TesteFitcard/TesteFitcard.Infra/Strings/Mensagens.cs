using System;
using System.Collections.Generic;
using System.Text;

namespace TesteFitcard.Infra.Strings
{
    public class Mensagens
    {
        /// <summary>
        /// Retorna uma mensagem de sucesso.
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static string MensagemSucesso(string texto)
        {
            var mensagem = "<div class=\"alert alert-success\">" +
                                "<i class=\"fa fa-check\"></i>&nbsp;" + texto +
                            "</div>";

            return mensagem;
        }

        /// <summary>
        /// Retorna uma mensagem de sucesso.
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static string MensagemFalha(string texto)
        {
            var mensagem = "<div class=\"alert alert-danger\">" +
                                "<i class=\"fa fa-check\"></i>&nbsp;" + texto +
                            "</div>";

            return mensagem;
        }
    }
}
