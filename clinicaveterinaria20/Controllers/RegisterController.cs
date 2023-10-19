using clinicaveterinaria20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace clinicaveterinaria20.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        private Model1 db = new Model1();
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register (Utente u)
        {
            List<Utente> uList = db.Utente.ToList();
            Utente utente = db.Utente.FirstOrDefault(m=> m == u);
            if (utente == null)
            {
                db.Utente.Add(u);
                db.SaveChanges();
            }
            else
            {
                ViewBag.Errore = "Utente presente nel database";
            }

            return View();
        }
    }
}