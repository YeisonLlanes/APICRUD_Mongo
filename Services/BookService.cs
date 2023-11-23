using API_CRUDMONGO.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API_CRUDMONGO.Services
{
    public class BookService : IBook
    {
        private readonly IMongoCollection<Book> _booksCollection;
        public BookService(IOptions<SettingsDataBase> DBSettings)
        {
            var mongoClient = new MongoClient(DBSettings.Value.ConnectionStrings);

            var mongoDatabase = mongoClient.GetDatabase(DBSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<Book>(DBSettings.Value.BooksCollectionName);

        }

        public async Task<List<Book>> GetAllAsync()
        {
            try
            {
                return await _booksCollection.Find(_ => true).ToListAsync(); ;
            }
            catch (Exception ex)
            {
                return new List<Book>();///Esto esta mal LUL
            }

        }

        public async Task<Book?> GetAsync(string id)
        {
            //655e64130ffc56b9ba00edd4
            var resultado = new Book();
            var filter = Builders<Book>.Filter.Eq("_id", id);
            try
            {
                resultado = await _booksCollection.Find(filter).FirstOrDefaultAsync();    
                //resultado = await _booksCollection.Find(x => x._id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

            }
            return resultado;
        }

        public async Task CreateAsync(Book newBook)
        {
            try
            {
                await _booksCollection.InsertOneAsync(newBook);
            }
            catch (Exception ex)
            {

            }

        }

        public async Task UpdateAsync(string id, Book updatedBook)
        {
            var filter = Builders<Book>.Filter.Eq("_id", id);
            try
            {
                await _booksCollection.ReplaceOneAsync(filter, updatedBook);
                //await _booksCollection.ReplaceOneAsync(x => x._id == id, updatedBook);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task RemoveAsync(string id)
        {
            var filter = Builders<Book>.Filter.Eq("_id", id);
            try
            {
                await _booksCollection.DeleteOneAsync(filter);
                //await _booksCollection.DeleteOneAsync(x => x._id == id);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
