using System;

namespace TesteFitcard.Infra.Strings
{
    /// <summary>
    /// Classe de manipulação de strings responsável por colocar e retirar máscaras.
    /// </summary>
    public class Mascaras
    {
        /// <summary>
        /// Retira a máscara de um CNPJ.
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public static string RetiraMascaraCNPJ(string cnpj) {

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "").Replace("_", "");

            return cnpj;
        }
            
        /// <summary>
        /// Retorna um número de CNPJ com máscara para exibição.
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public static string MascaraCNPJ(string cnpj) {

            return Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
        }

        /// <summary>
        /// Recebe um status e retorna Ativo ou Inativo.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string RetornaAtivoInativo(bool status) {
            
            return (status) ? "<span class=\"label label-success\">Ativo</span>" : "<span class=\"label label-danger\">Inativo</span>";
        }

        /// <summary>
        /// Retorna concatenação de ddd e telefone.
        /// </summary>
        /// <param name="ddd"></param>
        /// <param name="telefone"></param>
        /// <returns></returns>
        public static string RetornaTelefone(string ddd, string telefone) {

            string stringTelefone = "";

            if (ddd != null) {

                stringTelefone += "(" + ddd + ") ";
            }
            if (telefone != null) {

                stringTelefone += telefone;
            }

            return stringTelefone;
        }

        /// <summary>
        /// Retorna uma string contendo o endereco. 
        /// </summary>
        /// <param name="contato"></param>
        /// <returns></returns>
        public static string RetornaEndereco(string endereco, int numero, string complemento)
        {
            var stringNumero = (numero > 0) ? ", " + numero.ToString() : "";
            endereco = endereco ?? "";
            complemento = (complemento != null ) ? ", " + complemento : "";

            return endereco + stringNumero + complemento;
        }

    }
}
