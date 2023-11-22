using API_CRUDMONGO.Models;
using API_CRUDMONGO.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CRUDMONGO.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook _book;
        public BookController(IBook book)
        {
            _book = book;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Book>> ObtenerTodos()
        {
            var resultado = await _book.GetAllAsync();
            return Ok(resultado);
        }

        [HttpGet("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Book>> ObtenerLibro(string id)
        {
            var book = await _book.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody]Book newBook)
        {
            await _book.CreateAsync(newBook);
            Console.WriteLine(CreatedAtAction(nameof(ObtenerLibro), new { id = newBook._id }, newBook));
            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ActualizarLibro(string id, Book updateBook)
        {
            var book = await _book.GetAsync(id);
            if(book is null)
            {
                return NotFound();
            }

            updateBook._id = book._id;

            await _book.UpdateAsync(id, updateBook);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> EliminarLibro(string id)
        {
            var book = await _book.GetAsync(id);
            if (book is null)
            {
                return NotFound();
            }

            await _book.RemoveAsync(id);

            return NoContent();
        }

    }
}
