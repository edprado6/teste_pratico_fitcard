using Microsoft.AspNetCore.Mvc;
using TesteFitcard.DominioViewModel.Entidades;
using TesteFitcard.DominioViewModel.Filtros;
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
            var filtro = new CategoriaFiltroViewModel()
            {
                NomeCategoria = "Far",
                RegistrosPorPagina = 30
            };
            var data = _categoriaClient.GetFiltro("categoria", filtro);
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
                Id = "963b3181-4728-4c0c-88d6-30ea1b3bf625",
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
