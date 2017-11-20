using System;
using System.Linq.Expressions;
using TesteFitcard.Dominio.Entidades;

namespace TesteFitcard.Dominio.Filtros
{
    /// <summary>
    /// Filtro customizado para estabelecimentos.
    /// </summary>
    public class EstabelecimentoFiltro : FiltroBase<Estabelecimento>
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public bool? Ativo { get; set; }
        public override Expression<Func<Estabelecimento, bool>> Predicate
        {
            get
            {
                return (u =>
                    (string.IsNullOrEmpty(RazaoSocial) || u.RazaoSocial.ToLower().Contains(RazaoSocial.ToLower()))
                    && (string.IsNullOrEmpty(NomeFantasia) || u.NomeFantasia.ToLower().Contains(NomeFantasia.ToLower()))
                    && (string.IsNullOrEmpty(Cnpj) || u.Cnpj.ToLower().Contains(Cnpj.ToLower()))
                    && (Ativo == null || u.Ativo == Ativo)
                    && (u.Excluido == false)
                );
            }
        }
    }
}
