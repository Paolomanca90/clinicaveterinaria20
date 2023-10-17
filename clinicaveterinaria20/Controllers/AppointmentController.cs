using clinicaveterinaria20.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace clinicaveterinaria20.Controllers
{
    public class AppointmentController : Controller
    {
        private Model1 db = new Model1();
        private List<SelectListItem> OttieniListaAnimali()
        {
            List<Animale> animaliregistrati = db.Animale.ToList();
            List<SelectListItem> listaAnimali = new List<SelectListItem>();
            foreach (Animale animale in animaliregistrati)
            {
                listaAnimali.Add(new SelectListItem { Text = animale.nome, Value = animale.idanimale.ToString() });
            }
            return listaAnimali;
        }
        public ActionResult Index()
        {
            return View(db.Visita.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.ListaAnimali = OttieniListaAnimali();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Visita v)
        {
            if (ModelState.IsValid)
            {
                db.Visita.Add(v);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Errore = "Impossibile registrare la visita";
            return View();
        }

        public ActionResult Edit(int id)
        {
            Visita v = db.Visita.Find(id);
            ViewBag.ListaAnimali = OttieniListaAnimali();
            return View(v);
        }

        [HttpPost]
        public ActionResult Edit(Visita v)
        {
            Model1 dbVisita = new Model1();
            if (ModelState.IsValid)
            {
                dbVisita.Entry(v).State = EntityState.Modified;
                dbVisita.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            Visita v = db.Visita.Find(id);
            if (v == null)
            {
                return HttpNotFound();
            }
            return View(v);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ActualDelete(Visita v)
        {
            db.Visita.Remove(v);
            db.SaveChanges();
            TempData["Success"] = "Dati visita rimossi con successo";
            return RedirectToAction("Index");
        }
    }
}