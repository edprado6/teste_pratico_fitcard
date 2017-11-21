using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TesteFitcard.Infra.Validacoes;

namespace TesteFitcard.DominioViewModel.Filters
{
    public class CNPJAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var cnpj = Convert.ToString(value);

            // if (String.IsNullOrEmpty(cnpj))
            //   return true;

            return ValidaCNPJ.CnpjIsValid(cnpj);
        }
    }
}
