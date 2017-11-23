using Microsoft.AspNetCore.Mvc;
using System;
using TesteFitcard.Servico.ServicosDiversos.Interfaces;

namespace TesteFitcard.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CorreiosController : Controller
    {
        private ICorreiosServico _correiosServico { get; set; }

        ///// <summary>
        ///// Método construtor.
        ///// </summary>
        ///// <param name="correiosService"></param>
        public CorreiosController(ICorreiosServico correiosServico)
        {
            _correiosServico = correiosServico;
        }

        /// <summary>
        /// Retorna um endereço de acordo com um CEP.
        /// </summary>
        /// <returns></returns>        
        [HttpGet("buscaendereco/{cep}")]
        public IActionResult BuscaEndereco(string cep)
        {
            try
            {               
                return Ok(_correiosServico.BuscaEndereco(cep));
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
