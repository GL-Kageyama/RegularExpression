using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegularExpression
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var regExpClass = new RegExpClass();

            regExpClass.IsMatch1();

            regExpClass.StartString();

            regExpClass.CountMatch();

            regExpClass.PerfectMatch();

            regExpClass.SearchAndLinq();

            regExpClass.ReplaceString();

            regExpClass.ReplaceGroup();

            regExpClass.EnglishFive();
        }
    }

    class RegExpClass
    {
        // String judgment
        public void IsMatch1()
        {
            var text = "abc defg hijk lnm";
            // It includes spaces
            bool isMatch = Regex.IsMatch(text, @"bc d");
            if (isMatch)
                Console.WriteLine("A match to the criteria exists.");
            else
                Console.WriteLine("No match found.");
            Console.WriteLine();
        }

        // Judging the start string
        public void StartString()
        {
            var text = "using System.Text.RegularExpressions;";
            bool isMatch = Regex.IsMatch(text, @"^using");
            if (isMatch)
                Console.WriteLine("A string that starts with using");
            else
                Console.WriteLine("A string that does not start with using");
            Console.WriteLine();
        }

        // Counting match conditions
        public void CountMatch()
        {
            var strings = new[] {"Microsoft Windows", "Windows Server", "windows"};
            var regex = new Regex(@"^(W|w)indows$");
            var count = strings.Count(s => regex.IsMatch(s));
            Console.WriteLine("Consistent number : {0}", count);
            Console.WriteLine();
        }

        // Extraction of exact matches
        public void PerfectMatch()
        {
            var strings = new[] {"13000", "-50.6", "0.123", "+180.00", 
                                "10.2.5", "320-0851", "123", "$1200", "500円", };
            var regex = new Regex(@"^[-+]?(\d+)(\.\d+)?$");
            foreach (var s in strings)
            {
                var isMatch = regex.IsMatch(s);
                if (isMatch)
                    Console.WriteLine(s);
            }
            Console.WriteLine();
        }

        // Applying LINQ
        public void SearchAndLinq()
        {
            var text = "private List<string> results = new List<string>();";
            var matches = Regex.Matches(text, @"\b[a-z]+\b")
                                .Cast<Match>().OrderBy(x => x.Length);
            foreach (Match match in matches)
            {
                Console.WriteLine("Index={0}, Length={1}, Value={2}", 
                                  match.Index, match.Length, match.Value);
            }
            Console.WriteLine();
        }

        // Substitution process
        public void ReplaceString()
        {
            var text = "This is Soup.";
            var pattern = @"Potage|Soup|Juice";
            var replaced = Regex.Replace(text, pattern, "Potage");
            Console.WriteLine(replaced);
            Console.WriteLine();
        }

        // Targeted Replacement
        public void ReplaceGroup()
        {
            var text = "1024Megabyte, 8MegabyteString, Megabyte";
            var pattern = @"(\d+)Megabyte";
            var replaced = Regex.Replace(text, pattern, "$1byte");
            Console.WriteLine(replaced);
            Console.WriteLine();
        }

        // A string that begins with an alphabet followed by at least five numeric characters
        public void EnglishFive()
        {
            var text = "a12345 b123 Z12345 AX98765";
            var pattern = @"\b[a-zA-Z][0-9]{5}\b";
            var matches = Regex.Matches(text, pattern);
            foreach (Match m in matches)
                Console.WriteLine("'{0}'", m.Value);
            Console.WriteLine();
        }
    }
}