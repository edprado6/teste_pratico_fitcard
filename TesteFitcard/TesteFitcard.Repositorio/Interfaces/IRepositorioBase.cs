using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TesteFitcard.Dominio.Filtros;

namespace TesteFitcard.Repositorio.Interfaces
{
    /// <summary>
    /// Interface do repositório base.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// Atualiza um registro.
        /// </summary>
        /// <param name="objeto"></param>
        void Atualiza(TEntity objeto);

        /// <summary>
        /// Retorna uma lista de acordo com o predicate informado.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Busca(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Busca objeto pelo seu Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity BuscaPorId(string id);

        /// <summary>
        /// Retorna lista com todos registros.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> BuscaTodos();

        /// <summary>
        /// Insere registro.
        /// </summary>
        /// <param name="objeto"></param>
        TEntity Cadastra(TEntity objeto);

        /// <summary>
        /// Retorna uma lista de acordo com o filtro.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        KeyValuePair<int, IEnumerable<TEntity>> Filtra(FiltroBase<TEntity> filtro);

        /// <summary>
        /// Remove um registro.
        /// </summary>
        /// <param name="objeto"></param>
        void Remove(TEntity objeto);

        /// <summary>
        /// Remove varios registros
        /// </summary>
        /// <param name="predicate"></param>
        void Remove(Func<TEntity, bool> predicate);

    }
}
