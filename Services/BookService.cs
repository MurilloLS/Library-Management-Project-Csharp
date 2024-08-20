using System.Security.Cryptography.X509Certificates;
using LibraryManagement.Models;
using LibraryManagement.Repositories;

namespace LibraryManagement.Services
{
  public class BookService
  {
    private readonly Dictionary<string, Book> bookByTitleDictionary;
    private readonly Dictionary<Guid, Book> bookByIdDictionary;

    public BookService()
    {
      bookByIdDictionary =  DataRepository.GetBooks();
      bookByTitleDictionary = bookByIdDictionary.Values.ToDictionary(x => x.Title, x => x);
    }

    public void AddBook(Book book)
    {
      if (!bookByTitleDictionary.ContainsKey(book.Title))
      {
        bookByIdDictionary.Add(book.Id, book);
        bookByTitleDictionary.Add(book.Title, book);
        DataRepository.SaveBooks(bookByIdDictionary);
        Console.WriteLine("Book added!");
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
        Console.WriteLine("Book not found! ");
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

    public bool UpdateBook(Book updatedBook, string currentTitle)
    {
      if (bookByIdDictionary.ContainsKey(updatedBook.Id))
      {
        bookByIdDictionary[updatedBook.Id] = updatedBook;
        bookByTitleDictionary.Remove(currentTitle);
        bookByTitleDictionary.Add(updatedBook.Title, updatedBook);
        Console.WriteLine("Book updated!");
        return true;
      }
      Console.WriteLine("Book not found!");
      return false;
    }

    public bool DeleteBook(Guid bookId)
    {
      if (bookByIdDictionary.TryGetValue(bookId, out Book book))
      {
        bookByTitleDictionary.Remove(book.Title);
        bookByIdDictionary.Remove(book.Id);
        Console.WriteLine("Book deleted successfully!");
        return true;
      }
      System.Console.WriteLine("Book not found!");
      return false;
    }

    public void GetBooks()
    {
      Console.WriteLine("Books: \n");
      Console.WriteLine("Id".PadRight(40) + " | " + "Title".PadRight(20) + " | " + "Author".PadRight(20)); 
      Console.WriteLine();
      foreach (var book in bookByIdDictionary)
      {
        Console.WriteLine(book.Value.Id.ToString().PadRight(40) + " | " + book.Value.Title.PadRight(20) + " | " + book.Value.Author.Name.PadRight(20));
      }
    }
  }
}