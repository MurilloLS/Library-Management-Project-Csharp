using LibraryManagement.Models;

namespace LibraryManagement.Services
{
  public class LibraryService
  {
    private List<Author> authors;
    private List<Book> books;
    private Dictionary<string, Book> bookByTitleDictionary;
    private Dictionary<Guid, Book> bookByIdDictionary;
    private Dictionary<string, Author> authorByNameDictionary;
    private Dictionary<Guid, Author> authorByIdDictionary;

    public LibraryService()
    {
      authors = new List<Author>();
      books = new List<Book>();
      bookByTitleDictionary = new Dictionary<string, Book>();
      bookByIdDictionary = new Dictionary<Guid, Book>();
      authorByNameDictionary = new Dictionary<string, Author>();
      authorByIdDictionary = new Dictionary<Guid, Author>();

    }
    public void AddAuthor(Author author)
    {
      authors.Add(author);

      if (authorByNameDictionary.TryAdd(author.Name, author))
      {
        authorByIdDictionary.Add(author.Id, author);
      }
      else
      {
        Console.WriteLine("NotFound!");
      }

    }
    public void AddBook(Book book)
    {
      books.Add(book);

      if (bookByTitleDictionary.TryAdd(book.Title, book))
      {
        bookByIdDictionary.Add(book.Id, book);
      }
      else
      {
        Console.WriteLine("NotFound!");
      }

    }

    public Book SearchBookByTitle(string title)
    {
      if (bookByTitleDictionary.TryGetValue(title, out Book foundBook))
      {
        return foundBook;
      }
      else
      {
        Console.WriteLine("Not found!");
        return null;
      }
    }
    public Book SearchBookById(Guid id)
    {
      if (bookByIdDictionary.TryGetValue(id, out Book foundBook))
      {
        return foundBook;
      }
      else
      {
        Console.WriteLine("Not found!");
        return null;
      }
    }
    public Author SearchAuthorByName(string name)
    {
      if (authorByNameDictionary.TryGetValue(name, out Author foundAuthor))
      {
        return foundAuthor;
      }
      else
      {
        Console.WriteLine("Not found!");
        return null;
      }
    }
    public Author SearchAuthorById(Guid id)
    {
      if (authorByIdDictionary.TryGetValue(id, out Author foundAuthor))
      {
        return foundAuthor;
      }
      else
      {
        Console.WriteLine("Not found!");
        return null;
      }
    }

    public void GetAuthors()
    {
      foreach (var author in authorByNameDictionary.Values)
      {
        Console.WriteLine($"Id: {author.Id} - Author: {author.Name}");
      }
    }
    public void GetBooks()
    {
      foreach (var book in bookByTitleDictionary.Values)
      {
        Console.WriteLine($"Id: {book.Id} - Title: {book.Title}, Author: {book.Author.Name}");
      }
    }
  }
}