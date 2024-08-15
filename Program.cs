using LibraryManagement.Models;
using LibraryManagement.Services;

namespace LibraryManagement
{
  static class Program
  {
    static void Main(string[] args)
    {
      // Instanciando o serviço da biblioteca
      LibraryService libraryService = new LibraryService();

      // Criando e adicionando autores
      Author author1 = new ("Murillo");
      Author author2 = new ("Matheus");
      libraryService.AddAuthor(author1);
      libraryService.AddAuthor(author2);
      libraryService.GetAuthors();

      // Criando e adicionando livros
      Book book1 = new ("Harry Potter", author1 );
      Book book2 = new ("Avatar", author2 );
      libraryService.AddBook(book1);
      libraryService.AddBook(book2);
      libraryService.GetBooks();
      
      // Atualizando um livro
      book1.Title = "Annie Frank"; // Atualização do título
      bool bookUpdated = libraryService.UpdateBook(book1);
      Console.WriteLine(bookUpdated ? "\nBook updated successfully." : "\nBook update failed.");

      // Atualizando um autor
      author2.Name = "Robson"; // Atualização do nome
      bool authorUpdated = libraryService.UpdateAuthor(author2);
      Console.WriteLine(authorUpdated ? "Author updated successfully." : "Author update failed.");

      // Verificando as atualizações
      var updatedBook = libraryService.SearchBookById(book1.Id);
      if (updatedBook != null)
      {
        Console.WriteLine($"\nUpdated Book: {updatedBook.Title}");
      }
      else
      {
        Console.WriteLine("\nBook not found.");
      }

      var updatedAuthor = libraryService.SearchAuthorById(author2.Id);
      if (updatedAuthor != null)
      {
        Console.WriteLine($"Updated Author: {updatedAuthor.Name}\n");
      }
      else
      {
        Console.WriteLine("Author not found.\n");
      }

      libraryService.GetAuthors();
      libraryService.GetBooks();
      

      // Solicitando empréstimo de um livro
      libraryService.RequestBookLoan(book1.Id);

      // Processando a solicitação de empréstimo
      libraryService.ProcessLoanRequest();

      // Verificando se o livro foi removido da biblioteca
      Console.WriteLine(libraryService.SearchBookById(book1.Id) == null ? "Book was loaned." : "Book is still available.");

      // Desfazendo o último empréstimo
      libraryService.UndoLastLoan();

      // Verificando se o livro foi devolvido à biblioteca
      Console.WriteLine(libraryService.SearchBookById(book1.Id) != null ? "Book was returned." : "Book is not available.");

      // Teste para buscar autor por ID
      var foundAuthor = libraryService.SearchAuthorById(author1.Id);
      Console.WriteLine(foundAuthor != null ? $"Found Author: {foundAuthor.Name}" : "Author not found.");
    }
  }
}

