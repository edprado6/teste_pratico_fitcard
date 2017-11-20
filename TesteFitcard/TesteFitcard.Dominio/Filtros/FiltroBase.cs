using System;
using System.Linq.Expressions;

namespace TesteFitcard.Dominio.Filtros
{

    /// <summary>
    /// Classe generica de filtro.
    /// </summary>
    public abstract class FiltroBase<TEntity> where TEntity : class
    {
        public int RegistrosPorPagina { get; set; }

        public int Pagina { get; set; }

        public virtual Expression<Func<TEntity, bool>> Predicate { get; }
    }
}
