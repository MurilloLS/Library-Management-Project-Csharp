using LibraryManagement.Models;

namespace LibraryManagement.Services
{
  public class AuthorService
  {
    private readonly Dictionary<string, Author> authorByNameDictionary;
    private readonly Dictionary<Guid, Author> authorByIdDictionary;

    public AuthorService()
    {
      authorByNameDictionary = new Dictionary<string, Author>();
      authorByIdDictionary = new Dictionary<Guid, Author>();
    }

    public void AddAuthor(Author author)
    {
      if (authorByNameDictionary.TryAdd(author.Name, author))
      {
        authorByIdDictionary.Add(author.Id, author);
        Console.WriteLine("Author added");
      }
      else
      {
        Console.WriteLine("Author already exists in the dictionary.");
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

    public bool UpdateAuthor(Author updatedAuthor, string currentName)
    {
      if (authorByIdDictionary.ContainsKey(updatedAuthor.Id))
      {
        authorByIdDictionary[updatedAuthor.Id] = updatedAuthor;
        authorByNameDictionary.Remove(currentName);
        authorByNameDictionary.Add(updatedAuthor.Name, updatedAuthor);
        System.Console.WriteLine("Author updated!");
        return true;
      }
      Console.WriteLine("Author not found!");
      return false;
    }

    public bool DeleteAuthor(Guid authorId)
    {
      if (authorByIdDictionary.TryGetValue(authorId, out Author author))
      {
        authorByNameDictionary.Remove(author.Name);
        authorByIdDictionary.Remove(author.Id);
        Console.WriteLine("Author deleted successfully!");
        return true;
      }
      Console.WriteLine("Author not found!");
      return false;
    }

    public void GetAuthors()
    {
      Console.WriteLine("Authors: \n");
      Console.WriteLine("Id".PadRight(40) + " | " + "Author".PadRight(20)); 
      Console.WriteLine();
      foreach (var author in authorByIdDictionary)
      {
        Console.WriteLine(author.Value.Id.ToString().PadRight(40) + " | " + author.Value.Name.PadRight(20));
      }
    }
  }
}