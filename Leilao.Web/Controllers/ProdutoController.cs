using Leilao.Infra;
using Leilao.Model;
using Leilao.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Leilao.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutoServico ProdutoServico = new ProdutoServico();
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create() => View();
        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            ResultProcessing result = ProdutoServico.Adicionar(produto);
            return RedirectToAction("Create");
        }
        [HttpGet]
        public JsonResult Listar()
        {
            List<Produto> listPessoa = ProdutoServico.ListarTodos();
            return Json(new { data = listPessoa }, JsonRequestBehavior.AllowGet);
        }
    }
}