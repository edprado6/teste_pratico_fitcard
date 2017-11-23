
using TesteFitcard.DominioViewModel.Validadores;

namespace TesteFitcard.DominioViewModel.Entidades
{
    /// <summary>
    /// Classe que representa a entidade Estabelecimento (comercial).
    /// </summary>
    [FluentValidation.Attributes.Validator(typeof(EstabelecimentoViewModelValidador))]
    public class EstabelecimentoViewModel : EntidadeBaseViewModel
    {       
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Ddd { get; set; }
        public string Telefone { get; set; }
        public string CategoriaId { get; set; }
        public virtual CategoriaViewModel Categoria { get; set; }
    }
}
