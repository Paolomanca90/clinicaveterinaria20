using clinicaveterinaria20.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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
        public JsonResult magazion(string nome)
        {
            List<Prodotti> prodotto = new List<Prodotti>();
            if (nome == "")
            {
                prodotto = database.Prodotti.ToList();
            }
            else
            {
                prodotto = database.Prodotti.Where((a) => a.nome == nome).ToList();
            }

            List<ModelloProdotto> list = new List<ModelloProdotto>();
            if (prodotto.Count > 0)
            {
                foreach (var item in prodotto)
                {
                    ModelloProdotto modello = new ModelloProdotto();
                    modello.nome = item.nome;
                    modello.costo = item.costo;
                    modello.idprodotto = item.idprodotto;
                    modello.tipologia = item.tipologia;
                    modello.foto = item.foto;
                    modello.quantita = item.quantita;
                    modello.costo = item.costo;
                    modello.casetto = item.Cassetto.ncassetto;
                    modello.armadietto = item.Cassetto.Armadietti.codice;

                    list.Add(modello);
                }
            }
            else
            {
                ModelloProdotto modello = new ModelloProdotto();
                modello.nome = "prodotto insesistente";
                list.Add(modello);
            }
            return Json(list);
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
        public ActionResult inserisciprodottoinmagazino(Prodotti p, HttpPostedFileBase foto)
        {
            if (foto != null && foto.ContentLength > 0)
            {
                string nomeFile = foto.FileName;
                string pathToSave = Path.Combine(Server.MapPath("~/Content/img"), nomeFile);
                foto.SaveAs(pathToSave);

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
                                if (brand12 != null)
                                {
                                    Utilizzi utilizzi = database.Utilizzi.FirstOrDefault(u => u.descrizioni == u.descrizioni);
                                    if (utilizzi == null)
                                    {
                                        utilizzi.descrizioni = p.Utilizzi.descrizioni;
                                        database.Utilizzi.Add(utilizzi);
                                        database.SaveChanges();
                                        utilizzi = database.Utilizzi.FirstOrDefault(u => u.descrizioni == u.descrizioni);
                                    }
                                    Brand brand = database.Brand.FirstOrDefault(b => b.nome == p.Brand.nome);
                                    Prodotti prodotti = new Prodotti();
                                    prodotti.nome = p.nome;
                                    prodotti.tipologia = p.tipologia;
                                    prodotti.foto = p.foto;
                                    prodotti.quantita = p.quantita;
                                    prodotti.costo = p.costo;
                                    prodotti.foto = foto.FileName;
                                    prodotti.idcassetto = cassetto.idcassetto;
                                    prodotti.idbrand = brand12.idbrand;
                                    prodotti.idutilizzo = utilizzi.idutilizzo;

                                    database.Prodotti.Add(prodotti);

                                    database.SaveChanges();
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
            }
            else
            {
                ViewBag.img = "inserire un immaggine";
            }
            return View();
        }

        [HttpGet]
        public ActionResult aggiungiArmadio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult aggiungiArmadio(Armadietti a)
        {
            if (ModelState.IsValid)
            {
                Cassetto cassetto = new Cassetto();
                Armadietti arm = database.Armadietti.FirstOrDefault(e => a.codice == e.codice);
                if (arm == null)
                {
                    int n = a.nCassettti;

                    database.Armadietti.Add(a);
                    database.SaveChanges();
                    Armadietti ar = database.Armadietti.ToList().Last();

                    for (int i = 0; i < n; i++)
                    {
                        cassetto.idarmadietto = ar.idarmadietto;
                        cassetto.ncassetto = i + 1;
                        database.Cassetto.Add(cassetto);
                        database.SaveChanges();
                    }
                }
                else
                {
                    ViewBag.errore = "armadietto gia presente";
                }
            }
            return View();
        }
    }
}