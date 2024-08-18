using LibraryManagement.Models;

namespace LibraryManagement.Services
{
  public class BookService
  {
    private readonly Dictionary<string, Book> bookByTitleDictionary;
    private readonly Dictionary<Guid, Book> bookByIdDictionary;

    public BookService()
    {
      bookByTitleDictionary = new Dictionary<string, Book>();
      bookByIdDictionary = new Dictionary<Guid, Book>();
    }

    public void AddBook(Book book)
    {
      if (!bookByTitleDictionary.ContainsKey(book.Title))
      {
        bookByTitleDictionary.Add(book.Title, book);
        bookByIdDictionary.Add(book.Id, book);
      }
      else
      {
        Console.WriteLine("Book already exists in the dictionary.");
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
        Console.WriteLine("Book not found!");
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
        Console.WriteLine("Book not found!");
        return null;
      }
    }

    public bool UpdateBook(Book updatedBook)
    {
      if (bookByIdDictionary.ContainsKey(updatedBook.Id))
      {
        var oldBook = bookByIdDictionary[updatedBook.Id];
        bookByTitleDictionary.Remove(oldBook.Title);
        bookByTitleDictionary.Add(updatedBook.Title, updatedBook);
        bookByIdDictionary[updatedBook.Id] = updatedBook;
        return true;
      }
      return false;
    }

    public bool DeleteBook(Guid bookId)
    {
      if (bookByIdDictionary.TryGetValue(bookId, out Book book))
      {
        bookByTitleDictionary.Remove(book.Title);
        bookByIdDictionary.Remove(bookId);
        return true;
      }
      return false;
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