using Microsoft.AspNetCore.Http;
using System.Linq;
using TesteFitcard.Dominio.Entidades;
using TesteFitcard.Dominio.Filtros;
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

        /// <summary>
        /// Insere registro.
        /// </summary>
        /// <param name="estabelecimento"></param>
        public new Estabelecimento Cadastra(Estabelecimento estabelecimento)
        {
            EstabelecimentoFiltro filtro = new EstabelecimentoFiltro()
            {
                Cnpj = estabelecimento.Cnpj
            };

            var existeEstabelecimento = EstabelecimentoRepository.Busca(filtro.Predicate).FirstOrDefault();

            if (existeEstabelecimento != null)
            {
                estabelecimento.Id = existeEstabelecimento.Id;
                estabelecimento.Excluido = (estabelecimento.Excluido) ? false : estabelecimento.Excluido;
                estabelecimento.DataExclusao = null;

                return EstabelecimentoRepository.Atualiza(estabelecimento);
            }
            else
            {
                return EstabelecimentoRepository.Cadastra(estabelecimento);
            }
        }
    }
}
