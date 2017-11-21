using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteFitcard.DominioViewModel.Filtros;
using TesteFitcard.UI.RestClient.Interfaces;
using TesteFitcard.DominioViewModel.Entidades;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteFitcard.UI.Controllers
{
    public class EstabelecimentoController : Controller
    {
        private IEstabelecimentoClient _estabelecimentoClient { get; set; }

        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="estabelecimentoClient"></param>
        public EstabelecimentoController(IEstabelecimentoClient estabelecimentoClient)
        {
            _estabelecimentoClient = estabelecimentoClient;
        }

        /// <summary>
        /// Método que exxibe uma grid com as estabelecimentos cadastradas.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
           
            var filtro = new EstabelecimentoFiltroViewModel()
            {
                NomeFantasia = "Far"
            };
            var data = _estabelecimentoClient.GetSelect("estabelecimento", filtro);
            return View(data);
        }

        /// <summary>
        /// Método que busca os detalhes de uma estabelecimento a partir do seu id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Detalhes(string id)
        {

            var data = _estabelecimentoClient.Get("estabelecimento", id);
            return View(data);
        }



        public IActionResult Post()
        {

            var estabelecimento = new EstabelecimentoViewModel()
            {
                RazaoSocial = "Teste de Cadastro",
                CategoriaId = "735096bd-2cab-4384-b697-f612198cf5cc",
                Cnpj = "00881753000153",
                Email = "testecadastro@hotmail.com",
                Ativo = true,
                Excluido = false
            };

            var data = _estabelecimentoClient.Post("estabelecimento", estabelecimento);
            return View(data);
        }

        public IActionResult Put()
        {

            var estabelecimento = new EstabelecimentoViewModel()
            {
                Id = "963b3181-4728-4c0c-88d6-30ea1b3bf625",
                RazaoSocial = "Supermercado",
                Ativo = true,
                Excluido = false
            };

            var data = _estabelecimentoClient.Put("estabelecimento", estabelecimento);
            return View(data);
        }

        public IActionResult Delete(string id)
        {
            _estabelecimentoClient.Delete("estabelecimento", id);
            return View();
        }
    }
}
