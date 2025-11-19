using Biblioteca.DTO.BooksResponse;
using Biblioteca.DTO.Books;
using Biblioteca.Repositories;

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
            var list = _repo.GetAll();
            var result = new List<BookResponseDTO>();

            foreach (var book in list)
            {
                result.Add(new BookResponseDTO
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Category = book.Category,
                    Quantity = book.Quantity
                });
            }
            return result;
        }

        public Book GetById(int id)
        {
            return _repo.GetById(id);
        }

        public void Create(BookDTO dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Quantity = dto.Quantity
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

