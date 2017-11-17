using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using TesteFitcard.Dominio.Entidades;
using TesteFitcard.Repositorio.Interfaces;
using TesteFitcard.Servico.Entidades.Interfaces;

namespace TesteFitcard.Servico.Entidades.Servicos
{
    public class EstabelecimentoServico : ServicoBase<Estabelecimento>, IEstabelecimentoServico
    {
        public IEstabelecimentoRepositorio EstabelecimentoRepository { get; private set; }

        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="estabelecimentoRepository"></param>
        public EstabelecimentoServico(IEstabelecimentoRepositorio estabelecimentoRepository, IHttpContextAccessor context) : base(estabelecimentoRepository, context)
        {
            EstabelecimentoRepository = estabelecimentoRepository;
        }
    }
}
