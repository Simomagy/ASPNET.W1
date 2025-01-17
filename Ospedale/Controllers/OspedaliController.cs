using Ospedale.Models;
using Microsoft.AspNetCore.Mvc;
using MSSTU.DB.Utility;

namespace Ospedale.Controllers
{
    public class OspedaliController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListaOspedali()
        {
            return View(DaoOspedali.GetInstance().GetRecords());
        }
        public IActionResult Dettagli(int id)
        {
            return View(DaoOspedali.GetInstance().FindRecord(id));
        }
        public IActionResult? Elimina(int id)
        {
            if (DaoOspedali.GetInstance().DeleteRecord(id))
                return RedirectToAction("Lista");
            return Content($"Errore nell'eliminazione dell' ospedale con id {id}");
        }
        public IActionResult FormInserisci()
        {
            return View("FormInserisci");
        }
        public IActionResult Inserisci(Dictionary<string, string> parameters)
        {
            Entity e = new Models.Ospedale();
            e.TypeSort(parameters);

            if (DaoOspedali.GetInstance().CreateRecord(e))
                return RedirectToAction("Lista");
            return Content($"Errore nella creazione dell'ospedale {e.ToString()}");
        }
        public IActionResult Modifica(Dictionary<string, string> parameters)
        {
            Entity e = new Models.Ospedale();
            e.TypeSort(parameters);
            if (DaoOspedali.GetInstance().UpdateRecord(e))
                return RedirectToAction("Lista");
            return Content($"Errore nella modifica dell'ospedale {e.ToString()}");
        }
        public IActionResult FormModifica(int id)
        {
            var ospedale = DaoOspedali.GetInstance().FindRecord(id);
            if (ospedale == null)
                return Content($"Errore nel reperimento dell'ospedale con id {id}");
            return View((Models.Ospedale)ospedale);
        }
    }
}
