using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BookLibraryModification
{
    internal class Program
    {
        static void Main()
        {
            int booksCount = int.Parse(Console.ReadLine());
            Library library = new Library();
            library.Name = "Top library";
            library.Books = new List<Book>();

            for (int i = 0; i < booksCount; i++)
            {
                var input = Console.ReadLine().Split().ToArray();
                string title = input[0];
                string author = input[1];
                string publisher = input[2];
                var currDate = input[3];
                DateTime releaseDate = DateTime.ParseExact(currDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                int isbnNumber = int.Parse(input[4]);
                double price = double.Parse(input[5], CultureInfo.InvariantCulture);

                Book book = new Book()
                {
                    Title = title,
                    Author = author,
                    Publisher = publisher,
                    ReleaseDate = releaseDate,
                    ISBNNumber = isbnNumber,
                    Price = price
                };

                library.Books.Add(book);
            }

            var dateAsString = Console.ReadLine().Trim();
            DateTime date = DateTime.ParseExact(dateAsString, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            List<Book> orderedBooks = library.Books.OrderBy(b => b.ReleaseDate)
                                                   .ThenBy(b => b.Title)
                                                   .ToList();
            foreach (var book in orderedBooks)
            {
                int result = DateTime.Compare(book.ReleaseDate, date);
                if (result > 0) Console.WriteLine($"{book.Title} -> {book.ReleaseDate:dd.MM.yyyy}");
            }
        }
    }
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ISBNNumber { get; set; }
        public double Price { get; set; }
    }
    class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
