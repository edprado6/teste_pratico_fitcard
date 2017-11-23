using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using TesteFitcard.DominioViewModel.Entidades;
using TesteFitcard.DominioViewModel.Filtros;
using TesteFitcard.Infra.Strings;
using TesteFitcard.UI.RestClient.Interfaces;

namespace TesteFitcard.UI.Controllers
{
    /// <summary>
    /// Classe de interação com a entidade Estabelecimento.
    /// </summary>
    public class EstabelecimentoController : Controller
    {
        private IEstabelecimentoClient _estabelecimentoClient { get; set; }
        private ICategoriaClient _categoriaClient { get; set; }
        private ICorreiosClient _correiosClient { get; set; }

        /// <summary>
        /// Método construtor.
        /// </summary>
        /// <param name="estabelecimentoClient"></param>
        public EstabelecimentoController(IEstabelecimentoClient estabelecimentoClient, ICategoriaClient categoriaClient, ICorreiosClient correiosClient)
        {
            _estabelecimentoClient = estabelecimentoClient;
            _categoriaClient = categoriaClient;
            _correiosClient = correiosClient;
        }

        /// <summary>
        /// Método que exxibe uma grid com as estabelecimentos cadastradas.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {           
            var filtro = new EstabelecimentoFiltroViewModel()
            {
                RegistrosPorPagina = 30
            };
            var data = _estabelecimentoClient.GetFiltro(filtro);
            return View(data);
        }

        /// <summary>
        /// Método que busca os detalhes de uma estabelecimento a partir do seu id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Detalhes(string id)
        {
            var data = _estabelecimentoClient.Get(id);
            return View(data);
        }

        /// <summary>
        /// Exibe formulário para cadastro de novas estabelecimentos.
        /// </summary>
        /// <returns></returns>
        public IActionResult Cadastrar()
        {
            var selectCategorias = _categoriaClient.GetSelect();
            ViewBag.SelectCategorias = selectCategorias;
            return View();
        }

        /// <summary>
        /// Recebe dados do formulário para inserção
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        //[ValidateInput]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(EstabelecimentoViewModel estabelecimentoViewModel)
        {
            if (ModelState.IsValid)
            {
                var data = _estabelecimentoClient.Post(estabelecimentoViewModel);

                if (data != null)
                {
                    TempData["mensagem"] = Mensagens.MensagemSucesso(Resource.RegistroSalvoSucesso);
                    return RedirectToAction("Index");
                }
                
                ViewBag.SelectCategorias = _categoriaClient.GetSelect();
                TempData["mensagem"] = Mensagens.MensagemFalha(Resource.UmErroAconteceu);
                return View();
            }
           
            ViewBag.SelectCategorias = _categoriaClient.GetSelect();

            return View();
        }

        /// <summary>
        /// Método que busca os detalhes de uma estabelecimento a partir do seu id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Editar(string id)
        {
            var selectCategorias = _categoriaClient.GetSelect();
            ViewBag.SelectCategorias = selectCategorias;
            var data = _estabelecimentoClient.Get(id);
            return View(data);
        }

        /// <summary>
        /// Recebe dados do formulário para atualização.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(EstabelecimentoViewModel estabelecimentoViewModel)
        {
            if (ModelState.IsValid)
            {

                var data = _estabelecimentoClient.Put(estabelecimentoViewModel);

                if (data != null)
                {
                    TempData["mensagem"] = Mensagens.MensagemSucesso(Resource.RegistroAtualizadoSucesso);
                    return RedirectToAction("Index");
                }
                ViewBag.SelectCategorias = _categoriaClient.GetSelect();
                TempData["mensagem"] = Mensagens.MensagemFalha(Resource.UmErroAconteceu);
                return View();
            }
            ViewBag.SelectCategorias = _categoriaClient.GetSelect();
            return View();
        }

        /// <summary>
        /// Recebe um id para realizar a remoção do registro.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(string id)
        {
            try
            {
                _estabelecimentoClient.Delete(id);
                TempData["mensagem"] = Mensagens.MensagemSucesso(Resource.RegistroExcluidoSucesso);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["mensagem"] = Mensagens.MensagemFalha(e.Message.ToString());
                return View();
            }
        }

        /// <summary>
        /// Retorna endereço a partir de um CEP.
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult BuscaEndereco(string cep) {

            var resposta = _correiosClient.BuscaEndereco(cep);
            return Json(new { HttpStatusCode.OK, resposta });
        }
    }
}
