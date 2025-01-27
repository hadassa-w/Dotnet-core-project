using Books.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Services
{
    public interface IBookBuyerService
    {
        Task<IEnumerable<BookBuyer>> GetAllAsync();
        BookBuyer? GetById(int id);
        Task<BookBuyer> AddAsync(BookBuyer bookBuy);
        BookBuyer? Update(int id, BookBuyer bookBuy);
        void Delete(BookBuyer bookBuy);
    }
}
