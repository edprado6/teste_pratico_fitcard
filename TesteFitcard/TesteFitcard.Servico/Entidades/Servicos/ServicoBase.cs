using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using TesteFitcard.Repositorio.Interfaces;
using TesteFitcard.Servico.Entidades.Interfaces;

namespace TesteFitcard.Servico.Entidades.Servicos
{
    /// <summary>
    /// Serviços genéricos.
    /// </summary>
    public abstract class ServicoBase<TEntity> : IServicoBase<TEntity> where TEntity : class
    {
        protected IRepositorioBase<TEntity> RepositorioBase;
        protected IHttpContextAccessor Context { get; set; }

        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="repositoryBase"></param>
        public ServicoBase(IRepositorioBase<TEntity> repositorioBase, IHttpContextAccessor context)
        {
            RepositorioBase = repositorioBase;
            Context = context;
        }

        /// <summary>
        /// Atualiza um registro.
        /// </summary>
        /// <param name="objeto"></param>
        public void Atualiza(TEntity objeto)
        {
            RepositorioBase.Atualiza(objeto);
        }

        /// <summary>
        /// Retorna um registro a partir do seu Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity BuscaPorId(string id)
        {
            return RepositorioBase.BuscaPorId(id);
        }

        /// <summary>
        /// Retorna uma lista com todos os registros.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> BuscaTodos()
        {
            return RepositorioBase.BuscaTodos();
        }

        /// <summary>
        /// Insere registro.
        /// </summary>
        /// <param name="objeto"></param>
        public TEntity Cadastra(TEntity objeto)
        {
            return RepositorioBase.Cadastra(objeto);
        }

        public void Remove(TEntity objeto)
        {
            RepositorioBase.Remove(objeto);
        }

        public void Remove(Func<TEntity, bool> predicate)
        {
            RepositorioBase.Remove(predicate);
        }

        /// <summary>
        /// Retorna uma lista e a quantidade de registros a partir de um filtro.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        //public KeyValuePair<int, IEnumerable<TEntity>> Filtra(FiltroBase<TEntity> filtro)
        //{
        //    return RepositorioBase.Filtra(filtro);
    }    
}
