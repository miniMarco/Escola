using Escola.Infraestrutura;
using Escola.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Escola.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View(GerenciadorUsuario.Users);
        }
        private GerenciadorUsuario GerenciadorUsuario
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            }
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario user = new Usuario
                {
                    UserName = model.Nome,
                    Email = model.Email
                };
                IdentityResult result = GerenciadorUsuario.Create(user, model.Senha);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    addErrorsFromResult(result);
            }
            return View(model);
        }

        private void addErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
                ModelState.AddModelError("", error);
        }
    }
}