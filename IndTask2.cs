using System;
using System.Text.RegularExpressions;

namespace Lab4
{
    class IndTask2
    {

        // –ешение с помощью методов строк
        static void StringSolution()
        {
            Console.WriteLine("¬ведите текст:");
            string Text = Console.ReadLine();
            string pattern = @"(.)\1";
            string target = "";

            Regex regex = new Regex(pattern);
            string result = regex.Replace(Text, target);

            Console.WriteLine(result);
        }

        // –ешение с помощью массива
        static void ArraySolution()
        {
            Console.WriteLine("¬ведите текст:");
            string Text = Console.ReadLine();

            char[] TextArray = Text.ToCharArray();

            string NewString = "";

            for (int i = 0; i < TextArray.Length; i++)
            {
                if (i < TextArray.Length - 1)
                {
                    if (TextArray[i] == TextArray[i + 1])
                    {
                        i++;
                        continue;
                    }
                }
                NewString += TextArray[i];
            }

            Console.WriteLine(NewString);
        }
        static void Main(string[] args)
        {
            StringSolution();
            ArraySolution();

        }
    }
}
