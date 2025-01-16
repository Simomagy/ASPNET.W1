using MSSTU.DB.Utility;

namespace Ospedale.Models;

public class Ospedale : Entity
{
    public string Sede { get; set; }
    public string Nome { get; set; }
    public bool Pubblico { get; set; }

    public Ospedale()
    {}

    public Ospedale(int id, string sede, string nome, bool pubblico) : base (id)
    {
      Id = id;
      Sede = sede;
      Nome = nome;
      Pubblico = pubblico;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nSede: {Sede},\nNome: {Nome},\nAmministrazione: {(Pubblico?"Pubblica":"Privata")}";
    }
}
