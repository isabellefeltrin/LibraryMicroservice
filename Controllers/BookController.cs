using Biblioteca.DTO.Books;
using Biblioteca.Repositories;
using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;


namespace BooksService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _service;

        public BooksController(BookService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _service.GetById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create(BookDTO dto)
        {
            _service.Create(dto);
            return Created("", dto);
        }

        [HttpPatch("{id}/quantity")]
        public IActionResult UpdateQuantity(int id, int newQuantity)
        {
            _service.UpdateQuantity(id, newQuantity);
            return NoContent();
        }
    }
}