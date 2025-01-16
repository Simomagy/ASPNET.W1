using MSSTU.DB.Utility;

namespace HotPork.Models
{
    public class DAOPanini : IDAO
    {
        #region Singleton
        private static DAOPanini? _instance;

        private readonly IDatabase _database;
        private DAOPanini()
        {
            _database = new Database("HotPork");
        }

        public static DAOPanini? GetInstance() 
        {
            return _instance ??= new DAOPanini();
        }
        #endregion

        public bool CreateRecord(Entity entity)
        {

            var parametri = new Dictionary<string,object>
            {
                {"@Nome",((Panino)entity).Nome.Replace("'", "''")},
                {"@Carne",((Panino)entity).Carne.Replace("'", "''")},
                {"@Verdura",((Panino)entity).Verdura.Replace("'", "''")},
                {"@Salsa",((Panino)entity).Salsa.Replace("'", "''")},
                {"@Extra",((Panino)entity).Extra.Replace("'", "''")},
                {"@Prezzo",((Panino)entity).Prezzo},
                {"@Formaggio",((Panino)entity).Formaggio.Replace("'", "''")},
                {"@Immagine",((Panino)entity).Immagine.Replace("'", "''")},
                {"@Descrizione",((Panino)entity).Descrizione.Replace("'", "''")}
            };
            const string query = "Insert INTO Panini (Nome,Carne,Verdura,Salsa,Extra,Prezzo,Formaggio,Immagine,Descrizione) " +
                                 "VALUES (@Nome,@Carne,@Verdura,@Salsa,@Extra,@Prezzo,@Formaggio,@Immagine,@Descrizione)";

            return _database.UpdateDb(query, parametri);
        }

        public bool DeleteRecord(int recordId)
        {
            var parametro = new Dictionary<string, object>
            {
                { "@id", recordId }
            };
            const string query = "DELETE FROM Panini WHERE id = @id";

            return _database.UpdateDb(query,parametro);
        }
        public Entity? FindRecord(int recordId)
        {
            var parametro = new Dictionary<string, object>
            {
                { "@id", recordId }
            };

            const string query = "SELECT * FROM Panini WHERE id = @id";

            var ris = _database.ReadOneDb(query, parametro);
            if(ris == null)
                return null;

            Entity f = new Panino();
            f.TypeSort(ris);

            return f;

        }

        public List<Entity> GetRecords()
        {
            const string query = "SELECT * FROM Panini";
            List<Entity> entities = [];
            var ris = _database.ReadDb(query);
            if (ris == null)
                return entities;

            foreach( var r in ris)
            {
                Entity f = new Panino();
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
                {"@Nome",((Panino)entity).Nome.Replace("'", "''")},
                {"@Carne",((Panino)entity).Carne.Replace("'", "''")},
                {"@Verdura",((Panino)entity).Verdura.Replace("'", "''")},
                {"@Salsa",((Panino)entity).Salsa.Replace("'", "''")},
                {"@Extra",((Panino)entity).Extra.Replace("'", "''")},
                {"@Prezzo",((Panino)entity).Prezzo},
                {"@Formaggio",((Panino)entity).Formaggio.Replace("'", "''")},
                {"@Immagine",((Panino)entity).Immagine.Replace("'", "''")},
                {"@Descrizione",((Panino)entity).Descrizione.Replace("'", "''")}
            };

            const string query = "UPDATE Panini SET Nome = @Nome, Carne = @Carne, Verdura = @Verdura, Salsa = @Salsa, Extra = @Extra, Prezzo = @Prezzo, " +
                "Formaggio = @Formaggio, Immagine = @Immagine, Descrizione = @Descrizione WHERE id = @id ";

            return _database.UpdateDb(query, parametri);
        }
    }
}
