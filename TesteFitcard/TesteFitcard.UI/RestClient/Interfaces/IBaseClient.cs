using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteFitcard.DominioViewModel;
using TesteFitcard.DominioViewModel.Filtros;

namespace TesteFitcard.UI.RestClient.Interfaces
{
    public interface IBaseClient<TEntity> where TEntity : class
    {
        /// <summary>
        /// Realiza uma chamada GET buscando um objeto pelo seu id.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(string url, string id);

        /// <summary>
        /// Realiza uma chamada GET buscando uma lista de objetos de acordo com filtro.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="filtro"></param>
        /// <returns></returns>
        ResponseViewModel<TEntity> GetFiltro(string url, object filtro);

        /// <summary>
        /// Realiza um POST.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        TEntity Post(string url, TEntity obj);

        /// <summary>
        /// Realiza um PUT.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        TEntity Put(string url, TEntity obj);

        /// <summary>
        /// Remove objetos.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="id"></param>
        void Delete(string url, string id);

        /// <summary>
        /// Retorna um SelectListItem. 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="filtro"></param>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetSelect(string url, object filtro);
    }
}
