using Books.Core.Models;
using Books.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _context;
        private readonly IRepository<Book> _books;
        private readonly IRepository<BookBuyer> _booksBuyer;
        private readonly IRepository<BookSeller> _booksSeller;

        public RepositoryManager(DataContext context, IRepository<Book> bookRepository, IRepository<BookBuyer> bookBuyerRepository, IRepository<BookSeller> bookSellerRepository)
        {
            _context = context;
            _books = bookRepository;
            _booksBuyer = bookBuyerRepository;
            _booksSeller = bookSellerRepository;
        }

        public IRepository<Book> Books => _books;
        public IRepository<BookBuyer> BooksBuyer => _booksBuyer;
        public IRepository<BookSeller> BooksSeller => _booksSeller;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
