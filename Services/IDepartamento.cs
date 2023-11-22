using API_CRUDMONGO.Models;

namespace API_CRUDMONGO.Services
{
    public interface IDepartamento
    {
        Task<List<DepartamentoBson>> GetDepartamentos();

        Task<DepartamentoBson> GetDepartamento(int _id);

        Task<DepartamentoBson> CreateDepartamento(DepartamentoBson departamento);

        Task<DepartamentoBson> UpdateDepartamento(int _id, DepartamentoBson departamento);

        Task<bool> DeleteDepartamento(int _id);


    }
}
