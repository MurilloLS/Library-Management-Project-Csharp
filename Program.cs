using LibraryManagement.Models;
using LibraryManagement.Services;

namespace LibraryManagement
{
  static class Program
  {
    static void Main(string[] args)
    {
      // Instanciar os serviços
      var authorService = new AuthorService();
      var bookService = new BookService();
      var loanService = new LoanService(bookService);

      // Criar e adicionar um autor
      var author = new Author("Murillo");
      authorService.AddAuthor(author);

      // Criar e adicionar um livro
      var book = new Book("Avatar", author);
      bookService.AddBook(book);

      // Buscar e exibir livro e autor
      var foundBook = bookService.SearchBookByTitle("Avatar");
      if (foundBook != null)
      {
        Console.WriteLine($"Found book: {foundBook.Title} by {foundBook.Author.Name}");
      }

      var foundAuthor = authorService.SearchAuthorByName("Murillo");
      if (foundAuthor != null)
      {
        Console.WriteLine($"Found author: {foundAuthor.Name}");
      }

      // Listar todos os autores e livros
      Console.WriteLine("\nAll authors:");
      authorService.GetAuthors();
      Console.WriteLine("\nAll books:");
      bookService.GetBooks();

      // Solicitar e processar um empréstimo
      loanService.RequestBookLoan(book.Id);
      loanService.ProcessLoanRequest();

      // Desfazer o último empréstimo
      loanService.UndoLastLoan();

      // Atualizar livro e autor
      var updatedBook = new Book("Avatar (Updated)", author);
      updatedBook.Id = book.Id; // Manter o mesmo ID para atualização
      bookService.UpdateBook(updatedBook);

      var updatedAuthor = new Author("Murillo (Updated)");
      updatedAuthor.Id = author.Id; // Manter o mesmo ID para atualização
      authorService.UpdateAuthor(updatedAuthor);

      // Exibir todos os livros e autores após atualização
      Console.WriteLine("\nAll authors after update:");
      authorService.GetAuthors();
      Console.WriteLine("\nAll books after update:");
      bookService.GetBooks();

      // Excluir livro e autor
      bookService.DeleteBook(book.Id);
      authorService.DeleteAuthor(author.Id);

      // Exibir todos os livros e autores após exclusão
      Console.WriteLine("\nAll authors after deletion:");
      authorService.GetAuthors();
      Console.WriteLine("\nAll books after deletion:");
      bookService.GetBooks();
    }
  }
}

