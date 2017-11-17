using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TesteFitcard.Repositorio.Interfaces;

namespace TesteFitcard.Repositorio.Repositorios
{

    /// <summary>
    /// Classe abstrata que implementa métodos genéricos de acesso ao DB.
    /// </summary>
    public abstract class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class
    {
        protected Contexto Db;

        public RepositorioBase(Contexto context)
        {
            Db = context;
        }

        /// <summary>
        /// Atualiza um registro.
        /// </summary>
        /// <param name="objeto"></param>
        public void Atualiza(TEntity objeto)
        {
            using (var db = new Contexto())
            {
                db.Entry(objeto).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Retorna uma lista de acordo com o predicate informado.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Busca(Expression<Func<TEntity, bool>> predicate)
        {
            var lista = Db.Set<TEntity>().AsNoTracking().Where(predicate.Compile()).ToList();
            return lista;
        }

        /// <summary>
        /// Busca objeto pelo seu Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity BuscaPorId(string id)
        {
            using (var db = new Contexto())
            {
                db.Set<TEntity>().AsNoTracking();
                return db.Set<TEntity>().Find(id);
            }
        }

        /// <summary>
        /// Retorna lista com todos registros.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> BuscaTodos()
        {
            using (var db = new Contexto())
            {
                var lista = db.Set<TEntity>().AsNoTracking().ToList();
                return lista;
            }
        }

        /// <summary>
        /// Insere registro.
        /// </summary>
        /// <param name="objeto"></param>
        public TEntity Cadastra(TEntity objeto)
        {
            using (var db = new Contexto())
            {
                db.Set<TEntity>().Add(objeto);
                db.SaveChanges();
                return objeto;
            }
        }

        /// <summary>
        /// Retorna uma lista de acordo com o filtro.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        //public KeyValuePair<int, IEnumerable<TEntity>> Filtra(FiltroBase<TEntity> filtro)
        //{
        //    var query = Db.Set<TEntity>().AsNoTracking().Where(filtro.predicate.Compile());
        //    var quantidadeRegistros = query.Count();
        //    var registros = query.Skip((filtro.pagina - 1) * filtro.registrosPorPagina).Take(filtro.registrosPorPagina);
        //    return new KeyValuePair<int, IEnumerable<TEntity>>(quantidadeRegistros, registros);
        //}

        /// <summary>
        /// Remove (remoção física) um registro.
        /// </summary>
        /// <param name="objeto"></param>
        public void Remove(TEntity objeto)
        {
            using (var db = new Contexto())
            {
                db.Set<TEntity>().Remove(objeto);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Remove (remoção física) varios registros de acordo com predicate.
        /// </summary>
        /// <param name="predicate"></param>
        public void Remove(Func<TEntity, bool> predicate)
        {
            using (var db = new Contexto())
            {
                db.Set<TEntity>().Where(predicate).ToList()
                    .ForEach(del => db.Set<TEntity>().Remove(del));
                db.SaveChanges();
            }
        }
    }
}
