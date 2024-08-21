using LibraryManagement.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace LibraryManagement.Repositories
{
  public static class DataRepository
  {
    public static readonly string authorsFilePath = "Json/authors.json";
    private static readonly string booksFilePath = "Json/books.json";
    private static readonly string loanQueueFilePath = "Json/loanQueue.json";
    private static readonly string loanHistoryFilePath = "Json/loanHistory.json";
    
    public static void SaveAuthors(Dictionary<Guid, Author> authors)
    {
      var authorsJson = JsonSerializer.Serialize(authors.Values.ToList());
      File.WriteAllText(authorsFilePath, authorsJson);
    }
    public static Dictionary<Guid, Author> GetAuthors()
    {
      if (File.Exists(authorsFilePath))
      {
        var authorsJson = File.ReadAllText(authorsFilePath);
        var authors = JsonSerializer.Deserialize<List<Author>>(authorsJson);
        return authors.ToDictionary(x => x.Id, x => x);
      }
      return new Dictionary<Guid, Author>();
    }
    
    public static void SaveBooks(Dictionary<Guid, Book> books)
    {
      var booksJson = JsonSerializer.Serialize(books.Values.ToList());
      File.WriteAllText(booksFilePath, booksJson);
    }
    public static Dictionary<Guid, Book> GetBooks()
    {
      if (File.Exists(booksFilePath))
      {
        var booksJson = File.ReadAllText(booksFilePath);
        var books = JsonSerializer.Deserialize<List<Book>>(booksJson);
        return books.ToDictionary(x => x.Id, x => x);
      }
      return new Dictionary<Guid, Book>();
    }

    public static void SaveLoanQueue(Queue<Book> loanQueue)
    {
      var loanQueueJson = JsonSerializer.Serialize(loanQueue.ToList());
      File.WriteAllText(loanQueueFilePath, loanQueueJson);
    }
    public static Queue<Book> LoadLoanQueue()
    {
      if (File.Exists(loanQueueFilePath))
      {
        var loanQueueJson = File.ReadAllText(loanQueueFilePath);
        var loans = JsonSerializer.Deserialize<List<Book>>(loanQueueJson);
        return new Queue<Book>(loans);
      }
      return new Queue<Book>();
    }

    public static void SaveLoanHistory(Stack<Book> loanHistory)
    {
      var loanHistoryJson = JsonSerializer.Serialize(loanHistory.ToList());
      File.WriteAllText(loanHistoryFilePath, loanHistoryJson);
    }
    public static Stack<Book> LoadLoanHistory()
    {
      if (File.Exists(loanHistoryFilePath))
      {
        var loanHistoryJson = File.ReadAllText(loanHistoryFilePath);
        var loans = JsonSerializer.Deserialize<List<Book>>(loanHistoryJson);
        return new Stack<Book>(loans);
      }
      return new Stack<Book>();
    }
  }
}