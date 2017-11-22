using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TesteFitcard.Dominio.Entidades;
using TesteFitcard.Dominio.Filtros;
using TesteFitcard.DominioViewModel;
using TesteFitcard.DominioViewModel.Entidades;
using TesteFitcard.DominioViewModel.Filtros;
using TesteFitcard.Servico.Entidades.Interfaces;
using TesteFitcard.WebApi.Filters;

namespace TesteFitcard.WebApi.Controllers
{
    /// <summary>
    /// Classe que realiza interação com a entidade categoria.
    /// </summary>
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        private readonly IMapper _mapper;
        public ICategoriaServico _categoriaServico { get; private set; }

        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="categoriaServico"></param>
        /// <param name="mapper"></param>
        public CategoriaController(ICategoriaServico categoriaServico, IMapper mapper)
        {
            _categoriaServico = categoriaServico;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna uma lista de registros de acordo com filtro.
        /// </summary>
        /// <param name="filtroViewModel"></param>
        /// <returns></returns>              
        [HttpPost("filtrar")]
        public IActionResult Filtrar([FromBody]CategoriaFiltroViewModel filtroViewModel)
        {
            try
            {
                CategoriaFiltro filtro = _mapper.Map<CategoriaFiltroViewModel, CategoriaFiltro>(filtroViewModel);
                var registros = _categoriaServico.Filtra(filtro);
                var responseViewModel = new ResponseViewModel<CategoriaViewModel>()
                {
                    Total = registros.Key,
                    Registros = _mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(registros.Value)
                };
                return Ok(responseViewModel);
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
                var categoriaViewModel = _mapper.Map<Categoria, CategoriaViewModel>(_categoriaServico.BuscaPorId(id));
                return Ok(categoriaViewModel);
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
        /// <param name="categoriaViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput]
        public IActionResult Post([FromBody]CategoriaViewModel categoriaViewModel)
        {
            try
            {
                var categoria = _mapper.Map<CategoriaViewModel, Categoria>(categoriaViewModel);
                _categoriaServico.Cadastra(categoria);
                return Created("categoria/post", categoria);
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
        /// <param name="categoriaViewModel"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody]CategoriaViewModel categoriaViewModel)
        {
            try
            {
                var categoria = _mapper.Map<CategoriaViewModel, Categoria>(categoriaViewModel);
                _categoriaServico.Atualiza(categoria);
                return Ok(categoria);
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
                Func<Categoria, bool> predicate = (entity => (Array.IndexOf(id, entity.Id) > -1));
                _categoriaServico.Remove(predicate);
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

        /// <summary>
        /// Retorna um SelectListem contendo as categorias ativas para montagem de select.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>       
        [HttpPost("select")]        
        public IActionResult Select([FromBody]CategoriaFiltroViewModel filtro)
        {
            try
            {
                CategoriaFiltro filter = _mapper.Map<CategoriaFiltroViewModel, CategoriaFiltro>(filtro);
                return Ok(_categoriaServico.Select(filter));
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

