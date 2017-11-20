using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TesteFitcard.Dominio.Entidades;
using TesteFitcard.Dominio.Filtros;
using TesteFitcard.DominioViewModel.Entidades;
using TesteFitcard.DominioViewModel.Filtros;
using TesteFitcard.Servico.Entidades.Interfaces;

namespace TesteFitcard.WebApi.Controllers
{
    /// <summary>
    /// Classe que realiza interação com a entidade estabelecimento.
    /// </summary>
    [Route("api/[controller]")]
    public class EstabelecimentoController : Controller
    {
        private readonly IMapper _mapper;
        public IEstabelecimentoServico _estabelecimentoServico { get; private set; }

        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="estabelecimentoServico"></param>
        /// <param name="mapper"></param>
        public EstabelecimentoController(IEstabelecimentoServico estabelecimentoServico, IMapper mapper)
        {
            _estabelecimentoServico = estabelecimentoServico;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna uma lista de registros de acordo com filtro.
        /// </summary>
        /// <param name="filtroViewModel"></param>
        /// <returns></returns>              
        [HttpGet]
        public IActionResult Get(EstabelecimentoFiltroViewModel filtroViewModel)
        {
            try
            {
                EstabelecimentoFiltro filtro = _mapper.Map<EstabelecimentoFiltroViewModel, EstabelecimentoFiltro>(filtroViewModel);
                var registros = _estabelecimentoServico.Filtra(filtro);
                return Ok(new KeyValuePair<int, IEnumerable<EstabelecimentoViewModel>>(registros.Key, _mapper.Map<IEnumerable<Estabelecimento>, IEnumerable<EstabelecimentoViewModel>>(registros.Value)));
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Retorna um registro a partir de seu Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var estabelecimentoViewModel = _mapper.Map<Estabelecimento, EstabelecimentoViewModel>(_estabelecimentoServico.BuscaPorId(id));
                return Ok(estabelecimentoViewModel);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Recebe dados para inserção.
        /// </summary>
        /// <param name="estabelecimentoViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]EstabelecimentoViewModel estabelecimentoViewModel)
        {
            try
            {
                var estabelecimento = _mapper.Map<EstabelecimentoViewModel, Estabelecimento>(estabelecimentoViewModel);
                _estabelecimentoServico.Cadastra(estabelecimento);
                return Created("estabelecimento/post", estabelecimento);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " | " + e.InnerException.Message);
            }
        }

        /// <summary>
        /// Recebe um objeto para ser atualizado.
        /// </summary>
        /// <param name="estabelecimentoViewModel"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody]EstabelecimentoViewModel estabelecimentoViewModel)
        {
            try
            {
                var estabelecimento = _mapper.Map<EstabelecimentoViewModel, Estabelecimento>(estabelecimentoViewModel);
                _estabelecimentoServico.Atualiza(estabelecimento);
                return Ok(estabelecimento);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " | " + e.InnerException.Message);
            }
        }

        /// <summary>
        /// Realiza a exclusão de uma lista de registros.         
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(string[] id)
        {
            try
            {
                Func<Estabelecimento, bool> predicate = (entity => (Array.IndexOf(id, entity.Id) > -1));
                _estabelecimentoServico.Remove(predicate);
                return Ok();
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
