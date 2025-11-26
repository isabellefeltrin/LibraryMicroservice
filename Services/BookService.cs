using Biblioteca.DTO.Books;
using Biblioteca.DTO.BooksResponse;
using Biblioteca.Repositories;
using Library.Model;

namespace Biblioteca.Services
{
    public class BookService
    {
        private readonly BookRepository _repo;

        public BookService(BookRepository repo)
        {
            _repo = repo;
        }


        public List<BookResponseDTO> GetAll()
        {
            var books = _repo.GetAll();
            var result = new List<BookResponseDTO>();

            foreach (var b in books)
            {
                result.Add(new BookResponseDTO
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Category = b.Category,
                    Quantity = b.Quantity
                });
            }

            return result;
        }

        public BookResponseDTO? GetById(int id)
        {
            var book = _repo.GetById(id);
            if (book == null) return null;

            return new BookResponseDTO
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Category = book.Category,
                Quantity = book.Quantity
            };
        }

        public void Create(BookDTO dto)
        {
            var book = new BookModel
            {
                Title = dto.Title,
                Author = dto.Author,
                Quantity = dto.Quantity,
                Category = dto.Category,
            };

            _repo.Create(book);
        }


        public void UpdateQuantity(int id, int newQuantity)
        {
            var book = _repo.GetById(id);
            if (book == null) return;

            book.Quantity = newQuantity;
            _repo.Update(book);
        }
    }
}
