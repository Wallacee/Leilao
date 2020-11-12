using Leilao.Infra;
using Leilao.Model;
using Leilao.Service;
using Leilao.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Leilao.Web.Controllers
{
    public class LanceController : Controller
    {
        private LanceServico LanceServico = new LanceServico();
        private PessoaServico PessoaServico = new PessoaServico();
        private ProdutoServico ProdutoServico = new ProdutoServico();
        // GET: Lance
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create() => View();
        [HttpPost]
        public JsonResult Create(Lance lance)
        {
            ResultProcessing result = LanceServico.Adicionar(lance);
            return Json(new { success = result.Success, message = result.Message }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public PartialViewResult IniciarLeilao(int idPessoa, int produtoId)
        {
            ViewBag.pessoaId = idPessoa;
            ViewBag.produtoId = produtoId;
            ViewBag.nomePessoa = PessoaServico.BuscarNome(idPessoa);
            ViewBag.nomeProduto = ProdutoServico.BuscarNome(produtoId);

            return PartialView();
        }

        [HttpPost]
        public JsonResult LanceValido(int idProduto, float valor)
        {
            bool validez = LanceServico.ELanceValido(idProduto, valor);
            return Json(new { data = validez }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult BusvarValorAtual(int idProduto)
        {
            float valorAtual = LanceServico.BusvarValorAtual(idProduto);
            return Json(new { data = valorAtual }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult Salvar(int idProduto, float valor, int idPessoa)
        {
            ResultProcessing result = LanceServico.Salvar(idProduto, valor, idPessoa);
            return Json(new { success = result.Success,message = result.Message},JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Listar()
        {
            List<Lance> listLance= LanceServico.ListarTodos();
            return Json(new { data = listLance }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListarLances() => View();
        public ActionResult ListarPaginado(GridParams parametros)
        {
            CampoOrdenado campo = parametros.ObterCampoOrdenado(Request);
            var dadosPaginados = LanceServico.ListarPaginado(parametros.Start, parametros.Length, parametros.Search.Value, campo.Campo, campo.Ordem);
            var retorno = Json(new { data = dadosPaginados.Dados, recordsFiltered = dadosPaginados.Total, recordsTotal = dadosPaginados.Total }, JsonRequestBehavior.AllowGet);
            return retorno;
        }

    }
}