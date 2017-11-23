using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using TesteFitcard.Dominio.Entidades;
using TesteFitcard.Repositorio.Interfaces;

namespace TesteFitcard.Repositorio.Repositorios
{
    /// <summary>
    /// Classe de acesso ao DB da entidade estebelecimento.
    /// </summary>
    public class EstabelecimentoRepositorio : RepositorioBase<Estabelecimento>, IEstabelecimentoRepositorio
    {
        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="context"></param>
        public EstabelecimentoRepositorio(Contexto context) : base(context)
        {
           
        }

        /// <summary>
        /// Busca um estabelecimento pelo seu Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public new Estabelecimento BuscaPorId(string id)
        {
            Expression<Func<Estabelecimento, bool>> predicate;
            predicate = (l => l.Excluido == false && l.Id == id);

            using (var db = new Contexto())
            {
                var estabelecimento = db.Estabelecimento
                                        .Include("Categoria")                                
                                        .Where(predicate.Compile())
                                        .FirstOrDefault();

                return estabelecimento;
            }
        }
    }
}
