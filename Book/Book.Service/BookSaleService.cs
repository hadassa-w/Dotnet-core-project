using Books.Core.Models;
using Books.Core.Repositories;
using Books.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Service
{
    public class BookSaleService : IBookSellerService
    {
        private readonly IRepositoryManager _repositoryManager;

        public BookSaleService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public BookSeller Add(BookSeller bookSale)
        {
            _repositoryManager.BooksSeller.Add(bookSale);
            _repositoryManager.Save();
            return bookSale;
        }

        public void Delete(BookSeller bookSale)
        {
            _repositoryManager.BooksSeller.Delete(bookSale);
            _repositoryManager.Save();
        }

        public IEnumerable<BookSeller> GetAll()
        {
            return _repositoryManager.BooksSeller.GetAll();
        }

        public BookSeller? GetById(int id)
        {
            return _repositoryManager.BooksSeller.GetById(id);
        }

        public BookSeller? Update(int id, BookSeller bookSeller)
        {
            var dbUser = GetById(id);
            if (dbUser == null)
            {
                return null;
            }
            dbUser.FullName = bookSeller.FullName;
            dbUser.Phone = bookSeller.Phone;
            dbUser.Telephone = bookSeller.Telephone;
            dbUser.Email = bookSeller.Email;
            dbUser.Address = bookSeller.Address;
            dbUser.City = bookSeller.City;
            dbUser.Country = bookSeller.Country;
            dbUser.Books = bookSeller.Books;

            _repositoryManager.BooksSeller.Update(dbUser);
            _repositoryManager.Save();
            return dbUser;
        }
    }
}
