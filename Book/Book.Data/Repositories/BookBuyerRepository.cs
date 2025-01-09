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
    public class BookBuyerRepository :IBookBuyerRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<BookBuyer> _dbSet;

        public BookBuyerRepository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<BookBuyer>();
        }
        public BookBuyer Add(BookBuyer entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(BookBuyer entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<BookBuyer> GetAll()
        {
            return _context.BooksBuyer.ToList();
        }

        public BookBuyer? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public BookBuyer Update(BookBuyer entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
