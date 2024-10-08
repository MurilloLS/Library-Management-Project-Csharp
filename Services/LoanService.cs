using LibraryManagement.Models;
using LibraryManagement.Repositories;
using System.Collections.Generic;


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
      loanQueue = DataRepository.LoadLoanQueue();
      loanHistory = DataRepository.LoadLoanHistory();
    }

    public void RequestBookLoan(Guid bookId)
    {
      var book = bookService.SearchBookById(bookId);
      if (book != null)
      {
        loanQueue.Enqueue(book);
        DataRepository.SaveLoanQueue(loanQueue);
        Console.WriteLine($"Book '{book.Title}' has been added to the loan queue.");
      }
      else
      {
        Console.WriteLine("Book not found!");
      }
    }

    public void ProcessLoanRequest()
    {
      if (loanQueue.Count > 0)
      {
        Book loanedBook = loanQueue.Dequeue();
        loanHistory.Push(loanedBook);
        bookService.DeleteBook(loanedBook.Id);
        DataRepository.SaveLoanQueue(loanQueue);
        DataRepository.SaveLoanHistory(loanHistory);
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
        DataRepository.SaveLoanHistory(loanHistory);
        Console.WriteLine($"Book '{book.Title}' has been returned.");
      }
      else
      {
        Console.WriteLine("No loan history to undo.");
      }
    }

    public void GetLoanRequested()
    {
      Console.WriteLine("Loan Requested: \n");
      Console.WriteLine("Id".PadRight(40) + " | " + "Title".PadRight(20) + " | " + "Author".PadRight(20));
      Console.WriteLine();
      foreach (var loan in loanQueue)
      {
        Console.WriteLine(loan.Id.ToString().PadRight(40) + " | " + loan.Title.PadRight(20) + " | " + loan.Author.Name.PadRight(20));
      }
    }

    public void GetLoanHistory()
    {
      Console.WriteLine("Loan History: \n");
      Console.WriteLine("Id".PadRight(40) + " | " + "Title".PadRight(20) + " | " + "Author".PadRight(20));
      Console.WriteLine();
      foreach (var loan in loanHistory)
      {
        Console.WriteLine(loan.Id.ToString().PadRight(40) + " | " + loan.Title.PadRight(20) + " | " + loan.Author.Name.PadRight(20));
      }
    }
  }
}