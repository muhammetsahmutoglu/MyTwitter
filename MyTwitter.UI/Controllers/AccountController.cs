using MyTwitter.Model.Option;
using MyTwitter.Service.Option;
using MyTwitter.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyTwitter.UI.Controllers
{
    public class AccountController : Controller
    {
        AppUserService appUserService;
        public AccountController()
        {
            appUserService = new AppUserService();

        }
        public ActionResult Register()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Register(AppUser data)
        {
            AppUser user = appUserService.FindByUserNameOrEmail(data.UserName);
            
            if (user==null )
            {
                AppUser newUser = new AppUser();
                newUser.UserName = data.UserName;
                newUser.FirstName = data.FirstName;
                newUser.LastName = data.LastName;
                newUser.Password = data.Password;
                newUser.Email = data.Email;
                appUserService.Add(newUser);                
                return Redirect("/Account/Login");
            }
            
            return Redirect("/Account/Login");

        }
        
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Member/Home/Index");
            }
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM credentials)
        {
            if (ModelState.IsValid)
            {
                if (appUserService.CheckCredentials(credentials.UserName,credentials.Password))
                {
                    AppUser user = appUserService.FindByUserName(credentials.UserName);
                    Session["name"] = user.UserName;
                    Session["ID"] = user.ID;
                    string cookie = user.UserName;
                    FormsAuthentication.SetAuthCookie(cookie, true);
                    return Redirect("/Member/Home/Index");
                }
                else
                {
                    ViewData["error"] = "Kullanıcı adı/mail veya şifre hatalı";
                    return View();
                }

            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Account/Login");
        }
    }
}