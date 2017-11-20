using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteFitcard.Servico.Entidades.Interfaces;
using AutoMapper;

namespace TesteFitcard.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IMapper _mapper;
        public ICategoriaServico _categoriaServico { get; private set; }

        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="categoriaServico"></param>
        /// <param name="mapper"></param>
        public ValuesController(ICategoriaServico categoriaServico, IMapper mapper)
        {
            _categoriaServico = categoriaServico;
            _mapper = mapper;
        }



        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
