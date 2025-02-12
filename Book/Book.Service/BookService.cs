﻿using Books.Core.Models;
using Books.Core.Repositories;
using Books.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Service
{
    public class BookService : IBookService
    {
        private readonly IRepositoryManager _repositoryManager;

        public BookService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Book> AddAsync(Book book)
        {
            var newBook = await _repositoryManager.Books.AddAsync(book);
            _repositoryManager.Save();
            return newBook;
        }

        public void Delete(Book book)
        {
            _repositoryManager.Books.Delete(book);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _repositoryManager.Books.GetAllAsync();
        }

        public Book? GetById(int id)
        {
            return _repositoryManager.Books.GetById(id);
        }

        public Book? Update(int id, Book book)
        {
            var dbUser = GetById(id);
            if (dbUser == null)
                return null;
            dbUser.BookName = book.BookName;
            dbUser.WriterName = book.WriterName;
            dbUser.CountPages = book.CountPages;
            dbUser.Price = book.Price;
            dbUser.Description = book.Description;
            dbUser.DateWrite = book.DateWrite;
            dbUser.Status = book.Status;
            dbUser.BookBuyer = book.BookBuyer;
            dbUser.BookSeller = book.BookSeller;

            _repositoryManager.Books.Update(dbUser);
            _repositoryManager.Save();
            return dbUser;
        }
    }
}
