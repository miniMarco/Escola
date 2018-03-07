using Escola.Infraestrutura;
using Escola.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Escola.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return Redirect("/Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Usuario user = UserManager.Find(details.Nome, details.Senha);
                if (user == null)
                    ModelState.AddModelError("", "Nome ou senha Inválido(s).");
                else
                {
                    ClaimsIdentity ident = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = false
                    }, ident);
                    if (returnUrl == null)
                        returnUrl = "/Home";

                    return Redirect(returnUrl);
                }
            }

            return View(details);

        }

        private IAuthenticationManager AuthManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        private GerenciadorUsuario UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>(); }
        }
    }
}