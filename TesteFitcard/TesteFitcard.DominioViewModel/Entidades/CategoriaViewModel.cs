
using TesteFitcard.DominioViewModel.Validadores;

namespace TesteFitcard.DominioViewModel.Entidades
{
    /// <summary>
    /// Classe que repreesenta a entidade Categoria (de estabelecimentos comerciais).
    /// </summary>
    [FluentValidation.Attributes.Validator(typeof(CategoriaViewModelValidador))]
    public class CategoriaViewModel : EntidadeBaseViewModel
    {
        public string NomeCategoria { get; set; }
    }
}
