using Amazon.Runtime.Internal.Transform;
using API_CRUDMONGO.Models;
using API_CRUDMONGO.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CRUDMONGO.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamento _dpto;
        public DepartamentoController(IDepartamento departamento)
        {
            _dpto = departamento;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Departamento>> ObtenerTodos()
        {
            var dpto = await _dpto.GetDepartamentos();
            return Ok(dpto);
        }

    }
}
