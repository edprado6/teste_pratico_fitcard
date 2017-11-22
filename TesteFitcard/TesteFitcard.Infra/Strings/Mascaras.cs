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
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            return cnpj;
        }

        /// <summary>
        /// Recebe um status e retorna Ativo ou Inativo.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string RetornaAtivoInativo(bool status) {
            
            return (status) ? "<span class=\"label label-success\">Ativo</span>" : "<span class=\"label label-danger\">Inativo</span>";
        }

    }
}
