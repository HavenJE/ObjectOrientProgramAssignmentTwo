
// Part A: Create a project with a Program class

// Create a Bookstore project with a Program class, write the following two methods (headers provided) as described:

// - A method, public static int InputValue(int min, int max), to input an integer number that is between (inclusive) the range of a
// lower bound and an upper bound. The method should accept the lower bound and the upper bound as two parameters and allow users to
// re-enter the number if the number is not in the range or a non-numeric value was entered.

// - A Method, public static bool IsValid(string id), to check if an input string satisfies the following conditions: the string’s
// length is 5, the string starts with 2 uppercase characters and ends with 3 digits. For example, “AS122” is a valid string,
// “As123” or “SQ1234” are not valid strings. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bookstore
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part C - calling the method in Part A.1 
            int numBooks = InputValue(1, 30);
            Console.WriteLine("\n\n*******************************************************************");
            Book[] books = new Book[numBooks];

            GetBookData(numBooks, books);

            Console.WriteLine("\n\n*******************************************************************");

            // Part C -display all books in the array
            Console.WriteLine("\nInformation of all Books:\n");
            DisplayAllBooks(books);

            Console.WriteLine("\n*******************************************************************");

            // Part C - display all books in the array
            Console.WriteLine("\nCategory codes are:\n");
            GetLists(numBooks, books);

            while (true)
            {
                Console.Write("Enter a category code or 'Z' to quit: ");
                string categoryCode = Console.ReadLine().ToUpper();

                if (categoryCode == "Z")
                    break;

                bool isValidCode = false;
                for (int i = 0; i < Book.categoryCodes.Length; i++)
                {
                    if (categoryCode == Book.categoryCodes[i])
                    {
                        isValidCode = true;
                        break;
                    }
                }

                if (!isValidCode)
                {
                    Console.WriteLine(categoryCode + " is not a valid category code.");
                    Console.WriteLine();
                    continue;
                }

                int numBooksInCategory = 0;

                Console.WriteLine("Books with category code " + categoryCode + " are:");

                for (int i = 0; i < numBooks; i++)
                {
                    if (books[i].BookId.StartsWith(categoryCode))
                    {
                        Console.WriteLine(books[i].ToString());
                        numBooksInCategory++;
                    }
                }

                Console.WriteLine("Number of books in the category " + Book.categoryNames[Array.IndexOf(Book.categoryCodes, categoryCode)] + ": " + numBooksInCategory);
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        // Part C: Extend the application
        // GetBookData(int num, Book[] books) method 
        private static void GetBookData(int num, Book[] books)
        {
            for (int i = 0; i < num; i++)
            {
                string bookTitle;
                do
                {
                    Console.Write("Enter book name >> ");
                    bookTitle = Console.ReadLine();

                    if (string.IsNullOrEmpty(bookTitle))
                    {
                        Console.WriteLine("Book title cannot be empty. Please enter a valid book title.");
                    }
                } while (string.IsNullOrEmpty(bookTitle));

                Console.WriteLine("\nThe codes of categories are:");
                for (int j = 0; j < Book.categoryCodes.Length; j++)
                {
                    Console.WriteLine($"   {Book.categoryCodes[j]} {Book.categoryNames[j]}");
                }
                Console.WriteLine();

                string bookId;
                bool isValidId = false;

                do
                {
                    Console.Write("   Enter book id which starts with a category code and ends with a 3-digit number >> ");
                    bookId = Console.ReadLine();

                    isValidId = IsValid(bookId);

                    if (!isValidId)
                    {
                        Console.WriteLine("   Invalid book id. Please enter a valid book id.");
                    }
                } while (!isValidId);



                Console.Write("   Enter book number of pages: ");
                int numOfPages;
                while (!int.TryParse(Console.ReadLine(), out numOfPages) || numOfPages <= 0)
                {
                    Console.WriteLine("   Invalid number of pages. Please enter a positive integer.");
                    Console.Write("   Enter book number of pages >> ");
                }

                double price;
                do
                {
                    Console.Write("   Enter book price >> ");
                    string input = Console.ReadLine();

                    if (double.TryParse(input, out price))
                    {
                        break;
                    }

                    Console.WriteLine("   Invalid price. Please enter a valid numeric value.");
                } while (true);

                books[i] = new Book(bookId, bookTitle, numOfPages, price);
            }
        }

        // Part C - DisplayAllBooks(Book[] books) method 
        public static void DisplayAllBooks(Book[] books)
        {
            int i = 1;
            foreach (Book book in books)
            {
                Console.Write("\nBook {0}\t\t", i++);
                Console.WriteLine(book.ToString());
            }
        }

        // Part C - GetLists(int num, Book[] books) method
        private static void GetLists(int num, Book[] books)
        {
            // Console.WriteLine("Book Categories:\n");

            for (int i = 0; i < Book.categoryCodes.Length; i++)
            {
                Console.WriteLine($"{Book.categoryCodes[i]} {Book.categoryNames[i]}");
            }
            Console.WriteLine();

            string categoryCode;
            bool isValidCode = false;

            do
            {
                Console.Write("\nEnter a category code to see information of books in that category >> ");
                categoryCode = Console.ReadLine();

                if (Array.IndexOf(Book.categoryCodes, categoryCode) == -1)
                {
                    Console.WriteLine("Invalid category code. Please enter a valid category code.");
                }
                else
                {
                    isValidCode = true;
                    int count = 0;

                    Console.WriteLine("\nBooks in Category '{0}':\n", categoryCode);

                    foreach (Book book in books)
                    {
                        if (book.BookId.StartsWith(categoryCode))
                        {
                            Console.WriteLine(book.ToString());
                            count++;
                        }
                    }

                    Console.WriteLine("Number of Books in Category '{0}': {1}", categoryCode, count);
                }
            } while (!isValidCode);
        }

        public static int InputValue(int min, int max)
        {
            int value;
            bool isValid = false;

            do
            {
                Console.Write("Enter a number between {0} and {1}: ", min, max);
                string input = Console.ReadLine();

                isValid = int.TryParse(input, out value);

                if (isValid)
                {
                    if (value < min || value > max)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between {0} and {1}.", min, max);
                        isValid = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value.");
                }
            } while (!isValid);

            return value;
        }

        // Part A - IsValid(string id) method 
        public static bool IsValid(string id)
        {
            if (id.Length != 5)
                return false;

            if (!char.IsUpper(id[0]) || !char.IsUpper(id[1]))
                return false;

            if (!char.IsDigit(id[2]) || !char.IsDigit(id[3]) || !char.IsDigit(id[4]))
                return false;

            return true;
        }
    }
}
