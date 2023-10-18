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
                lista = db.Prodotti.ToList();
                foreach (Prodotti p in lista)
                {
                    SelectListItem item = new SelectListItem { Text = $"{p.nome} - {p.costo:C}", Value = $"{p.idprodotto}" };
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
                return RedirectToAction("Create");
            }
            else { return View(); }
        
        }

        public ActionResult Create()
        {
            ViewBag.Prodotti = ListaProdotti;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vendita vd)
        {
            vd.datavendita = DateTime.Now;
            var prodotto = db.Prodotti.Find(vd.idprodotto);
            vd.costotot = vd.quantita * prodotto.costo;
            vd.idcliente = (int)Session["idCliente"];
            db.Vendita.Add(vd);
            db.SaveChanges();
            return RedirectToAction("Create");
        }

        public ActionResult venditeCF()
        {
            return View();
        }

        [HttpPost]
        public JsonResult jsnVenditeCF(string cf)
        {
            List<Vendita> json = db.Vendita.Where(m => m.Cliente.codicefiscale == cf).ToList();
            VetrinaPH vetrina = new VetrinaPH();
            List<VetrinaPH> lista = new List<VetrinaPH>();
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

        public JsonResult jsnVenditeData(string pippo)
        {
            DateTime dat = Convert.ToDateTime(pippo);
            List<Vendita> json = db.Vendita.Where(m => m.datavendita == dat).ToList();
            VetrinaPH vetrina = new VetrinaPH();
            List<VetrinaPH> lista = new List<VetrinaPH>();
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
}