using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TesteFitcard.DominioViewModel;

namespace TesteFitcard.UI.RestClient.Interfaces
{
    public interface IBaseClient<TEntity> where TEntity : class
    {
        /// <summary>
        /// Realiza uma chamada GET buscando um objeto pelo seu id.
        /// </summary>       
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(string id);

        /// <summary>
        /// Realiza uma chamada GET buscando uma lista de objetos de acordo com filtro.
        /// </summary>        
        /// <param name="filtro"></param>
        /// <returns></returns>
        ResponseViewModel<TEntity> GetFiltro(object filtro);

        /// <summary>
        /// Realiza um POST.
        /// </summary>        
        /// <param name="obj"></param>
        /// <returns></returns>
        TEntity Post(TEntity obj);

        /// <summary>
        /// Realiza um PUT.
        /// </summary>       
        /// <param name="obj"></param>
        /// <returns></returns>
        TEntity Put(TEntity obj);

        /// <summary>
        /// Remove objetos.
        /// </summary>        
        /// <param name="id"></param>
        void Delete(string id);

        /// <summary>
        /// Retorna um SelectListItem. 
        /// </summary>       
        /// <param name="filtro"></param>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetSelect();
    }
}
