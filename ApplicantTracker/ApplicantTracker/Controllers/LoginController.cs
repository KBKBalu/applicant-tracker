using ApplicantTracker.InfraStructure;
using ApplicantTracker.InfraStructure.Interfaces;
using ApplicantTracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ApplicantTracker.Controllers
{
    public class LoginController : Controller
    {
        IAuthenticationManager Authentication
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }


        private readonly IBusinessLayer _businessLayer;

        public LoginController()
        {
            _businessLayer = new BusinessLayer();
        }


        // GET: Account
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new ApptrackLoginViewModel());
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(ApptrackLoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var isExistuser = _businessLayer.IsUserExists(model.UserName, model.Password);

            if (isExistuser)
            {
                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.UserName), }, DefaultAuthenticationTypes.ApplicationCookie);

                //Authentication.SignIn(new AuthenticationProperties
                //{
                //    IsPersistent = model.RememberMe
                //}, identity);


                FormsAuthentication.SetAuthCookie(model.UserName, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Authentication.SignOut();
            
            return RedirectToAction("Login", "Login");
        }
    }
}