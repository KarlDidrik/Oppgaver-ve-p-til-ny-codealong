using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAi_sin_Biblotekoppgave
{
    internal class Library
    {
        private List<Book> books;
        private List<String> borrowers; 

        public Library()
        {
        books = new List<Book>();
        borrowers = new List<string>();
        }
        public void AddBook(Book book)
        {
        books.Add(book);
        }

        public void AddBorrower(string borrowerName)
        {
            borrowers.Add(borrowerName);
        }

        public void BorrowBook(string borrowerName, string bookTitle)
        {
            if (!borrowers.Contains(borrowerName))
            {
                Console.WriteLine($"Borrower {borrowerName} does not exist.");
                return;
            }

            Book bookToBorrow = books.Find(book => book.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));
            if (bookToBorrow == null)
            {
                Console.WriteLine($"Book {bookTitle} not found in the library.");
                return;
            }

            if (bookToBorrow.Availible)
            {
                bookToBorrow.Availible = false;
                Console.WriteLine($"{borrowerName} borrowed the book: {bookToBorrow}");
            }
            else
            {
                Console.WriteLine($"The book {bookToBorrow.Title} is not available");
            }
        }

        public void ReturnBook(string borrowerName, string bookTitle)
        {
            Book borrowedBook = FindBorrowedBook(borrowerName, bookTitle);

            if (borrowedBook == null)
            {
                borrowedBook.Availible = true;
                Console.WriteLine($"{borrowerName} has returned the book: {borrowedBook.Title}");
            }
            else
            {
                Console.WriteLine($"{borrowerName} did not borrow the book: {bookTitle}");
            }

            Book FindBorrowedBook(string borrowerName, string bookTitle)
            {
                if (!borrowers.Contains(borrowerName))
                {
                    Console.WriteLine($"Borrower {borrowerName} does not exist.");
                    return null;
                }

                Book borrowedBook = books.Find(book =>
                    book.Title.Equals(bookTitle, StringComparison.InvariantCultureIgnoreCase));
                if (borrowedBook == null)
                {
                    Console.WriteLine($"Book {bookTitle} not found in the library.");
                    return null;
                }

                if (!borrowedBook.Availible)
                {
                    return borrowedBook;
                }
                else
                {
                    Console.WriteLine($"{borrowerName} did not borrow the book : {bookTitle}");
                    return null;
                }
            }
        }

        public void DisplayAvailableBooks()
        {
            var availableBooks = books.Where(book => book.Availible).ToList();
            if (availableBooks.Count > 0)
            {
                Console.WriteLine("Available Books:");
                foreach (var book in availableBooks)
                {
                    Console.WriteLine(book);
                }
                
            }
            else
            {
                Console.WriteLine("No books are available in the library.");
            }
        }

        public void DisplayBorrowersAndBooks()
        {
            foreach (var borrower in borrowers)
            {
                var borrowedBooks = books.Where(book => !book.Availible && FindBorrower(book) == borrower).ToList();

                if (borrowedBooks.Count > 0)
                {
                    Console.WriteLine($"Borrower: {borrower}");
                    foreach (var book in borrowedBooks)
                    {
                        Console.WriteLine($"Borrower {borrower} has not borrowed any books.");
                    }
                    Console.WriteLine();
                }
            }

            
        }
        public string FindBorrower(Book book)
        {
            return borrowers.FirstOrDefault(borrowers => books.Any(b => !b.Availible && b.Title == book.Title));
        }
    }


}
