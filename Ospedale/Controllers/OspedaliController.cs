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
        public IActionResult Lista()
        {
            return View(DAOOspedali.GetInstance.GetRecords());
        }
        public IActionResult Dettagli(int id)
        {
            return View(DAOOspedali.GetInstance.FindRecords(id));
        }
        public IActionResult? Elimina(int id)
        {
            if (DAOOspedali.GetInstance().DeleteRecord(id))
                return RedirectToAction("Lista");
            return Content($"Errore nell'eliminazione dell' ospedale con id {id}");
        }
        public IActionResult FormInserisci()
        {
            return View("FormInserisci");
        }
        public IActionResult Inserisci(Dictionary<string, string> parameters)
        {
            Entity e = new Ospedale();
            e.TypeSort(parameters);

            if (DAOOspedali.GetInstance().CreateRecord(e))
                return RedirectToAction("Lista");
            return Content($"Errore nella creazione dell'ospedale {e.ToString()}");
        }
        public IActionResult Modifica(Dictionary<string, string> parameters)
        {
            Entity e = new Ospedali();
            e.TypeSort(parameters);
            if (DAOOspedali.GetInstance().UpdateRecord(e))
                return RedirectToAction("Lista");
            return Content($"Errore nella modifica dell'ospedale {e.ToString()}");
        }
        public IActionResult FormModifica(int id)
        {
            var ospedale = DAOOspedali.GetInstance().FindRecord(id);
            if (ospedale == null)
                return Content($"Errore nel reperimento dell'ospedale con id {id}");
            return View((Ospedale)ospedale);
        }
    }
}
