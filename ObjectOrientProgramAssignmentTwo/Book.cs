using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore
{
    // Part B: Create a Book class
    class Book
    {
        // Two public static arrays; categoryCodes & categoryNames
        public static string[] categoryCodes = { "CS", "IS", "SE", "SO", "MI" };
        public static string[] categoryNames = { "Computer Science", "Information System", "Security", "Society", "Miscellaneous" };

        // Data fields for book id (bookId) and book category name (categoryNameOfBook).
        private string bookId;
        private string categoryNameOfBook;

        public string BookId
        {
            get { return bookId; }
            set
            {
                bookId = value;
                string categoryCode = value.Substring(0, 2);
                int index = Array.IndexOf(categoryCodes, categoryCode);
                if (index != -1)
                    categoryNameOfBook = categoryNames[index];
                else
                    categoryNameOfBook = categoryNames[4];
            }
        }
        // Properties that hold a book’s title (BookTitle),(NumOfPages), (Price)
        public string BookTitle { get; set; }
        public int NumOfPages { get; set; }
        public double Price { get; set; }

        // Constructor1 with no parameter: public Book().
        public Book()
        {
        }

        // Constructor2 with parameter: public Book().
        public Book(string bookId, string bookTitle, int numOfPages, double price)
        {
            BookId = bookId;
            BookTitle = bookTitle;
            NumOfPages = numOfPages;
            Price = price;
        }

        // ToString() method
        public override string ToString()
        {
            return $"{BookId}\t{BookTitle}\t{NumOfPages}\t{Price:C}\n";
        }
    }
}

