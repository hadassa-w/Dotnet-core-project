﻿using Books.Core.Models;
using Books.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public T Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            _context.BooksBuyer.Include(b => b.Books).ToList();
            _context.BooksSeller.Include(b => b.Books).ToList();
            _context.Books.Include(b => b.BookBuyer).Include(b => b.BookSeller).ToList();
            return _dbSet.ToList();
        }

        public T? GetById(int id)
        {
            _context.BooksBuyer.Include(b => b.Books).Where(book => book.Id == id).ToList();
            _context.BooksSeller.Include(b => b.Books).Where(book => book.Id == id).ToList();
            _context.Books.Include(b => b.BookBuyer).Include(b => b.BookSeller).ToList();
            return _dbSet.Find(id);
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
