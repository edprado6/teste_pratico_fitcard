namespace TesteFitcard.DominioViewModel.Filtros
{
    /// <summary>
    /// Filtro customizado para categorias.
    /// </summary>
    public class CategoriaFiltroViewModel : FiltroBaseViewModel
    {
        public string NomeCategoria { get; set; }
        public bool? Ativo { get; set; }
    }
}
