using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TesteFitcard.DominioViewModel.Entidades;
using TesteFitcard.Infra.Validacoes;

namespace TesteFitcard.DominioViewModel.Validadores
{
    /// <summary>
    /// Classe responsável pela validação de dados da entidade Estabelecimento.
    /// </summary>
    public class EstabelecimentoViewModelValidador : AbstractValidator<EstabelecimentoViewModel>
    {
        /// <summary>
        /// Validações customizadas.
        /// </summary>
        public EstabelecimentoViewModelValidador()
        {            
            RuleFor(x => x.RazaoSocial)
               .NotEmpty().WithMessage("O campo Razão Social deve ser informado.");
            
            RuleFor(c => c.Email)            
             .EmailAddress().WithMessage("E-mail inválido.");

            RuleFor(c => c.Cnpj)
             .NotEmpty().WithMessage("O campo CNPJ deve ser informado.")
             .Must(VerificaCNPJ).WithMessage("CNPJ informado não é válido.");

            RuleFor(c => c.CategoriaId).NotNull().WithMessage("A Categoria deve ser informada.");
        }

        /// <summary>
        /// Chama o método da infra responsável pela validação do campo de CNPJ.
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        private static bool VerificaCNPJ(string value)
        {
            var cnpj = Convert.ToString(value);
            return ValidaCNPJ.CnpjIsValid(cnpj);
        }
    }
}
