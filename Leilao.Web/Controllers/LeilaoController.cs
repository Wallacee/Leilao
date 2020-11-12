using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Leilao.Web.Controllers
{
    public class LeilaoController : Controller
    {
        // GET: Leilao
        public ActionResult Index()
        {
            return View();
        }
    }
}