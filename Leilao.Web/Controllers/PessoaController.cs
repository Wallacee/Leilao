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
    public class PessoaController : Controller
    {
        private PessoaServico pessoaServico = new PessoaServico();
        // GET: Pessoa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(Pessoa pessoa)
        {
            ResultProcessing result = pessoaServico.Adicionar(pessoa);
            return RedirectToAction("Create");
        }
        [HttpGet]
        public JsonResult Listar()
        {
            List<Pessoa> listPessoa = pessoaServico.ListarTodos();
            return Json(new { data = listPessoa }, JsonRequestBehavior.AllowGet);
        }
    }
}