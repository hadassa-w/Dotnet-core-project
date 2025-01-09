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
    public class BookBuyerService : IBookBuyerService
    {
        private readonly IRepositoryManager _repositoryManager;

        public BookBuyerService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public BookBuyer Add(BookBuyer bookBuy)
        {
            _repositoryManager.BooksBuyer.Add(bookBuy);
            _repositoryManager.Save();
            return bookBuy;
        }

        public void Delete(BookBuyer bookBuy)
        {
            _repositoryManager.BooksBuyer.Delete(bookBuy);
            _repositoryManager.Save();
        }

        public IEnumerable<BookBuyer> GetAll()
        {
            return _repositoryManager.BooksBuyer.GetAll();
        }

        public BookBuyer? GetById(int id)
        {
            return _repositoryManager.BooksBuyer.GetById(id);
        }

        public BookBuyer? Update(int id, BookBuyer bookBuyer)
        {
            var dbUser = GetById(id);
            if (dbUser == null)
            {
                return null;
            }
            dbUser.FullName = bookBuyer.FullName;
            dbUser.Phone = bookBuyer.Phone;
            dbUser.Telephone = bookBuyer.Telephone;
            dbUser.Email = bookBuyer.Email;
            dbUser.Address = bookBuyer.Address;
            dbUser.City = bookBuyer.City;
            dbUser.Country = bookBuyer.Country;
            dbUser.Books = bookBuyer.Books;

            _repositoryManager.BooksBuyer.Update(dbUser);
            _repositoryManager.Save();
            return dbUser;
        }
    }
}
