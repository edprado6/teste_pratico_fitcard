using System;
using System.Collections.Generic;
using System.Text;
using TesteFitcard.Dominio.Entidades;
using TesteFitcard.Repositorio.Interfaces;

namespace TesteFitcard.Repositorio.Repositorios
{
    /// <summary>
    /// Classe de acesso ao DB da entidade Categoria.
    /// </summary>
    public class CategoriaRepositorio : RepositorioBase<Categoria>, ICategoriaRepositorio
    {
        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="context"></param>
        public CategoriaRepositorio(Contexto context) : base(context)
        {

        }
    }

}
