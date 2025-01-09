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
    public class BookSellerRepository : Repository<BookSeller>, IBookSellerRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<BookSeller> _dbSet;

        public BookSellerRepository(DataContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<BookSeller>();
        }
        public BookSeller Add(BookSeller entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(BookSeller entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<BookSeller> GetAll()
        {
            return _dbSet.ToList();
        }

        public BookSeller? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public BookSeller Update(BookSeller entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
