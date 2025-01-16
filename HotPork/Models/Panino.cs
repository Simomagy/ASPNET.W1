using MSSTU.DB.Utility;

namespace HotPork.Models;

public class Panino : Entity
{
    public string Nome { get; set; }
    public string Carne { get; set; }
    public string Verdura { get; set; }
    public string Salsa { get; set; }
    public string Extra { get; set; }
    public double Prezzo { get; set; }
    public string Formaggio { get; set; }
    public string Immagine { get; set; }
    public string Descrizione { get; set; }
    
    public Panino() { }
}
