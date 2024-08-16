using LibraryManagement.Models;

namespace LibraryManagement.Services
{
  public class LibraryService
  {
    private readonly Dictionary<string, Book> bookByTitleDictionary;
    private readonly Dictionary<Guid, Book> bookByIdDictionary;
    private readonly Dictionary<string, Author> authorByNameDictionary;
    private readonly Dictionary<Guid, Author> authorByIdDictionary;
    private readonly Queue<Book> loanQueue;
    private readonly Stack<Book> loanHistory;

    public LibraryService()
    {
      bookByTitleDictionary = new Dictionary<string, Book>();
      bookByIdDictionary = new Dictionary<Guid, Book>();
      authorByNameDictionary = new Dictionary<string, Author>();
      authorByIdDictionary = new Dictionary<Guid, Author>();
      loanQueue = new Queue<Book>();
      loanHistory = new Stack<Book>();
    }

    //Métodos para add
    public void AddAuthor(Author author)
    {
      if (!authorByNameDictionary.ContainsKey(author.Name))
      {
        authorByNameDictionary.Add(author.Name, author);
        authorByIdDictionary.Add(author.Id, author);

      }
      else
      {
        Console.WriteLine("Author already exists in the dictionary.");
      }

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


    //Métodos de busca
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
    public Author SearchAuthorByName(string name)
    {
      if (authorByNameDictionary.TryGetValue(name, out Author foundAuthor))
      {
        return foundAuthor;
      }
      else
      {
        Console.WriteLine("Author not found!");
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
        Console.WriteLine("Author not found!");
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


    //Métodos para atualização
    public bool UpdateBook(Book updatedBook)
    {
      if (bookByIdDictionary.ContainsKey(updatedBook.Id))
      {
        bookByIdDictionary[updatedBook.Id] = updatedBook;
        return true;
      }
      return false;
    }
    public bool UpdateAuthor(Author updatedAuthor)
    {
      if (authorByIdDictionary.ContainsKey(updatedAuthor.Id))
      {
        authorByIdDictionary[updatedAuthor.Id] = updatedAuthor;
        return true;
      }
      return false;
    }


    //Métodos para delete
    public bool DeleteBook(Guid bookId)
    {
      if (bookByIdDictionary.TryGetValue(bookId, out Book book))
      {
        bookByIdDictionary.Remove(bookId);
        bookByTitleDictionary.Remove(book.Title);
        return true;
      }
      return false;
    }
    public bool DeleteAuthor(Guid authorId)
    {
      if (authorByIdDictionary.TryGetValue(authorId, out Author author))
      {
        var booksToRemove = bookByIdDictionary.Values.Where(book => book.Author.Id == authorId).ToList();

        foreach (var book in booksToRemove)
        {
          bookByTitleDictionary.Remove(book.Title);
          bookByIdDictionary.Remove(book.Id);
        }
        authorByIdDictionary.Remove(authorId);
        authorByNameDictionary.Remove(author.Name);
        return true;
      }
      return false;
    }





    //Métodos para emprestimo
    public void RequestBookLoan(Guid bookId)
    {
      if (bookByIdDictionary.TryGetValue(bookId, out Book book))
      {
        loanQueue.Enqueue(book);
        System.Console.WriteLine($"Book '{book.Title}' has been added to the loan queue.");
      }
      else
      {
        System.Console.WriteLine("Book not found.");
      }
    }
    public void ProcessLoanRequest()
    {
      if (loanQueue.Count > 0)
      {
        Book loanedBook = loanQueue.Dequeue();
        loanHistory.Push(loanedBook);
        bookByIdDictionary.Remove(loanedBook.Id);
        System.Console.WriteLine($"Book '{loanedBook.Title}' has been loaned out.");
      }
      else
      {
        Console.WriteLine("No loan request in the queue.");
      }
    }
    public void UndoLastLoan()
    {
      if (loanHistory.Count > 0)
      {
        var book = loanHistory.Pop();
        bookByIdDictionary.Add(book.Id, book);
      }
    }
  }
}