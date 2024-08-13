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
      Author author1 = new Author("Murillo");
      Author author2 = new Author("Matheus");

      // Adicionar autores
      libraryService.AddAuthor(author1);
      libraryService.AddAuthor(author2);

      // Criar livros
      Book book1 = new Book("Star Wars - Capitulo I", author1);
      Book book2 = new Book("Starfild", author2);

      // Adicionar livros
      libraryService.AddBook(book1);
      libraryService.AddBook(book2);

      // Listar todos os livros
      Console.WriteLine("All Books:");
      libraryService.GetBooks();

      // Buscar e pedir empréstimo de um livro pelo ID
      Console.WriteLine("\nRequest a book loan by ID:");
      string searchBookIdInput = Console.ReadLine();
      if (Guid.TryParse(searchBookIdInput, out Guid searchBookId))
      {
        libraryService.RequestBookLoan(searchBookId);
      }
      else
      {
        Console.WriteLine("Invalid ID format.");
      }

      // Processar a solicitação de empréstimo
      Console.WriteLine("\nProcessing loan request:");
      libraryService.ProcessLoanRequest();

      // Tentar processar novamente para mostrar a fila vazia
      Console.WriteLine("\nProcessing another loan request:");
      libraryService.ProcessLoanRequest();
    }
  }
}
