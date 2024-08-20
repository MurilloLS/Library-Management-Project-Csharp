using LibraryManagement.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace LibraryManagement.Repositories
{
  public static class DataRepository
  {
    public static readonly string authorsFilePath = "Json/authors.json";
    private static readonly string booksFilePath = "Json/books.json";

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
  }
}