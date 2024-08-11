namespace LibraryManagement.Models
{
  public class Author
  {
    public Author(string name)
    {
      Name = name;
      Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
  }
}