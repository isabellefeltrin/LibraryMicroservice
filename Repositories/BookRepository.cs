using Biblioteca.Services;

namespace Biblioteca.Repositories;

using Library.Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using Biblioteca.Data;

public class BookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<BookModel> GetAll()
        {
            return _context.Books.ToList();
        }

        public BookModel GetById(int id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }

        public void Create(BookModel book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(BookModel book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }


