using HotPork.Models;
using Microsoft.AspNetCore.Mvc;
using MSSTU.DB.Utility;
using Negozio.Models;

namespace HotPork.Controllers;

public class MenuController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Lista()
    {
        return View(DAOPanini.GetInstance().GetRecords());
    }

    public IActionResult Dettagli(int id)
    {
        return View(DAOPanini.GetInstance().FindRecord(id));
    }

    public IActionResult? Elimina(int id)
    {
        if (DAOPanini.GetInstance().DeleteRecord(id))
            return RedirectToAction("Lista");
        return Content($"Errore nell'eliminazione del panino con id {id}");
    }

    public IActionResult FormInserisci()
    {
        return View("FormInserisci");
    }

    public IActionResult Inserisci(Dictionary<string, string> parameters)
    {
        Entity e = new Panino();
        e.TypeSort(parameters);

        if (DAOPanini.GetInstance().CreateRecord(e))
            return RedirectToAction("Lista");
        return Content($"Errore nella creazione del panino {e.ToString()}");
    }

    public IActionResult Modifica(Dictionary<string, string> parameters)
    {
        Entity e = new Panino();
        e.TypeSort(parameters);

        if (DAOPanini.GetInstance().UpdateRecord(e))
            return RedirectToAction("Lista");
        return Content($"Errore nella modifica del panino {e.ToString()}");
    }
    
    public IActionResult FormModifica(int id)
    {
        var panino = DAOPanini.GetInstance().FindRecord(id);
        if (panino == null)
            return Content($"Errore nel reperimento del panino con id {id}");
        return View((Panino)panino);
    }
}
