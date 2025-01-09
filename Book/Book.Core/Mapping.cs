using Books.Core.DTOs;
using Books.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core
{
    public class Mapping
    {
        public BookDTO MappingBookDTO(Book book)
        {
            return new BookDTO { Id = book.Id, BookName = book.BookName, WriterName = book.WriterName, CountPages = book.CountPages, Price = book.Price, Description = book.Description, DateWrite = book.DateWrite, Status = book.Status};
        }
    }
}
