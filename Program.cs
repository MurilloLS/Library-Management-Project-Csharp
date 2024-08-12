using LibraryManagement.Models;
using LibraryManagement.Services;

namespace LibraryManagement
{
  static class Program
  {
    static void Main(string[] args)
    {
      LibraryService libraryService = new LibraryService();

      // Criar autores
      Author author1 = new Author("J.K. Rowling");
      Author author2 = new Author("George Orwell");

      // Adicionar autores
      libraryService.AddAuthor(author1);
      libraryService.AddAuthor(author2);

      // Criar livros
      Book book1 = new Book("Harry Potter and the Sorcerer's Stone", author1);
      Book book2 = new Book("1984", author2);

      // Adicionar livros
      libraryService.AddBook(book1);
      libraryService.AddBook(book2);

      // Listar todos os livros
      Console.WriteLine("All Books:");
      libraryService.GetBooks();

      // Listar todos os autores
      Console.WriteLine("\nAll Authors:");
      libraryService.GetAuthors();

      // Buscar livro pelo título
      Console.WriteLine("\nSearch for a book by title:");
      string searchTitle = Console.ReadLine();
      Book foundBook = libraryService.SearchBookByTitle(searchTitle);
      if (foundBook != null)
      {
        Console.WriteLine($"Found Book by Title: {foundBook.Title}, Author: {foundBook.Author.Name}");
      }

      // Buscar livro pelo ID
      Console.WriteLine("\nSearch for a book by ID:");
      string searchBookIdInput = Console.ReadLine();
      if (Guid.TryParse(searchBookIdInput, out Guid searchBookId))
      {
        Book foundBookById = libraryService.SearchBookById(searchBookId);
        if (foundBookById != null)
        {
          Console.WriteLine($"Found Book by ID: {foundBookById.Title}, Author: {foundBookById.Author.Name}");
        }
      }
      else
      {
        Console.WriteLine("Invalid ID format.");
      }

      // Buscar autor pelo nome
      Console.WriteLine("\nSearch for an author by name:");
      string searchAuthor = Console.ReadLine();
      Author foundAuthor = libraryService.SearchAuthorByName(searchAuthor);
      if (foundAuthor != null)
      {
        Console.WriteLine($"Found Author by Name: {foundAuthor.Name}");
      }

      // Buscar autor pelo ID
      Console.WriteLine("\nSearch for an author by ID:");
      string searchAuthorIdInput = Console.ReadLine();
      if (Guid.TryParse(searchAuthorIdInput, out Guid searchAuthorId))
      {
        Author foundAuthorById = libraryService.SearchAuthorById(searchAuthorId);
        if (foundAuthorById != null)
        {
          Console.WriteLine($"Found Author by ID: {foundAuthorById.Name}");
        }
      }
      else
      {
        Console.WriteLine("Invalid ID format.");
      }
    }
  }
}
