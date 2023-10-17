using clinicaveterinaria20.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace clinicaveterinaria20.Controllers
{
    public class AnimalController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            return View(db.Animale.ToList());
        }

        public ActionResult Create()
        {
            Animale animale = new Animale
            {
                microchip = false
            };
            return View(animale);
        }

        [HttpPost]
        public ActionResult Create(Animale a, HttpPostedFileBase foto)
        {
            if (ModelState.IsValid)
            {
                if (!a.microchip.HasValue)
                {
                    a.microchip = false;
                }
                if (foto != null && foto.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(foto.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/Content/img/uploads"), fileName);
                    foto.SaveAs(filePath);
                    a.foto = fileName;
                }
                else
                {
                    a.foto = "placeholder.jpg";
                }
                db.Animale.Add(a);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Errore = "Impossibile anagrafare l'animale";
            return View();
        }

        public ActionResult Edit(int id)
        {
            Animale a = db.Animale.Find(id);
            return View(a);
        }

        [HttpPost]
        public ActionResult Edit(Animale a, HttpPostedFileBase foto)
        {
            Model1 dbAnimale = new Model1();
            if (ModelState.IsValid)
            {
                if (foto != null)
                {
                    string fileName = Path.GetFileName(foto.FileName);
                    string filePath = Path.Combine(Server.MapPath("~/Content/img/uploads"), fileName);
                    foto.SaveAs(filePath);
                    a.foto = fileName;
                }
                else
                {
                    a.foto = "placeholder.jpg";
                }
                dbAnimale.Entry(a).State = EntityState.Modified;
                dbAnimale.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Errore = "Impossibile modificare l'anagrafica dell'animale";
            return View();
        }

        public ActionResult Delete(int id)
        {
            Animale a = db.Animale.Find(id);
            if (a == null)
            {
                return HttpNotFound();
            }
            return View(a);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ActualDelete(Animale a)
        {
            db.Animale.Remove(a);
            db.SaveChanges();
            TempData["Success"] = "Anagrafica rimossa con successo";
            return RedirectToAction("Index");
        }

        public ActionResult MedicalHistory(int id)
        {
            Animale a = db.Animale.Find(id);
            return PartialView();
        }
    }
}