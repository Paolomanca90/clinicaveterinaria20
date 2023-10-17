using clinicaveterinaria20.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace clinicaveterinaria20.Controllers
{
    public class magazzinoController : Controller
    {
        // GET: magazzino
        private Model1 database = new Model1();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult magazzino()
        {
            return View();
        }

        [HttpPost]
        public ActionResult magazzino([Bind(Include = "nome")] Prodotti p)
        {
            Prodotti prodotto = database.Prodotti.FirstOrDefault((a) => a.quantita > 0 && a.nome == p.nome);
            if (prodotto != null)
            {
                ViewBag.prodotto = "sono presenti " + prodotto.quantita + " " + prodotto.nome + " nell'armadietto " + prodotto.Cassetto.Armadietti.codice + " cassetto n." + prodotto.Cassetto.ncassetto;
            }
            else
            {
                ViewBag.prodotto = "attulmente questo prodotto non è presente in magazzino";
            }
            return View();
        }

        [HttpGet]
        public ActionResult aggiugiAziende()
        {
            return View();
        }

        [HttpPost]
        public ActionResult aggiugiAziende(Brand b)
        {
            if (ModelState.IsValid)
            {
                Brand brand = database.Brand.FirstOrDefault((a) => a.piva == b.piva && a.nome == b.nome);
                if (brand == null)
                {
                    database.Brand.Add(b);
                    database.SaveChanges();
                }
                else
                {
                    ViewBag.errore = "azienda gia presente";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult inserisciprodottoinmagazino()
        {
            return View();
        }

        [HttpPost]
        public ActionResult inserisciprodottoinmagazino(Prodotti p, HttpPostedFile foto)
        {
            if (foto != null && foto.ContentLength > 0)
            {
                p.foto = foto.FileName;
                string path = Server.MapPath("~/Content/img/") + foto.FileName;
                foto.SaveAs(path);
            }
            Prodotti prodotto = database.Prodotti.FirstOrDefault((a) => a.nome == p.nome);
            if (prodotto == null)
            {
                Armadietti a = database.Armadietti.FirstOrDefault((arm) => p.Cassetto.Armadietti.codice == arm.codice);
                if (a != null)
                {
                    Cassetto cassetto = database.Cassetto.FirstOrDefault(c => c.ncassetto == p.Cassetto.ncassetto);
                    if (cassetto != null)
                    {
                        Prodotti pr = database.Prodotti.FirstOrDefault(e => e.idcassetto == p.idcassetto);
                        if (pr == null)
                        {
                            Brand brand12 = database.Brand.FirstOrDefault(b => b.nome == p.Brand.nome);
                            if (brand12 == null)
                            {
                                database.Prodotti.Add(p);
                            }
                            else { ViewBag.errore = "brand non registrato"; }
                        }
                        else { ViewBag.errore = "cassetto occupato"; }
                    }
                    else { ViewBag.errore = "cassetto non presente"; }
                }
                else
                {
                    ViewBag.errore = "aramdietto non presente";
                }
            }
            else
            {
                ViewBag.errore = "prodotto gia presente presente";
            }
            return View();
        }
    }
}