using MSSTU.DB.Utility;

namespace Fumetteria.Models;

public class Fumetto : Entity
{
    public string? Titolo { get; set; }
    public string? Testata { get; set; }
    public string? CasaEditrice { get; set; }
    public int Numero { get; set; }

    public Fumetto() { }
    public Fumetto(int id, string? titolo, string? testata, string? casaEditrice, int numero) : base(id)
    {
        Titolo = titolo;
        Testata = testata;
        CasaEditrice = casaEditrice;
        Numero = numero;
    }
}
