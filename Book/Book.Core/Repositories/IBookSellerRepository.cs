using Books.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Repositories
{
    public interface IBookSellerRepository
    {
        IEnumerable<BookSeller> GetAll();
        BookSeller? GetById(int id);
        BookSeller Add(BookSeller bookSeller);
        BookSeller Update(BookSeller bookSeller);
        void Delete(BookSeller bookSeller);
    }
}
