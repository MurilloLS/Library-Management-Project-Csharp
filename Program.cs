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

      // Criando alguns autores
      Author author1 = new ("Murillo");
      Author author2 = new ("Matheus");

      // Adicionando os autores
      libraryService.AddAuthor(author1);
      libraryService.AddAuthor(author2);

      // Criando alguns livros
      Book book1 = new ("Harry Potter", author1);
      Book book2 = new ("Star Wars", author2 );

      // Adicionando os livros
      libraryService.AddBook(book1);
      libraryService.AddBook(book2);

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

