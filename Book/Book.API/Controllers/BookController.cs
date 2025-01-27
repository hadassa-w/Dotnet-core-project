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

        private readonly IBookBuyerService _bookBuyerService;
        private readonly IBookSellerService _bookSellerService;

        //private readonly Mapping _mapping;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IMapper mapper, IBookBuyerService bookBuyerService, IBookSellerService bookSellerService)
        {
            _bookService = bookService;
            _mapper = mapper;
            _bookBuyerService = bookBuyerService;
            _bookSellerService = bookSellerService;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = await _bookService.GetAllAsync();
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
        public async Task<ActionResult> Post([FromBody] BookPostModel book)
        {
            var bookBuyer = _bookBuyerService.GetById(book.BookBuyerId); // הנחה שהשיטה מחזירה BookBuyer
            var bookSeller = _bookSellerService.GetById(book.BookSellerId); // הנחה שהשיטה מחזירה BookSeller
            var newBook = new Book
            {
                BookName = book.BookName,
                WriterName = book.WriterName,
                CountPages = book.CountPages,
                Price = book.Price,
                Description = book.Description,
                DateWrite = book.DateWrite,
                Status = book.Status,
                BookBuyer = bookBuyer,
                BookSeller = bookSeller
            };
            var bookNew = await _bookService.AddAsync(newBook);
            var newBookBuyerDTO = new BookBuyerDTO
            {
                FullName = bookBuyer.FullName,
                Phone = bookBuyer.Phone,
                Telephone = bookBuyer.Telephone,
                Email = bookBuyer.Email,
                Address = bookBuyer.Address,
                City = bookBuyer.City,
                Country = bookBuyer.Country,
                //Books = bookList
            }; 
            var newBookSellerDTO = new BookSellerDTO
            {
                FullName = bookSeller.FullName,
                Phone = bookSeller.Phone,
                Telephone = bookSeller.Telephone,
                Email = bookSeller.Email,
                Address = bookSeller.Address,
                City = bookSeller.City,
                Country = bookSeller.Country,
                //Books = bookList.ToList()
            };

            var newBookDTO = new BookDTO
            {
                BookName = book.BookName,
                WriterName = book.WriterName,
                CountPages = book.CountPages,
                Price = book.Price,
                Description = book.Description,
                DateWrite = book.DateWrite,
                Status = book.Status,
                BookBuyer = newBookBuyerDTO,
                BookSeller = newBookSellerDTO
            };

            return Ok(newBookDTO);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BookPostModel book)
        {
            var bookBuyer = _bookBuyerService.GetById(book.BookBuyerId); // הנחה שהשיטה מחזירה BookBuyer
            var bookSeller = _bookSellerService.GetById(book.BookSellerId); // הנחה שהשיטה מחזירה BookSeller
            var newBook = new Book
            {
                BookName = book.BookName,
                WriterName = book.WriterName,
                CountPages = book.CountPages,
                Price = book.Price,
                Description = book.Description,
                DateWrite = book.DateWrite,
                Status = book.Status,
                BookBuyer = bookBuyer,
                BookSeller = bookSeller
            };
            var bookNew = _bookService.AddAsync(newBook);
            var newBookBuyerDTO = new BookBuyerDTO
            {
                FullName = bookBuyer.FullName,
                Phone = bookBuyer.Phone,
                Telephone = bookBuyer.Telephone,
                Email = bookBuyer.Email,
                Address = bookBuyer.Address,
                City = bookBuyer.City,
                Country = bookBuyer.Country,
                //Books = bookList
            };
            var newBookSellerDTO = new BookSellerDTO
            {
                FullName = bookSeller.FullName,
                Phone = bookSeller.Phone,
                Telephone = bookSeller.Telephone,
                Email = bookSeller.Email,
                Address = bookSeller.Address,
                City = bookSeller.City,
                Country = bookSeller.Country,
                //Books = bookList.ToList()
            };

            var newBookDTO = new BookDTO
            {
                BookName = book.BookName,
                WriterName = book.WriterName,
                CountPages = book.CountPages,
                Price = book.Price,
                Description = book.Description,
                DateWrite = book.DateWrite,
                Status = book.Status,
                BookBuyer = newBookBuyerDTO,
                BookSeller = newBookSellerDTO
            };

            return Ok(newBookDTO);
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
