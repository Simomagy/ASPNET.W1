using MSSTU.DB.Utility;

namespace Ospedale.Models;

public class Ospedale : Entity
{
    public string Sede { get; set; }
    public string Nome { get; set; }
    public bool Pubblico { get; set; }

    public override string ToString()
    {
        return base.ToString() + $"\nSede: {Sede},\nNome: {Nome},\nAmministrazione: {(Pubblico?"Pubblica":"Privata")}";
    }
}
