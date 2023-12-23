using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace AppsPortfolio
{
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public long ISBN { get; set; }
        public int PublicationYear { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Availability { get; set; }
    }

    public class Library
    {
        private List<Book> books = new List<Book>();

        private void DisplayAvailableBooks()
        {
            Console.WriteLine("Available books in the library:");
            if (books.Count == 0)
            {
                Console.WriteLine("No books available.");
            }
            else
            {
                foreach (var book in books)
                {
                    if (book.Availability)
                    {
                        Console.WriteLine($"{book.Name} by {book.Author} published in {book.PublicationYear}, " +
                            $"(ISBN: {book.ISBN}), genre is {book.Genre}. Last updated: {book.LastUpdated}.");
                    }
                }
            }
        }

        public void AddBook()
        {
            Console.WriteLine("Enter the name of the new book you want to add to the library: ");
            Book newBook = new Book();
            Console.Write("Name: ");
            newBook.Name = Console.ReadLine();

            Console.Write("Author: ");
            newBook.Author = Console.ReadLine();

            Console.Write("Genre: ");
            newBook.Genre = Console.ReadLine();

            // Validate and set the publication year
            int publicationYear;
            while (true)
            {
                Console.Write("Publication Year (4 digits): ");
                string inputYear = Console.ReadLine();

                if (int.TryParse(inputYear, out publicationYear) && inputYear.Length == 4)
                {
                    newBook.PublicationYear = publicationYear;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid 4-digit year.");
                }
            }

            Console.Write("ISBN: ");
            long isbn;
            while (!long.TryParse(Console.ReadLine(), out isbn) || isbn <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid ISBN number.");
            }

            newBook.ISBN = isbn;
            newBook.Availability = true;

            books.Add(newBook);
            Console.WriteLine($"{newBook.Name} has been added to the library.");
            SaveToFile(newBook);
        }

        private void SaveToFile(Book book)
        {
            string filePath = "LibraryData.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"Name: {book.Name}");
                writer.WriteLine($"Author: {book.Author}");
                writer.WriteLine($"Genre: {book.Genre}");
                writer.WriteLine($"Publication Year: {book.PublicationYear}");
                writer.WriteLine($"ISBN: {book.ISBN}");
                writer.WriteLine($"Availability: {book.Availability}");
                writer.WriteLine($"Last Updated: {DateTime.Now}");
                writer.WriteLine(new string('-', 30)); // Separation line
            }
            SerializeBooks();
        }

        private void SerializeBooks()
        {
            string filePath = "LibraryData.json";
            string json = JsonConvert.SerializeObject( books, Formatting.Indented );
            File.WriteAllText( filePath, json );
        }
        private void DeserializeBooks()
        {
            string filePath = "LibraryData.json";

            if(File.Exists( filePath ) )
            {
                string json = File.ReadAllText( filePath );
                books = JsonConvert.DeserializeObject<List<Book>>( json ) ?? new List<Book>();
            }
        }
        
        public void BorrowBook()
        {
            DisplayAvailableBooks();

            if (books.Count == 0 || books.All(book => !book.Availability))
            {
                Console.WriteLine("No books available for borrowing.");
                return;
            }

            Console.Write("Enter the name of the book you want to borrow: ");
            string bookToBorrow = Console.ReadLine();

            Book selectedBook = books.Find(book => book.Name.Equals(bookToBorrow, StringComparison.OrdinalIgnoreCase));
            if (selectedBook != null && selectedBook.Availability)
            {
                Console.WriteLine($"You borrowed {selectedBook.Name} for 2 weeks. Please return it before the deadline.");
                selectedBook.Availability = false;

                // Display remaining books
                DisplayAvailableBooks();

                // Ask if the user wants to borrow another book
                Console.Write("Do you want to borrow another book? (y/n): ");
                if (Console.ReadLine().ToLower() == "y")
                {
                    BorrowBook();
                }
                else
                {
                    Console.WriteLine("Thank you for using the library.");
                }
            }
            else
            {
                Console.WriteLine($"Sorry. {bookToBorrow} is not available. Please check again later.");
            }

            Console.WriteLine("Press esc to exit...");
            Console.ReadKey();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Library library = new Library();
            do
            {
                library.AddBook();
                Console.Write("Do you want to add another book to the library? (y/n): ");
            } while (Console.ReadLine().ToLower() == "y");

            library.BorrowBook();

            // Wait for the Escape key to exit
            while (Console.ReadKey().Key != ConsoleKey.Escape) { }
        }
    }
}
