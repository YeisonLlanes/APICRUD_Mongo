using Amazon.Runtime.Internal.Transform;
using API_CRUDMONGO.Models;
using API_CRUDMONGO.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Runtime.CompilerServices;
using ZstdSharp.Unsafe;

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
        public async Task<ActionResult<DepartamentoBson>> obtenerTodos()
        {
            var dpto = await _dpto.GetDepartamentos();
            return Ok(dpto);
        }

        [HttpGet("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<DepartamentoBson>> obtenerDepartamento(string id)
        {
            var dpto = await _dpto.GetDepartamento(id);

            if(dpto == null)  
            {
                return NotFound();
            }

            return Ok(dpto);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> insertarDepartamento(DepartamentoBson departamento)
        {
            await _dpto.CreateDepartamento(departamento);
            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> actualizarDepartamento(string id, DepartamentoBson departamento)
        {
            var dpto = await _dpto.GetDepartamento(id);

            if(dpto == null)
            {
                return NotFound();
            }

            departamento._id = dpto._id;

            await _dpto.UpdateDepartamento(id, departamento);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<IActionResult> eliminarDepartamento(string id)
        {
            var dpto = await _dpto.GetDepartamento(id);

            if (dpto == null)
            {
                return NotFound();
            }

            await _dpto.DeleteDepartamento(id);

            return NoContent();
        }
    }
}
