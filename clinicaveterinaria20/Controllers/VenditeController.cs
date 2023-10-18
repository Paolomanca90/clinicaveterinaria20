using clinicaveterinaria20.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace clinicaveterinaria20.Controllers
{
    public class VenditeController : Controller
    {
        // GET: Vendite
        private Model1 db = new Model1();

        public List<SelectListItem> ListaProdotti
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();
                List<Prodotti> lista = new List<Prodotti>();
                lista = db.Prodotti.Where((a) => a.quantita > 0).ToList();
                foreach (Prodotti p in lista)
                {
                    SelectListItem item = new SelectListItem { Text = $"{p.quantita} pz - {p.nome} - {p.costo:C}", Value = $"{p.idprodotto}" };
                    list.Add(item);
                }
                return list;
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                Cliente comp = db.Cliente.FirstOrDefault(m => m.codicefiscale == cliente.codicefiscale);
                if (comp == null)
                {
                    db.Cliente.Add(cliente);
                    db.SaveChanges();
                }
                List<Cliente> lista = new List<Cliente>();
                lista = db.Cliente.ToList();
                foreach (Cliente c in lista)
                {
                    if (c.codicefiscale == cliente.codicefiscale)
                    {
                        Session["idCliente"] = c.idcliente;
                    }
                }
                if (Session["idCliente"] != null)
                {
                    return RedirectToAction("Create");
                }
                return View();
            }
            else { return View(); }
        }

        public ActionResult Create()
        {
            if (Session["idCliente"] != null)
            {
                ViewBag.Prodotti = ListaProdotti;
                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vendita vd)
        {
            Model1 database = new Model1();
            if (vd.quantita == 0 || vd.quantita == null)
            {
                vd.quantita = 1;
            }
            vd.datavendita = DateTime.Now;
            Prodotti prodotto = database.Prodotti.Find(vd.idprodotto);
            if (prodotto.quantita < vd.quantita)
            {
                ViewBag.errore = "attualmente non è presente il numero di articoli richiesti sono presenti " + prodotto.quantita;
                ViewBag.Prodotti = ListaProdotti;
                return View();
            }
            else
            {
                vd.costotot = vd.quantita * prodotto.costo;
                vd.idcliente = (int)Session["idCliente"];
                database.Vendita.Add(vd);

                Prodotti prodotti1 = database.Prodotti.Find(vd.idprodotto);
                prodotti1.quantita -= vd.quantita;
                database.Entry(prodotti1).State = EntityState.Modified;
                database.SaveChanges();
            }

            return RedirectToAction("Create");
        }

        public ActionResult venditeCF()
        {
            return View();
        }

        [HttpPost]
        public JsonResult jsnVenditeCF(string cf)
        {
            List<VetrinaPH> lista = new List<VetrinaPH>();

            List<Vendita> json = db.Vendita.Where(m => m.Cliente.codicefiscale == cf).ToList();
            if (json.Count > 0)
            {
                VetrinaPH vetrina = new VetrinaPH();

                foreach (Vendita vendita in json)
                {
                    vetrina.datavendita = vendita.datavendita;
                    vetrina.idvendita = vendita.idvendita;
                    vetrina.nricetta = vendita.nricetta;
                    vetrina.quantita = vendita.quantita;
                    vetrina.costotot = vendita.costotot;

                    lista.Add(vetrina);
                }
                return Json(lista);
            }
            VetrinaPH vetrina1 = new VetrinaPH();
            vetrina1.idcliente = -1;
            lista.Add(vetrina1);
            return Json(lista);
        }

        public JsonResult jsnVenditeData(string pippo)
        {
            List<VetrinaPH> lista = new List<VetrinaPH>();
            if (pippo == "")
            {
                DateTime dat = Convert.ToDateTime(pippo);

                List<Vendita> json = db.Vendita.Where(m => m.datavendita == dat).ToList();
                if (json.Count > 0)
                {
                    VetrinaPH vetrina = new VetrinaPH();

                    foreach (Vendita vendita in json)
                    {
                        vetrina.datavendita = vendita.datavendita;
                        vetrina.idvendita = vendita.idvendita;
                        vetrina.nricetta = vendita.nricetta;
                        vetrina.quantita = vendita.quantita;
                        vetrina.costotot = vendita.costotot;
                        lista.Add(vetrina);
                    }
                    return Json(lista);
                }
            }
            VetrinaPH vetrina1 = new VetrinaPH();
            vetrina1.idcliente = -1;
            lista.Add(vetrina1);
            return Json(lista);
        }
    }
}