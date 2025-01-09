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
        IEnumerable<BookBuyer> GetAll();
        BookBuyer? GetById(int id);
        BookBuyer Add(BookBuyer bookBuy);
        BookBuyer? Update(int id, BookBuyer bookBuy);
        void Delete(BookBuyer bookBuy);
    }
}
