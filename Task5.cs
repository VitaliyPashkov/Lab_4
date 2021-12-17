using System;
using System.Text.RegularExpressions;
namespace Lab4
{
    class Task5
    {

        // Решение с помощью массива
        static string ArraySolution(string Text)
        {
            string CorrectWords = "";
            string[] words = Text.Split(' ');

            foreach (string word in words)
            {
                if (char.IsUpper(word[0]) &&
                    char.IsDigit(word[^1]) &&
                    char.IsDigit(word[^2]))
                {
                    CorrectWords += word + " ";
                }
            }
            return CorrectWords.Trim();
        }

        // Решение с помощью методов строк
        static void StringSolution(string text)
        {
            Regex regex = new Regex(@"([A-Z]{1})([a-z]*)([0-9]{2})");
            string CorrectWords = "";
            MatchCollection matches = regex.Matches(text);

                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                        CorrectWords += match.Value + " ";
                }
            
                Console.WriteLine(CorrectWords);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(ArraySolution("Petr93 Service02 something text00"));
            StringSolution("Petr93 Service02 something text00");

        }
    }
}
