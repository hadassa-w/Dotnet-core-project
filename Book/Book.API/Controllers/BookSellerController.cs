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
    public class BookSellerController : ControllerBase
    {
        private readonly IBookSellerService _bookSellerService;
        private readonly IMapper _mapper;

        public BookSellerController(IBookSellerService bookSellerService, IMapper mapper)
        {
            _bookSellerService = bookSellerService;
            _mapper = mapper;
        }

        // GET: api/<BookSaleController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = await _bookSellerService.GetAllAsync();
            var listDTO = _mapper.Map<IEnumerable<BookSellerDTO>>(list);
            return Ok(listDTO);
        }

        // GET api/<BookSaleController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var book = _bookSellerService.GetById(id);
            var bookDTO = _mapper.Map<BookSellerDTO>(book);
            return Ok(bookDTO);
        }

        // POST api/<BookSaleController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BookSellerPostModel book)
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
            var newBook = new BookSeller
            {
                FullName = book.FullName,
                Phone = book.Phone,
                Telephone = book.Telephone,
                Email = book.Email,
                Address = book.Address,
                City = book.City,
                Country = book.Country,
                //Books = bookList.ToList()
            };
            var bookSellerNew = await _bookSellerService.AddAsync(newBook);
            return Ok(bookSellerNew);
        }

        // PUT api/<BookSaleController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BookSellerPostModel book)
        {
            var newBook = new BookSeller
            {
                FullName = book.FullName,
                Phone = book.Phone,
                Telephone = book.Telephone,
                Email = book.Email,
                Address = book.Address,
                City = book.City,
                Country = book.Country,
                //Books = bookList.ToList()
            };
            return Ok(_bookSellerService.Update(id, newBook));
        }

        // DELETE api/<BookSaleController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var book = _bookSellerService.GetById(id);
            if (book is null)
            {
                return NotFound();
            }
            _bookSellerService.Delete(book);
            return NoContent();
        }
    }
}
