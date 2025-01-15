using MSSTU.DB.Utility;

namespace Fumetteria.Models;

public class DaoFumetti : IDAO
{
    public List<Entity> GetRecords()
    {
        const string query = "SELECT * FROM Fumetti";
        List<Entity> athletesRecords = [];
        var fullResponse = _db.ReadDb(query);
        if (fullResponse == null)
            return athletesRecords;
        foreach (var singleResponse in fullResponse)
        {
            Entity entity = new Fumetto();
            entity.TypeSort(singleResponse);
            athletesRecords.Add(entity);
        }

        return athletesRecords;
    }

    public bool CreateRecord(Entity entity)
    {
        var parameters = new Dictionary<string, object>
        {
            { "@titolo", ((Fumetto)entity).Titolo.Replace("'", "''") },
            { "@testata", ((Fumetto)entity).Testata.Replace("'", "''") },
            { "@casaEditrice", ((Fumetto)entity).CasaEditrice.Replace("'", "''") },
            { "@numero", ((Fumetto)entity).Numero }
        };
        const string query =
            "INSERT INTO Fumetti (titolo, testata, casaEditrice, numero) VALUES (@titolo, @testata, @casaEditrice, @numero)";

        return _db.UpdateDb(query, parameters);
    }

    public bool UpdateRecord(Entity entity)
    {
        var parameters = new Dictionary<string, object>
        {
            { "@titolo", ((Fumetto)entity).Titolo.Replace("'", "''") },
            { "@testata", ((Fumetto)entity).Testata.Replace("'", "''") },
            { "@casaEditrice", ((Fumetto)entity).CasaEditrice.Replace("'", "''") },
            { "@numero", ((Fumetto)entity).Numero },
            { "@Id", entity.Id }
        };
        const string query =
            "UPDATE Fumetti SET titolo = @titolo, testata = @testata, numero = @numero, casaEditrice = @casaEditrice WHERE Id = @Id";

        return _db.UpdateDb(query, parameters);
    }

    public bool DeleteRecord(int recordId)
    {
        const string query = "DELETE FROM Fumetti WHERE Id = @Id";
        var parameters = new Dictionary<string, object> { { "@Id", recordId } };
        return _db.UpdateDb(query, parameters);
    }

    public Entity? FindRecord(int recordId)
    {
        const string query = "SELECT * FROM Fumetti WHERE Id = @Id";
        var parameters = new Dictionary<string, object> { { "@Id", recordId } };
        var singleResponse = _db.ReadOneDb(query, parameters);
        if (singleResponse == null)
            return null;
        Entity entity = new Fumetto();
        entity.TypeSort(singleResponse);
        return entity;
    }

    #region Singleton

    private static DaoFumetti? _instance;
    private readonly IDatabase _db;

    private DaoFumetti()
    {
        _db = new Database("Fumetteria_Web");
    }

    /// <summary>
    ///     Restituisce l'istanza del DAO
    /// </summary>
    /// <returns>
    ///     Se l'istanza è <see langword="null" /> restituisce una nuova istanza, altrimenti restituisce l'istanza esistente
    /// </returns>
    public static DaoFumetti GetInstance()
    {
        return _instance ??= new DaoFumetti();
    }

    #endregion
}
