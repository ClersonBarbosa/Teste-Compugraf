using Compugraf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Compugraf.Controllers
{
    public class PessoaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult Consultar()
        {
            return View();
        }

        #region | POST 

        [System.Web.Http.HttpPost]
        public JsonResult CadastrarPessoa([FromBody]Pessoa pessoa)
        {
            if (new Pessoa().CadastrarPessoa(pessoa))
                return Json(new { status = true, JsonRequestBehavior.AllowGet });
            else
                return Json(new { status = false, JsonRequestBehavior.AllowGet });
        }

        [System.Web.Http.HttpPost]
        public JsonResult ExcluirPessoa(Pessoa pessoa)
        {
            if (new Pessoa().ExcluirPessoa(pessoa))
                return Json(new { status = true, JsonRequestBehavior.AllowGet });
            else
                return Json(new { status = false, JsonRequestBehavior.AllowGet });
        }
        

        #endregion

        #region | GETS 

        [System.Web.Http.HttpGet]
        public JsonResult ConsultarPessoa(Pessoa pessoa) { 

            var ListaPessoa = new Pessoa().ConsultarPessoa(pessoa);

            return Json(new { data = ListaPessoa }, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public JsonResult ConsultarPessoaByID(Pessoa pessoa)
        {
            bool status = false;

            var ListaPessoa = new Pessoa().ConsultarPessoaByID(pessoa);

            if (ListaPessoa.Id > 0)
                status = true;

            return Json(new { status, response = ListaPessoa }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
