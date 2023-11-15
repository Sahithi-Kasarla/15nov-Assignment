using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter a piece of text
            Console.WriteLine("Enter a piece of text:");
            string inputText = Console.ReadLine();

            // Display the word count
            int wordCount = CountWords(inputText);
            Console.WriteLine($"Number of words: {wordCount}");

            // Display the list of email addresses found
            var emailAddresses = ExtractEmailAddresses(inputText);
            Console.WriteLine("Email addresses:");
            foreach (var email in emailAddresses)
            {
                Console.WriteLine(email);
            }

            // Display the extracted mobile numbers
            var mobileNumbers = ExtractMobileNumbers(inputText);
            Console.WriteLine("Mobile numbers:");
            foreach (var number in mobileNumbers)
            {
                Console.WriteLine(number);
            }

            // Allow the user to input a custom regular expression
            Console.WriteLine("Enter a custom regular expression:");
            string customRegex = Console.ReadLine();

            // Perform custom regex search and display matches
            var customMatches = PerformCustomRegexSearch(inputText, customRegex);
            Console.WriteLine("Custom regex matches:");
            foreach (var match in customMatches)
            {
                Console.WriteLine(match);
            }

            Console.ReadLine(); // To keep the console window open
        }

        static int CountWords(string text)
        {
            // Define a regular expression pattern to match words
            string wordPattern = @"\b\w+\b";

            // Create a Regex object with the word pattern
            Regex wordRegex = new Regex(wordPattern);

            // Match the pattern against the input text
            MatchCollection matches = wordRegex.Matches(text);

            // Return the count of matched words
            return matches.Count;
        }

        static IEnumerable<string> ExtractEmailAddresses(string text)
        {
            // Define a regular expression pattern to match email addresses
            string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";

            // Create a Regex object with the email pattern
            Regex emailRegex = new Regex(emailPattern);

            // Match the pattern against the input text
            MatchCollection matches = emailRegex.Matches(text);

            // Return the matched email addresses
            return matches.Cast<Match>().Select(match => match.Value);
        }

        static IEnumerable<string> ExtractMobileNumbers(string text)
        {
            // Define a regular expression pattern to match mobile numbers
            string mobileNumberPattern = @"\b\d{10}\b";

            // Create a Regex object with the mobile number pattern
            Regex mobileNumberRegex = new Regex(mobileNumberPattern);

            // Match the pattern against the input text
            MatchCollection matches = mobileNumberRegex.Matches(text);

            // Return the matched mobile numbers
            return matches.Cast<Match>().Select(match => match.Value);
        }

        static IEnumerable<string> PerformCustomRegexSearch(string text, string customRegex)
        {
            // Create a Regex object with the custom regex pattern
            Regex customRegexObject = new Regex(customRegex);

            // Match the pattern against the input text
            MatchCollection matches = customRegexObject.Matches(text);

            // Return the matched strings
            return matches.Cast<Match>().Select(match => match.Value);
        }
    }
}
