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

        public async Task<BookSeller> AddAsync(BookSeller bookSale)
        {
            var newBookSeller = await _repositoryManager.BooksSeller.AddAsync(bookSale);
            _repositoryManager.Save();
            return newBookSeller;
        }

        public void Delete(BookSeller bookSale)
        {
            _repositoryManager.BooksSeller.Delete(bookSale);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<BookSeller>> GetAllAsync()
        {
            return await _repositoryManager.BooksSeller.GetAllAsync();
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
