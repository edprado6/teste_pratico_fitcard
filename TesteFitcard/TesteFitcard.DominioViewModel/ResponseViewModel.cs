using System.Collections.Generic;

namespace TesteFitcard.DominioViewModel
{
    /// <summary>
    /// Classe de resposta dos métodos de preenchimento de grids.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class ResponseViewModel<TEntity>
    {
        /// <summary>
        /// Total de registros de acordo com um filtro.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Registros de uma busca utilizando filtro.
        /// </summary>
        public IEnumerable<TEntity> Registros { get; set; }
    }
}
