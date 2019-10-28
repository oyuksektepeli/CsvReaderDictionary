using System;
using System.Collections.Generic;

namespace CsvReaderDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"C:\Repos\CsvReaderDictionary\CountryPopulations.csv";

            Reader reader = new Reader(filepath);

            Dictionary<string, Country> countries = reader.ReadAllCountries();

            // NB. Bear in mind when trying this code that string comparison is by default case-sensitive.
            // Hence, for example, to display Finland, you need to type in "FIN" in capitals. "fin" won't work.
            Console.WriteLine("Which country code do you want to look up? ");
            string userInput = Console.ReadLine();

            bool gotCountry = countries.TryGetValue(userInput, out Country country);
            if (!gotCountry)
                Console.WriteLine($"Sorry, there is no country with code, {userInput}");
            else
                Console.WriteLine($"{country.Name} has population {Formatter.FormatPopulation(country.Population)}");
        }
    }
}
