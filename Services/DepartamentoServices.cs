using API_CRUDMONGO.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Security.Cryptography;

namespace API_CRUDMONGO.Services
{
    public class DepartamentoServices : IDepartamento
    {
        private readonly string _conexion = "";
        private readonly MongoClient _client;
        private readonly IMongoDatabase _dataBase;
        private readonly IMongoCollection<BsonDocument> _collection;

        public DepartamentoServices(IConfiguration configuration)
        {
            _conexion = configuration.GetConnectionString("conexionMongo");
            _client = new MongoClient(_conexion);
            _dataBase = _client.GetDatabase("Empleados");
            _collection = _dataBase.GetCollection<BsonDocument>("Departamentos");

        }

        public async Task<List<DepartamentoBson>> GetDepartamentos()
        {
            List<DepartamentoBson> _dblist = new List<DepartamentoBson>();

            var dblist = await _collection.FindAsync(_ => true);

            foreach (var db in dblist.ToList())
            {
                //Console.WriteLine(db.GetValue("descripcion"));
                _dblist.Add(new DepartamentoBson
                {
                    _id = db.GetValue("_id").ToString(),
                    descripcion = db.GetValue("descripcion").ToString()
                });

            }
            return _dblist;

            /**
            using MongoDB.Bson;
            var document = new BsonDocument
            {
               { "account_id", "MDB829001337" },
               { "account_holder", "Linus Torvalds" },
               { "account_type", "checking" },
               { "balance", 50352434 }
            };
             */

        }

        public Task<DepartamentoBson> GetDepartamento(int _id)
        {
            throw new NotImplementedException();
        }

        public Task<DepartamentoBson> CreateDepartamento(DepartamentoBson departamento)
        {
            throw new NotImplementedException();

            
        }

        public Task<DepartamentoBson> UpdateDepartamento(int _id, DepartamentoBson departamento)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDepartamento(int _id)
        {
            throw new NotImplementedException();
        }

    }
}
