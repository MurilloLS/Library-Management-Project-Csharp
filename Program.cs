using LibraryManagement.Models;
using LibraryManagement.Services;

namespace LibraryManagement
{
  static class Program
  {
    static AuthorService authorService = new AuthorService();
    static BookService bookService = new BookService();
    static LoanService loanService = new LoanService(bookService);

    static void Main(string[] args)
    {
      bool exit = false;

      while (!exit)
      {
        Console.Clear();
        Console.WriteLine("\n=== Library Management System ===");
        Console.WriteLine("1. Manage Authors");
        Console.WriteLine("2. Manage Books");
        Console.WriteLine("3. Loan/Return Books");
        Console.WriteLine("4. Exit");
        Console.Write("Select an option:  ");
        string option = Console.ReadLine();

        switch (option)
        {
          case "1":
            ManageAuthorsMenu();
            Console.ReadKey();
            break;
          case "2":
            ManageBooksMenu();
            Console.ReadKey();
            break;
          case "3":
            ManageLoansMenu();
            Console.ReadKey();
            break;
          case "4":
            exit = true;
            break;
          default:
            Console.WriteLine("Invalid option. Please try again. ");
            Console.ReadKey();
            break;
        }
      }
    }

    static void ManageAuthorsMenu()
    {
      Console.Clear();
      Console.WriteLine("\n=== Manage Authors ===");
      Console.WriteLine("1. Add Author");
      Console.WriteLine("2. View All Authors");
      Console.WriteLine("3. Search Author by ID");
      Console.WriteLine("4. Search Author by Name");
      Console.WriteLine("5. Update Author");
      Console.WriteLine("6. Delete Author");
      Console.WriteLine("7. Back to Main Menu");
      Console.Write("Select an option: ");
      string option = Console.ReadLine();

      switch (option)
      {
        case "1":
          Console.Clear();
          Console.Write("Enter author name: ");
          string authorName = Console.ReadLine();
          authorService.AddAuthor(new Author(authorName));
          break;
        case "2":
          Console.Clear();
          authorService.GetAuthors();
          break;
        case "3":
          Console.Clear();
          Console.Write("Enter author ID: ");
          Guid authorId = Guid.Parse(Console.ReadLine());
          var authorById = authorService.SearchAuthorById(authorId);
          if (authorById != null) Console.WriteLine($"Found Author: {authorById.Name}");
          break;
        case "4":
          Console.Clear();
          Console.Write("Enter author name: ");
          string searchName = Console.ReadLine();
          var authorByName = authorService.SearchAuthorByName(searchName);
          if (authorByName != null) Console.WriteLine($"Found Author: {authorByName.Name}");
          break;
        case "5":
          Console.Clear();
          Console.Write("Enter author ID: ");
          Guid updateAuthorId = Guid.Parse(Console.ReadLine());
          var authorToUpdate = authorService.SearchAuthorById(updateAuthorId);
          string currentName = authorToUpdate.Name;
          if (authorToUpdate != null)
          {
            Console.Write("Enter new author name: ");
            string newName = Console.ReadLine();
            authorToUpdate.Name = newName;
            authorService.UpdateAuthor(authorToUpdate, currentName);
          }
          break;
        case "6":
          Console.Clear();
          Console.Write("Enter author ID: ");
          Guid deleteAuthorId = Guid.Parse(Console.ReadLine());
          if (authorService.DeleteAuthor(deleteAuthorId))
            Console.WriteLine("Author deleted successfully.");
          break;
        case "7":
          break;
        default:
          Console.Clear();
          Console.WriteLine("Invalid option. Please try again.");
          break;
      }
    }

    static void ManageBooksMenu()
    {
      Console.Clear();
      Console.WriteLine("\n=== Manage Books ===");
      Console.WriteLine("1. Add Book");
      Console.WriteLine("2. View All Books");
      Console.WriteLine("3. Search Book by ID");
      Console.WriteLine("4. Search Book by Title");
      Console.WriteLine("5. Update Book");
      Console.WriteLine("6. Delete Book");
      Console.WriteLine("7. Back to Main Menu");
      Console.Write("Select an option: ");
      string option = Console.ReadLine();

      switch (option)
      {
        case "1":
          Console.Clear();
          Console.Write("Enter book title: ");
          string bookTitle = Console.ReadLine();
          Console.Write("Enter author name: ");
          string bookAuthorName = Console.ReadLine();

          var bookAuthor = authorService.SearchAuthorByName(bookAuthorName);
          if (bookAuthor != null)
          {
            Book newBook = new Book(bookTitle, bookAuthor);
            bookService.AddBook(newBook);
          }
          else
          {
            Console.WriteLine("Author not found. Please add the author first.");
          }
          break;
        case "2":
          Console.Clear();
          bookService.GetBooks();
          break;
        case "3":
          Console.Clear(); 
          Console.Write("Enter book ID:  ");
          Guid bookId = Guid.Parse(Console.ReadLine());
          var bookById = bookService.SearchBookById(bookId);
          if (bookById != null) Console.WriteLine($"Found Book: {bookById.Title} by {bookById.Author.Name}");
          break;
        case "4":
          Console.Clear();
          Console.Write("Enter book title: ");
          string searchTitle = Console.ReadLine();
          var bookByTitle = bookService.SearchBookByTitle(searchTitle);
          if (bookByTitle != null) Console.WriteLine($"Found Book: {bookByTitle.Title} by {bookByTitle.Author.Name}");
          break;
        case "5":
          Console.Clear();
          Console.Write("Enter book ID: ");
          Guid updateBookId = Guid.Parse(Console.ReadLine());
          var bookToUpdate = bookService.SearchBookById(updateBookId);
          string currentTitle = bookToUpdate.Title;
          if (bookToUpdate != null)
          {
            Console.Write("Enter new book title: ");
            string newTitle = Console.ReadLine();
            bookToUpdate.Title = newTitle;
            bookService.UpdateBook(bookToUpdate, currentTitle);
          }
          break;
        case "6":
          Console.Clear();
          Console.Write("Enter book ID: ");
          Guid deleteBookId = Guid.Parse(Console.ReadLine());
          if (bookService.DeleteBook(deleteBookId))
            Console.WriteLine("Book deleted successfully.");
          break;
        case "7":
          break;
        default:
          Console.Clear();
          Console.WriteLine("Invalid option. Please try again.");
          break;
      }
    }

    static void ManageLoansMenu()
    {
      Console.Clear();
      Console.WriteLine("\n=== Loan/Return Books ===");
      Console.WriteLine("1. Request Book Loan");
      Console.WriteLine("2. Process Loan Request");
      Console.WriteLine("3. Undo Last Loan");
      Console.WriteLine("4. Back to Main Menu");
      Console.Write("Select an option: ");
      string option = Console.ReadLine();

      switch (option)
      {
        case "1":
          Console.Clear();
          Console.Write("Enter book ID: ");
          Guid bookId = Guid.Parse(Console.ReadLine());
          loanService.RequestBookLoan(bookId);
          break;
        case "2":
          Console.Clear();
          loanService.ProcessLoanRequest();
          break;
        case "3":
          Console.Clear();
          loanService.UndoLastLoan();
          break;
        case "4":
          break;
        default:
          Console.Clear();
          Console.WriteLine("Invalid option. Please try again.");
          break;
      }
    }
  }
}

