using Books.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Book? GetById(int id);
        Task<Book> AddAsync(Book book);
        Book? Update(int id,Book book);
        void Delete(Book book);
    }
}
