using API_CRUDMONGO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Security.Cryptography;

namespace API_CRUDMONGO.Services
{
    public class DepartamentoServices : IDepartamento
    {
        //private readonly string _conexion = "";
        //private readonly MongoClient _client;
        //private readonly IMongoDatabase _dataBase;
        private readonly IMongoCollection<DepartamentoBson> _collection;

        public DepartamentoServices(IOptions<SettingsDataBase> DBSettings)
        {
            /*
                _conexion = DBSettings.Value.ConnectionStrings;
                _client = new MongoClient(_conexion);
                _dataBase = _client.GetDatabase(DBSettings.Value.DBEmpleados);
                _collection = _dataBase.GetCollection<DepartamentoBson>(DBSettings.Value.DptoCollectionName);
            */

            var mongoClient = new MongoClient(DBSettings.Value.ConnectionStrings);

            var mongoDatabase = mongoClient.GetDatabase(DBSettings.Value.DBEmpleados);

            _collection = mongoDatabase.GetCollection<DepartamentoBson>(DBSettings.Value.DptoCollectionName);


        }

        public async Task<List<DepartamentoBson>> GetDepartamentos()
        {
            List<DepartamentoBson> _dblist = new ();

            var dblist = await _collection.FindAsync(_ => true);

            foreach (var db in dblist.ToList())
            {
                //Console.WriteLine(db.GetValue("descripcion"));
                _dblist.Add(new DepartamentoBson
                {
                    _id = db._id,
                    descripcion = db.descripcion
                }) ;

            }
            return _dblist;

        }

        public async Task<DepartamentoBson?> GetDepartamento(string _id)
        {
            var resultado = new DepartamentoBson();
            var filtro = Builders<DepartamentoBson>.Filter.Eq("_id", _id);

            resultado = await _collection.Find(filtro).FirstOrDefaultAsync();

            return resultado;

        }

        public async Task CreateDepartamento(DepartamentoBson departamento)
        {
            DepartamentoBson _departamento = new()
            {
                descripcion = departamento.descripcion
            };

            await _collection.InsertOneAsync(_departamento);
            
        }

        public async Task<UpdateResult> UpdateDepartamento(string _id, DepartamentoBson departamento)
        {
            DepartamentoBson dpto = new()
            {
               _id = departamento._id,
               descripcion = departamento.descripcion
            };

            var filtros = Builders<DepartamentoBson>.Filter.Eq(a => a._id, dpto._id);
            var update = Builders<DepartamentoBson>.Update.Set(a => a.descripcion, dpto.descripcion);

            var resultado = await _collection.UpdateOneAsync(filtros, update);

            return resultado;
        }

        public Task<DeleteResult> DeleteDepartamento(string _id)
        {
            var filtro = Builders<DepartamentoBson>.Filter.Eq("_id", _id);
            
            var resultado = _collection.DeleteOneAsync(filtro);

            return resultado;

        }

    }
}
