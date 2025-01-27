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

        public async Task<BookBuyer> AddAsync(BookBuyer bookBuy)
        {
            var newBookBuyer = await _repositoryManager.BooksBuyer.AddAsync(bookBuy);
            _repositoryManager.Save();
            return newBookBuyer;
        }

        public void Delete(BookBuyer bookBuy)
        {
            _repositoryManager.BooksBuyer.Delete(bookBuy);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<BookBuyer>> GetAllAsync()
        {
            return await _repositoryManager.BooksBuyer.GetAllAsync();
        }

        public  BookBuyer? GetById(int id)
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
