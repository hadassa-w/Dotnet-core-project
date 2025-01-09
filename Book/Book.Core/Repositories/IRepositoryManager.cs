using Books.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Repositories
{
    public interface IRepositoryManager
    {
        IRepository<Book> Books { get; }
        IRepository<BookBuyer> BooksBuyer { get; }
        IRepository<BookSeller> BooksSeller { get; }
        void Save();
    }
}
