namespace LibraryManagement.Models
{
  public class Book
  {
    public Book(string title, Author author)
    {
      Id = Guid.NewGuid();
      Title = title;
      Author = author;
    }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Author Author { get; set; }
  }
}