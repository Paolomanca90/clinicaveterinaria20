using clinicaveterinaria20.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace clinicaveterinaria20.Controllers
{
    public class HomeController : Controller
    {
        private Model1 database = new Model1();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(Utente u)
        {
            Utente utente = database.Utente.FirstOrDefault((e) => e.username == u.username && e.password == u.password);
            if (utente != null)
            {
                FormsAuthentication.SetAuthCookie(u.username, false);
            }
            return View();
        }

        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}