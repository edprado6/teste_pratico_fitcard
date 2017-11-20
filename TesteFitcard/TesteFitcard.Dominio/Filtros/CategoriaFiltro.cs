using System;
using System.Linq.Expressions;
using TesteFitcard.Dominio.Entidades;

namespace TesteFitcard.Dominio.Filtros
{
    /// <summary>
    /// Filtro customizado para categorias.
    /// </summary>
    public class CategoriaFiltro : FiltroBase<Categoria>
    {
        public string NomeCategoria { get; set; }        
        public bool? Ativo { get; set; }
        public override Expression<Func<Categoria, bool>> Predicate
        {
            get
            {
                return (u =>
                    (string.IsNullOrEmpty(NomeCategoria) || u.NomeCategoria.ToLower().Contains(NomeCategoria.ToLower()))                   
                    && (Ativo == null || u.Ativo == Ativo)
                    && (u.Excluido == false)
                );
            }
        }
    }
}
