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
        IEnumerable<BookSeller> GetAll();
        BookSeller? GetById(int id);
        BookSeller Add(BookSeller bookSale);
        BookSeller? Update(int id, BookSeller bookSale);
        void Delete(BookSeller bookSale);
    }
}
