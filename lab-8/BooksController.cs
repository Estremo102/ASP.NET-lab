using lab_8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lab_8
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService service;
        public BooksController(IBookService service)
        {
            this.service = service;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get() => service.FindAll();

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        //public ActionResult<Book> Get(int id) => service.FindBy(id) == null ? NotFound() : Ok(service.FindBy(id));
        public ActionResult<Book> Get(int id)
        {
            var book = service.FindBy(id);
            if (book == null)
                return NotFound();
            return Ok(book);
    }

    // POST api/<BooksController>
    [HttpPost]
        public ActionResult<Book> Post([FromBody] Book book)
        {
            if(ModelState.IsValid)
            {
                int id =service.Save(book);
                return Created($"/api/books/{id}", book);
            }
            return BadRequest();
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public ActionResult<Book> Put(int id, [FromBody] Book book)
        {
            book.Id = id;
            if (!ModelState.IsValid)
                return BadRequest();
            if (service.Update(book))
                return Ok();
            return NotFound();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (service.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}
