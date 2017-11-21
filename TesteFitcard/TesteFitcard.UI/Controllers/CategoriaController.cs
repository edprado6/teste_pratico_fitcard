using Microsoft.AspNetCore.Mvc;
using TesteFitcard.DominioViewModel.Entidades;
using TesteFitcard.DominioViewModel.Filtros;
using TesteFitcard.Infra.Validacoes;
using TesteFitcard.UI.RestClient.Interfaces;

namespace TesteFitcard.UI.Controllers
{
    /// <summary>
    /// Classe responsável pelas iterações com a entidade Categoria.
    /// </summary>
    public class CategoriaController : Controller
    {
        private ICategoriaClient _categoriaClient { get; set; }

        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="categoriaClient"></param>
        public CategoriaController(ICategoriaClient categoriaClient)
        {
            _categoriaClient = categoriaClient;
        }

        /// <summary>
        /// Método que exxibe uma grid com as categorias cadastradas.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var cnpjValido1 = ValidaCNPJ.CnpjIsValid("00881753000153");
            var cnpjValido2 = ValidaCNPJ.CnpjIsValid("19861350000170");
            var cnpjValido3 = ValidaCNPJ.CnpjIsValid("19861350000413");
            var cnpjValido4 = ValidaCNPJ.CnpjIsValid("19861350000251");

            var cnpjInvalido1 = ValidaCNPJ.CnpjIsValid("00881753000154");
            var cnpjInvalido2 = ValidaCNPJ.CnpjIsValid("19861350000171");
            var cnpjInvalido3 = ValidaCNPJ.CnpjIsValid("19861350000414");
            var cnpjInvalido4 = ValidaCNPJ.CnpjIsValid("19861350000252");

            var filtro = new CategoriaFiltroViewModel()
            {
                NomeCategoria = "Far",
                RegistrosPorPagina = 30
            };
            var data = _categoriaClient.GetSelect("categoria", filtro);
            return View(data);
        }

        /// <summary>
        /// Método que busca os detalhes de uma categoria a partir do seu id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Detalhes(string id) {

            var data = _categoriaClient.Get("categoria", id);
            return View(data);
        }

        

        public IActionResult Post() {

            var categoria = new CategoriaViewModel()
            {
                NomeCategoria = "Farmácia",
                Ativo = true,
                Excluido = false
            };

            var data = _categoriaClient.Post("categoria", categoria);
            return View(data);
        }
   
        public IActionResult Put()
        {

            var categoria = new CategoriaViewModel()
            {
                Id = "f529be70-9d3f-4549-b9f4-ae22a266a9a0",
                NomeCategoria = "Supermercado",
                Ativo = true,
                Excluido = false
            };

            var data = _categoriaClient.Put("categoria", categoria);
            return View(data);
        }

        public IActionResult Delete(string id)
        {            
            _categoriaClient.Delete("categoria", id);
            return View();
        }
    }
}
