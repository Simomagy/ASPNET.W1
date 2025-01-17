using MSSTU.DB.Utility;

namespace Ospedale.Models;

public class DaoMedici : IDAO
{
    # region Singleton
    private Database _db;
    private DaoMedici()
    {
        _db = new Database("Ospedale", "DESKTOP-0EJOTBJ");
    }
    private static DaoMedici _instance;

    public static DaoMedici GetInstance()
    {
        return _instance ??= new DaoMedici();
    }
    #endregion
    public List<Entity> GetRecords()
    {
        const string query = @"
                SELECT
                    m.id as idMedico, m.nome, m.cognome, m.dob, m.residenza, m.reparto, m.primario, m.pazientiGuariti, m.totaleDecessi,
                    o.id as idOspedale, o.sede, o.nome as nomeOspedale, o.pubblico
                FROM Medici m
                JOIN Ospedali o ON m.ospedale = o.id;";
        List<Entity> mediciRecords = [];
        var fullResponse = _db.ReadDb(query);
        if (fullResponse == null)
            return mediciRecords;
        foreach (var singleResponse in fullResponse)
        {
            var medico = new Medico();
            medico.TypeSort(singleResponse);
            medico.Id = int.Parse(singleResponse["idmedico"]);

            var ospedale = new Ospedale();
            ospedale.TypeSort(singleResponse);
            medico.Ospedale = ospedale;
            medico.Ospedale.Id = int.Parse(singleResponse["idospedale"]);
            medico.Ospedale.Nome = singleResponse["nomeospedale"];

            mediciRecords.Add(medico);
        }

        return mediciRecords;
    }

    public bool CreateRecord(Entity entity)
    {
        var parameters = new Dictionary<string,object>
        {
            { "@Nome", ((Medico)entity).Nome.Replace("'", "''") },
            { "@Cognome", ((Medico)entity).Cognome.Replace("'", "''") },
            { "@Dob", ((Medico)entity).Dob },
            { "@Residenza", ((Medico)entity).Residenza.Replace("'", "''") },
            { "@Reparto", ((Medico)entity).Reparto.Replace("'", "''") },
            { "@Primario", ((Medico)entity).Primario },
            { "@PazientiGuariti", ((Medico)entity).PazientiGuariti },
            { "@TotaleDecessi", ((Medico)entity).TotaleDecessi },
            { "@Ospedale", ((Medico)entity).Ospedale.Id }
        };
        const string query =
            "Insert INTO Medici (nome, cognome, dob, residenza, reparto, primario, pazientiGuariti, totaleDecessi, ospedale) VALUES (@Nome, @Cognome, @Dob, @Residenza, @Reparto, @Primario, @PazientiGuariti, @TotaleDecessi, @Ospedale)";

        return _db.UpdateDb(query, parameters);
    }

    public bool UpdateRecord(Entity entity)
    {
        var parameters = new Dictionary<string, object>
        {
            { "@Nome", ((Medico)entity).Nome.Replace("'", "''") },
            { "@Cognome", ((Medico)entity).Cognome.Replace("'", "''") },
            { "@Dob", ((Medico)entity).Dob },
            { "@Residenza", ((Medico)entity).Residenza.Replace("'", "''") },
            { "@Reparto", ((Medico)entity).Reparto.Replace("'", "''") },
            { "@Primario", ((Medico)entity).Primario },
            { "@PazientiGuariti", ((Medico)entity).PazientiGuariti },
            { "@TotaleDecessi", ((Medico)entity).TotaleDecessi },
            { "@Ospedale", ((Medico)entity).Ospedale.Id },
            { "@id", entity.Id }
        };

        const string query = "UPDATE Medicis SET nome = @Nome, cognome = @Cognome, dob = @Dob, residenza = @Residenza, reparto = @Reparto, primario = @Primario, pazientiGuariti = @PazientiGuariti, totaleDecessi = @TotaleDecessi, ospedale = @Ospedale WHERE id = @id";

        return _db.UpdateDb(query, parameters);
    }

    public bool DeleteRecord(int recordId)
    {
        var parameters = new Dictionary<string, object>
        {
            { "@id", recordId }
        };
        const string query = "DELETE FROM Medici WHERE id = @id";

        return _db.UpdateDb(query,parameters);
    }

    public Entity? FindRecord(int recordId)
    {
        var parameters = new Dictionary<string, object>
        {
            { "@id", recordId }
        };

        const string query = @"
                SELECT 
                    m.id as idMedico, m.nome, m.cognome, m.dob, m.residenza, m.reparto, m.primario, m.pazientiGuariti, m.totaleDecessi, 
                    o.id as idOspedale, o.sede, o.nome as nomeOspedale, o.pubblico 
                FROM Medici m 
                  JOIN Ospedali o on m.ospedale = o.id 
                WHERE m.id = @id";

        var singleResponse = _db.ReadOneDb(query, parameters);
        if(singleResponse == null)
            return null;

        var medico = new Medico();
        medico.TypeSort(singleResponse);
        medico.Id = int.Parse(singleResponse["idmedico"]);

        var ospedale = new Ospedale();
        ospedale.TypeSort(singleResponse);
        medico.Ospedale = ospedale;
        medico.Ospedale.Id = int.Parse(singleResponse["idospedale"]);
        medico.Ospedale.Nome = singleResponse["nomeospedale"];

        return medico;
    }

    public List<Medico> GetTop10()
    {
        var entities = GetRecords();
        var medici = entities.Cast<Medico>().ToList();
        return medici.OrderByDescending<Medico, object>(medico => medico.PazientiGuariti).Take(10).ToList();
    }
}
