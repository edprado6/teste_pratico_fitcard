using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TesteFitcard.Dominio.Entidades;
using TesteFitcard.Dominio.Filtros;

namespace TesteFitcard.Servico.Entidades.Interfaces
{
    /// <summary>
    /// Interface de CategoriaServico
    /// </summary>
    public interface ICategoriaServico : IServicoBase<Categoria>
    {
        /// <summary>
        /// Retorna um SelectListem contendo as categorias ativas para montagem de select.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        IEnumerable<SelectListItem> Select();
    }
}
