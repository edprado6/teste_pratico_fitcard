using FluentValidation;
using TesteFitcard.DominioViewModel.Entidades;

namespace TesteFitcard.DominioViewModel.Validadores
{
    /// <summary>
    /// Classe responsável pela validação de dados da entidade Categoria.
    /// </summary>
    public class CategoriaViewModelValidador : AbstractValidator<CategoriaViewModel>
    {
        /// <summary>
        /// Validações customizadas.
        /// </summary>
        public CategoriaViewModelValidador()
        {
            RuleFor(x => x.NomeCategoria)
              .NotEmpty().WithMessage("O campo Nome da Categoria deve ser informado.");

        }
    }
}
