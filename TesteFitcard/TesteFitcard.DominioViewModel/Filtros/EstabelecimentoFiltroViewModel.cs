namespace TesteFitcard.DominioViewModel.Filtros
{
    /// <summary>
    /// Filtro customizado para estabelecimentos.
    /// </summary>
    public class EstabelecimentoFiltroViewModel : FiltroBaseViewModel
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public bool? Ativo { get; set; }
    }
}
