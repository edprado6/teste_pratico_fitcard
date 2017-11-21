using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteFitcard.Dominio.Entidades;
using TesteFitcard.Dominio.Filtros;
using TesteFitcard.Repositorio.Interfaces;
using TesteFitcard.Servico.Entidades.Interfaces;

namespace TesteFitcard.Servico.Entidades.Servicos
{
    public class CategoriaServico : ServicoBase<Categoria>, ICategoriaServico
    {
        public ICategoriaRepositorio CategoriaRepository { get; private set; }

        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="categoriaRepository"></param>
        public CategoriaServico(ICategoriaRepositorio categoriaRepository, IHttpContextAccessor context) : base(categoriaRepository, context)
        {
            CategoriaRepository = categoriaRepository;
        }

        /// <summary>
        /// Retorna um SelectListem contendo as categorias ativas para montagem de select.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public IEnumerable<SelectListItem> Select(CategoriaFiltro filtro)
        {
            
            var categorias = CategoriaRepository.Busca(filtro.Predicate);
            var select = categorias.Select(x => new SelectListItem()
            {
                Text = x.NomeCategoria,
                Value = x.Id
            });

            return select;
        }
    }
}
