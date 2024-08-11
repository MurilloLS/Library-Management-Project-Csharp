using LibraryManagement.Models;
using LibraryManagement.Services;

namespace LibraryManagement
{
  static class Program
  {
    static void Main(string[] args)
    {
      var libraryService = new LibraryService();

      var author1 = new Author("J.K. Rowling");
      var author2 = new Author("George R.R. Martin");

      libraryService.AddAuthor(author1);
      libraryService.AddAuthor(author2);

      var book1 = new Book("Harry Potter", author1);
      var book2 = new Book("A Game of Thrones", author2);

      libraryService.AddBook(book1);
      libraryService.AddBook(book2);

      Console.WriteLine("Authors in the library:");
      foreach (var author in libraryService.GetAuthors())
      {
        Console.WriteLine($"- {author.Name}");
      }

      Console.WriteLine("\nBooks in the library:");
      foreach (var book in libraryService.GetBooks())
      {
        Console.WriteLine($"- {book.Title} by {book.Author.Name}");
      }
    }
  }
}
