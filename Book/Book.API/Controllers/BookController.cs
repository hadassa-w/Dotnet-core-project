using AutoMapper;
using Books.API.Models;
using Books.Core;
using Books.Core.DTOs;
using Books.Core.Models;
using Books.Core.Services;
using Books.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        //private readonly Mapping _mapping;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        // GET: api/<BookController>
        [HttpGet]
        public ActionResult Get()
        {
            var list = _bookService.GetAll();
            var listDTO = _mapper.Map<IEnumerable<BookDTO>>(list);
            //var listDTO = new List<BookDTO>();
            //foreach (var book in list)
            //{
            //    //listDTO.Add(_mapping.MappingBookDTO(book));
            //    listDTO.Add(_mapper.Map<BookDTO>(book));
            //}
            return Ok(listDTO);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var book = _bookService.GetById(id);
            //var bookDTO = _mapping.MappingBookDTO(book);
            var bookDTO = _mapper.Map<BookDTO>(book);
            return Ok(bookDTO);
        }

        // POST api/<BookController>
        [HttpPost]
        public ActionResult Post([FromBody] BookPostModel book)
        {
            var newBook = new Book { BookName = book.BookName, WriterName = book.WriterName, CountPages = book.CountPages, Price = book.Price, Description = book.Description, DateWrite = book.DateWrite, Status = book.Status };
            return Ok(_bookService.Add(newBook));
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book book)
        {
            return Ok(_bookService.Update(id, book));
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var book = _bookService.GetById(id);
            if (book is null)
                return NotFound();
            _bookService.Delete(book);
            return NoContent();
        }
    }
}
