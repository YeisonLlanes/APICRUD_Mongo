using API_CRUDMONGO.Models;

namespace API_CRUDMONGO.Services
{
    public interface IBook
    {
        Task<List<Book>> GetAllAsync();

        Task<Book?> GetAsync(string id);

        Task CreateAsync(Book newBook);

        Task UpdateAsync(string id, Book updatedBook);

        Task RemoveAsync(string id);
    }
}
