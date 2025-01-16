namespace Ospedale.Models;
using MSSTU.DB.Utility;

public class DaoOspedali : IDAO
{
    public string TableName = "Ospedale";
    private Database _database;

    private DaoOspedali()
    {
        _database = new Database("Ospedale");
    }
    private static DaoOspedali _instance;

    public static DaoOspedali GetInstance()
    {
        if (_instance == null)
            _instance = new DaoOspedali();
        return _instance;
    }

    public bool CreateRecord(Entity entity)
        {

            var parametri = new Dictionary<string,object>
            {
                {"@Sede",((Ospedale)entity).Sede.Replace("'", "''")},
                {"@Nome",((Ospedale)entity).Nome.Replace("'", "''")},
                {"@Pubblico",(((Ospedale)entity).Pubblico?"1":"0")}
            };
            const string query = "Insert INTO Ospedali (Sede,Nome,Pubblico) " +
                                 "VALUES (@Sede,@Nome,@Pubblico)";

            return _database.UpdateDb(query, parametri);
        }

        public bool DeleteRecord(int recordId)
        {
            var parametro = new Dictionary<string, object>
            {
                { "@id", recordId }
            };
            const string query = "DELETE FROM Ospedali WHERE id = @id";

            return _database.UpdateDb(query,parametro);
        }
        public Entity? FindRecord(int recordId)
        {
            var parametro = new Dictionary<string, object>
            {
                { "@id", recordId }
            };

            const string query = "SELECT * FROM Ospedali WHERE id = @id";

            var ris = _database.ReadOneDb(query, parametro);
            if(ris == null)
                return null;

            Entity f = new Ospedale();
            f.TypeSort(ris);

            return f;

        }

        public List<Entity> GetRecords()
        {
            const string query = "SELECT * FROM Ospedali";
            List<Entity> entities = [];
            var ris = _database.ReadDb(query);
            if (ris == null)
                return entities;

            foreach( var r in ris)
            {
                Entity f = new Ospedale();
                f.TypeSort(r);

                entities.Add(f);
            }
            return entities;
        }

        public bool UpdateRecord(Entity entity)
        {
            var parametri = new Dictionary<string, object>
            {
                {"@id",entity.Id},
                {"@Sede",((Ospedale)entity).Sede.Replace("'", "''")},
                {"@Nome",((Ospedale)entity).Nome.Replace("'", "''")},
                {"@Pubblico",(((Ospedale)entity).Pubblico?"1":"0")}
            };

            const string query = "UPDATE Ospedali SET Sede = @Sede, Nome = @Nome, Pubblico = @Pubblico WHERE id = @id ";

            return _database.UpdateDb(query, parametri);
        }
}
