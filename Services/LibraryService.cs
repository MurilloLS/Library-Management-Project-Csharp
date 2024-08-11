using LibraryManagement.Models;

namespace LibraryManagement.Services
{
  public class LibraryService
  {
    public LibraryService()
    {
      authors = new List<Author>();
      books = new List<Book>();
    }
    private List<Author> authors { get; set; }

    private List<Book> books { get; set; }

    public void AddAuthor(Author author)
    {
      authors.Add(author);
    }

    public void AddBook(Book book)
    {
      books.Add(book);
    }

    public List<Author> GetAuthors()
    {
      return authors;
    }

    public List<Book> GetBooks()
    {
      return books;
    }
  }
}