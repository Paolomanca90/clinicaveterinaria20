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

        public ActionResult Home()
        {
            return View();
        }
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
            if (!a.microchip.HasValue)
            {
                a.microchip = false;
            }
            if (string.IsNullOrWhiteSpace(a.nome) && a.datainizioricovero != null)
            {
                var animalesmarrito = db.Animale
                    .Where(an => an.nome.StartsWith("animalesmarrito"))
                    .ToList();

                if (animalesmarrito.Any())
                {
                    int maxNanimalesmarrito = animalesmarrito
                        .Select(an => int.TryParse(an.nome.Replace("animalesmarrito", ""), out var result) ? result : 0)
                        .Max();

                    a.nome = "animalesmarrito" + (maxNanimalesmarrito + 1);
                }
                else
                {
                    a.nome = "animalesmarrito1";
                }
            }

            ModelState.Remove("microchip");
            ModelState.Remove("nome");
            if (ModelState.IsValid)
            {
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

        public ActionResult CreateVisit(int id)
        {
            Animale animale = db.Animale.Find(id);
            if (animale == null)
            {
                return HttpNotFound();
            }

            var visiteInOrdineCronologico = animale.Visita.OrderByDescending(v => v.datavisita).ToList();
            ViewBag.Anamnesi = visiteInOrdineCronologico;
            ViewBag.NomePaziente = animale.nome;

            Visita nuovavisita = new Visita
            {
                idanimale = id
            };
            return View(nuovavisita);
        }

        [HttpPost]
        public ActionResult CreateVisit(Visita v)
        {
            if(ModelState.IsValid)
            {
                db.Visita.Add(v);
                db.SaveChanges();

            ViewBag.Anamnesi = db.Visita.Where(visita => visita.idanimale == v.idanimale)
            .OrderByDescending(visita => visita.datavisita).ToList();
            ViewBag.NomePaziente = db.Animale.Find(v.idanimale).nome;

            return View();
            }
            ViewBag.Errore = "Impossibile registrare la visita";

            ViewBag.Anamnesi = db.Visita.Where(visita => visita.idanimale == v.idanimale)
            .OrderByDescending(visita => visita.datavisita).ToList();
            ViewBag.NomePaziente = db.Animale.Find(v.idanimale).nome;
            return View(v);
        }

        //public ActionResult MedicalHistory(int id)
        //{
        //    Animale animale = db.Animale.Include(a => a.Visita).FirstOrDefault(a => a.idanimale == id);
        //    if (animale == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    var visiteInOrdineCronologico = animale.Visita.OrderByDescending(v => v.datavisita).ToList();

        //    return View(visiteInOrdineCronologico);
        //}

        public ActionResult SearchByMNumber()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchByMNumber(string nmicrochip)
        {
            if (!string.IsNullOrEmpty(nmicrochip))
            {
                Animale animale = db.Animale.Where(a=>a.nmicrochip == nmicrochip).FirstOrDefault();
                return Json(animale);
            }
            else
            {
                ViewBag.Errore = "Nessun animale trovato con il numero di microchip inserito.";
                return View();
            }
        }
    }
}