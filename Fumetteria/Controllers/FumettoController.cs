using Fumetteria.Models;
using Microsoft.AspNetCore.Mvc;
using MSSTU.DB.Utility;

namespace Fumetteria.Controllers;

public class FumettoController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public ActionResult Elenco()
    {
        return View(DaoFumetti.GetInstance().GetRecords());
    }

    public IActionResult Dettagli(int id)
    {
        return View(DaoFumetti.GetInstance().FindRecord(id));
    }

    public IActionResult? Elimina(int id)
    {
        if (DaoFumetti.GetInstance().DeleteRecord(id))
            return RedirectToAction("Elenco");
        return Content($"Errore nell'eliminazione del fumetto con id {id}");
    }

    public IActionResult FormInserisci()
    {
        return View("FormInserisci");
    }

    public IActionResult Inserisci(Dictionary<string, string> parameters)
    {
        Entity e = new Fumetto();
        e.TypeSort(parameters);

        if (DaoFumetti.GetInstance().CreateRecord(e))
            return RedirectToAction("Elenco");
        return Content($"Errore nella creazione del fumetto {e.ToString()}");
    }

    public IActionResult Modifica(Dictionary<string, string> parameters)
    {
        Entity e = new Fumetto();
        e.TypeSort(parameters);

        if (DaoFumetti.GetInstance().UpdateRecord(e))
            return RedirectToAction("Elenco");
        return Content($"Errore nella modifica del fumetto {e.ToString()}");
    }

    public IActionResult FormModifica(int id)
    {
        Console.WriteLine("ID: " + id);
        var fumetto = DaoFumetti.GetInstance().FindRecord(id);
        if (fumetto == null)
            return Content($"Errore nel reperimento del fumetto con id {id}");
        return View((Fumetto)fumetto);
    }
}
