namespace Ospedale.Models;
using MSSTU.DB.Utility;

public class DaoOspedali : IDAO
{
    # region Singleton
    private Database _db;
    private DaoOspedali()
    {
        _db = new Database("Ospedale");
    }
    private static DaoOspedali _instance;

    public static DaoOspedali GetInstance()
    {
        return _instance ??= new DaoOspedali();
    }
    #endregion
    public bool CreateRecord(Entity entity)
    {

        var parameters = new Dictionary<string,object>
        {
            {"@Sede",((Ospedale)entity).Sede.Replace("'", "''")},
            {"@Nome",((Ospedale)entity).Nome.Replace("'", "''")},
            {"@Pubblico",(((Ospedale)entity).Pubblico?"1":"0")}
        };
        const string query = "Insert INTO Ospedali (Sede,Nome,Pubblico) " +
                             "VALUES (@Sede,@Nome,@Pubblico)";

        return _db.UpdateDb(query, parameters);
    }

    public bool DeleteRecord(int recordId)
    {
        var parameters = new Dictionary<string, object>
        {
            { "@id", recordId }
        };
        const string query = "DELETE FROM Ospedali WHERE id = @id";

        return _db.UpdateDb(query,parameters);
    }
    public Entity? FindRecord(int recordId)
    {
        var parameters = new Dictionary<string, object>
        {
            { "@id", recordId }
        };

        const string query = "SELECT * FROM Ospedali WHERE id = @id";

        var singleResponse = _db.ReadOneDb(query, parameters);
        if(singleResponse == null)
            return null;

        Entity ospedale = new Ospedale();
        ospedale.TypeSort(singleResponse);

        return ospedale;

    }

    public List<Entity> GetRecords()
    {
        const string query = "SELECT * FROM Ospedali";
        List<Entity> entities = [];
        var fullResponse = _db.ReadDb(query);
        if (fullResponse == null)
            return entities;

        foreach( var singleResponse in fullResponse)
        {
            Entity ospedale = new Ospedale();
            ospedale.TypeSort(singleResponse);

            entities.Add(ospedale);
        }
        return entities;
    }

    public bool UpdateRecord(Entity entity)
    {
        var parameters = new Dictionary<string, object>
        {
            {"@id",entity.Id},
            {"@Sede",((Ospedale)entity).Sede.Replace("'", "''")},
            {"@Nome",((Ospedale)entity).Nome.Replace("'", "''")},
            {"@Pubblico",(((Ospedale)entity).Pubblico?"1":"0")}
        };

        const string query = "UPDATE Ospedali SET Sede = @Sede, Nome = @Nome, Pubblico = @Pubblico WHERE id = @id ";

        return _db.UpdateDb(query, parameters);
    }
}
