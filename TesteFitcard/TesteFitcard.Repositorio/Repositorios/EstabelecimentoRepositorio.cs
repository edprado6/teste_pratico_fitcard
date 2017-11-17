using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
