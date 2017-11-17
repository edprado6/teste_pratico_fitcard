using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using TesteFitcard.Dominio.Entidades;
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
    }
}
