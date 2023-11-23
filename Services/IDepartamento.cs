using API_CRUDMONGO.Models;
using MongoDB.Driver;

namespace API_CRUDMONGO.Services
{
    public interface IDepartamento
    {
        Task<List<DepartamentoBson>> GetDepartamentos();

        Task<DepartamentoBson?> GetDepartamento(string _id);

        Task CreateDepartamento(DepartamentoBson departamento);

        Task <UpdateResult> UpdateDepartamento(string _id, DepartamentoBson departamento);

        Task <DeleteResult> DeleteDepartamento(string _id);


    }
}
