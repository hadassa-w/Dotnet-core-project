using AutoMapper;
using Books.API.Models;
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
    public class BookBuyerController : ControllerBase
    {
        private readonly IBookBuyerService _bookBuyerService;
        private readonly IMapper _mapper;
        public BookBuyerController(IBookBuyerService bookBuyerService, IMapper mapper)
        {
            _bookBuyerService = bookBuyerService;
            _mapper = mapper;
        }

        // GET: api/<BookBuyController>
        [HttpGet]
        public ActionResult Get()
        {
            var list = _bookBuyerService.GetAll();
            var listDTO = _mapper.Map<IEnumerable<BookBuyerDTO>>(list);
            return Ok(listDTO);
        }

        // GET api/<BookBuyController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var book = _bookBuyerService.GetById(id);
            var bookDTO = _mapper.Map<BookBuyerDTO>(book);
            return Ok(bookDTO);
        }

        // POST api/<BookBuyController>
        [HttpPost]
        public ActionResult Post([FromBody] BookBuyerPostModel book)
        {
            //var bookList = new List<Book>();

            //foreach (var bookPostModel in book.Books)
            //{
            //    var book1 = new Book
            //    {
            //        BookName = bookPostModel.BookName,
            //        WriterName = bookPostModel.WriterName,
            //        CountPages = bookPostModel.CountPages,
            //        Price = bookPostModel.Price,
            //        Description = bookPostModel.Description,
            //        DateWrite = bookPostModel.DateWrite,
            //        Status = bookPostModel.Status,
            //        BookBuyer = bookPostModel.BookBuyer,
            //        BookSeller = bookPostModel.BookSeller,
            //    };
            //    bookList.Add(book1);
            //}
            var newBook = new BookBuyer
            {
                FullName = book.FullName,
                Phone = book.Phone,
                Telephone = book.Telephone,
                Email = book.Email,
                Address = book.Address,
                City = book.City,
                Country = book.Country,
                //Books = bookList
            };
            return Ok(_bookBuyerService.Add(newBook));
        }

        // PUT api/<BookBuyController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BookBuyer book)
        {
            return Ok(_bookBuyerService.Update(id, book));
        }

        // DELETE api/<BookBuyController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var book = _bookBuyerService.GetById(id);
            if (book is null)
            {
                return NotFound();
            }
            _bookBuyerService.Delete(book);
            return NoContent();
        }
    }
}
