using Books.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Services
{
    public interface IBookSellerService
    {
        Task<IEnumerable<BookSeller>> GetAllAsync();
        BookSeller? GetById(int id);
        Task<BookSeller> AddAsync(BookSeller bookSale);
        BookSeller? Update(int id, BookSeller bookSale);
        void Delete(BookSeller bookSale);
    }
}
