using MSSTU.DB.Utility;

namespace Ospedale.Models;

public class Medico : Entity
{
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public DateTime Dob { get; set; }
    public string Residenza { get; set; }
    public string Reparto { get; set; }
    public bool Primario { get; set; }
    public int PazientiGuariti { get; set; }
    public int TotaleDecessi { get; set; }
    public Ospedale Ospedale { get; set; }

    public override string ToString()
    {
        return base.ToString() +
               $"\nNome: {Nome} " +
               $"\nCognome: {Cognome} " +
               $"\nData di nascita: {Dob:dd/MM/yyyy} " +
               $"\nResidenza: {Residenza} " +
               $"\nReparto: {Reparto} " +
               $"\nRuolo: {(Primario ? "Primario" : "Dipendente")}" +
               $"\nPazientiGuariti: {PazientiGuariti} " +
               $"\nTotaleDecessi: {TotaleDecessi} " +
               $"\nOspedale: {Ospedale} ";
    }
}
