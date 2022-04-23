using System;

namespace AdvertisementMessage
{
    internal class Program
    {
        static void Main()
        {
            var phrases = new string[]
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };
            var events = new string[]
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };
            var authors = new string[]
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"
            };
            var cities = new string[]
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };

            var eventsRnd = new Random();
            var authorsRnd = new Random();
            var citiesRnd = new Random();
            var phrasesRnd = new Random();

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int phrasesIndex = phrasesRnd.Next(0, phrases.Length);

                int eventsIndex = eventsRnd.Next(0, events.Length);

                int authorsIndex = authorsRnd.Next(0, authors.Length);

                int citiesIndex = citiesRnd.Next(0, cities.Length);

                Console.WriteLine("{0} {1} {2} - {3}",
                    phrases[phrasesIndex], events[eventsIndex],
                    authors[authorsIndex], cities[citiesIndex]);
            }
        }
    }
}
