using Ospedale.Models;
using Microsoft.AspNetCore.Mvc;
using MSSTU.DB.Utility;

namespace Ospedale.Controllers
{
    public class MediciController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Lista()
        {
            return View(DAOMedici.GetInstace().GetRecords());
        }

        public IActionResult Dettagli(int id)
        {
            return View(DaoMedici.GetInstance().FindRecord(id));
        }
        public IActionResult? Elimina(int id)
        {
            if (DAOMedici.GetInstance().DeleteRecord(id))
                return RedirectToAction("Lista");
            return Content($"Errore nell'eliminazione del medico con id {id}");
        }
        public IActionResult FormInserisci()
        {
            return View("FormInserisci");
        }
        public IActionResult Inserisci(Dictionary<string, string> parameters)
        {
            Entity e = new Medico();
            e.TypeSort(parameters);

            if (DAOMedici.GetInstance().CreateRecord(e))
                return RedirectToAction("Lista");
            return Content($"Errore nella creazione del medico {e.ToString()}");
        }
        public IActionResult Modifica(Dictionary<string, string> parameters)
        {
            Entity e = new Medico();
            e.TypeSort(parameters);

            if (DAOMedici.GetInstance().UpdateRecord(e))
                return RedirectToAction("Lista");
            return Content($"Errore nella modifica del medico {e.ToString()}");
        }
        public IActionResult FormModifica()
        {
            var medico = DAOMedici.GetInstance().FindRecord(id);
            if (medico == null)
                return Content($"Errore nel reperimento del medico con id {id}");
            return View((Medico)medico);
        }
    }
}
