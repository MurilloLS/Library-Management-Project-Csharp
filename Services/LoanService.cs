using LibraryManagement.Models;

namespace LibraryManagement.Services
{
  public class LoanService
  {
    private readonly Queue<Book> loanQueue;
    private readonly Stack<Book> loanHistory;
    private readonly BookService bookService;

    public LoanService(BookService bookService)
    {
      this.bookService = bookService;
      loanQueue = new Queue<Book>();
      loanHistory = new Stack<Book>();
    }

    public void RequestBookLoan(Guid bookId)
    {
      var book = bookService.SearchBookById(bookId);
      if (book != null)
      {
        loanQueue.Enqueue(book);
        Console.WriteLine($"Book '{book.Title}' has been added to the loan queue.");
      }
    }

    public void ProcessLoanRequest()
    {
      if (loanQueue.Count > 0)
      {
        Book loanedBook = loanQueue.Dequeue();
        loanHistory.Push(loanedBook);
        bookService.DeleteBook(loanedBook.Id);
        Console.WriteLine($"Book '{loanedBook.Title}' has been loaned out.");
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
        bookService.AddBook(book);
        Console.WriteLine($"Book '{book.Title}' has been returned.");
      }
      else
      {
        Console.WriteLine("No loan history to undo.");
      }
    }
  }
}