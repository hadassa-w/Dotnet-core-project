using Books.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Repositories
{
    public interface IBookBuyerRepository
    {
        IEnumerable<BookBuyer> GetAll();
        BookBuyer? GetById(int id);
        BookBuyer Add(BookBuyer bookBuyer);
        BookBuyer Update(BookBuyer bookBuyer);
        void Delete(BookBuyer bookBuyer);
    }
}
