using System;
using System.Text.RegularExpressions;

namespace Lab4
{
    class IndTask3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¬ведите текст:");
            string text = Console.ReadLine();
            Regex regex = new Regex(@"[A-Z]\:\\\w*\\\w*");
            MatchCollection matches = regex.Matches(text);

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                    Console.WriteLine(match.Value);
            }
        }
    }
}
