using Microsoft.AspNetCore.Mvc;
using System;
using TesteFitcard.DominioViewModel.Entidades;
using TesteFitcard.DominioViewModel.Filtros;
using TesteFitcard.Infra.Strings;
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
        public IActionResult Index()
        {
            var filtro = new CategoriaFiltroViewModel()
            {               
                RegistrosPorPagina = 30
            };
            var data = _categoriaClient.GetFiltro("categoria", filtro);
            return View(data);
        }

        /// <summary>
        /// Exibe formulário para cadastro de novas categorias.
        /// </summary>
        /// <returns></returns>
        public IActionResult Cadastrar() {

            return View();
        }

        /// <summary>
        /// Recebe dados do formulário para inserção
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public IActionResult Cadastrar(CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid) {

                var data = _categoriaClient.Post("categoria", categoriaViewModel);

                if (data != null)
                {
                    TempData["mensagem"] = Mensagens.MensagemSucesso(Resource.RegistroSalvoSucesso);
                    return RedirectToAction("Index");
                }

                TempData["mensagem"] = Mensagens.MensagemFalha(Resource.UmErroAconteceu);
                return View();
            }

            return View();
        }

        /// <summary>
        /// Método que busca os detalhes de uma categoria a partir do seu id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Editar(string id) {

            var data = _categoriaClient.Get("categoria", id);
            return View(data);
        }

        /// <summary>
        /// Recebe dados do formulário para atualização.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid) {

                var data = _categoriaClient.Put("categoria", categoriaViewModel);

                if (data != null)
                {
                    TempData["mensagem"] = Mensagens.MensagemSucesso(Resource.RegistroAtualizadoSucesso);
                    return RedirectToAction("Index");
                }

                TempData["mensagem"] = Mensagens.MensagemFalha(Resource.UmErroAconteceu);
                return View();
            }
            
            return View();
        }

        /// <summary>
        /// Método que busca os detalhes de uma categoria a partir do seu id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Detalhes(string id)
        {
            var data = _categoriaClient.Get("categoria", id);
            return View(data);
        }

        /// <summary>
        /// Recebe um id para realizar a remoção do registro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(string id)
        {
            try {

                _categoriaClient.Delete("categoria", id);
                TempData["mensagem"] = Mensagens.MensagemSucesso(Resource.RegistroExcluidoSucesso);
                return RedirectToAction("Index");
            }
            catch (Exception e) {
                TempData["mensagem"] = Mensagens.MensagemFalha(e.Message.ToString());
                return View();
            }
        }
    }
}
