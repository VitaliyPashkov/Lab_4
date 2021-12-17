using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab4
{
    class Task4
    {
        // Решение с помощью методов строк
        static void StringSolution(string[] StringArray)
        {
            foreach (string line in StringArray)
            {
                if (Regex.IsMatch(line, @"\.com(\,|\.|\s|$)", RegexOptions.IgnoreCase))
                {
                    Console.WriteLine(line);
                }
            }
        }


        // Решение с помощью массива
        static void ArraySolution(string[] StringArray)
        {
            char[] separators = { ' ', '.', ',' };
            foreach (string line in StringArray)
            {
                string LowerLine = line.ToLower();
                for (int i = 0; i < line.Length - 3; i++)
                {
                    if (LowerLine[i] == '.' &&
                        LowerLine[i + 1] == 'c' &&
                        LowerLine[i + 2] == 'o' &&
                        LowerLine[i + 3] == 'm')
                    {
                        if (i + 4 != line.Length)
                        {
                            if (separators.Contains(LowerLine[i + 4]))
                                Console.WriteLine(line);
                        }
                        else
                            Console.WriteLine(line);
                    }
                }
            }
        }

        //функция нахождения минимального кол-ва пробелов
        static int SpaceCounter(string[] StringArray)
        {
            List<int> SpaceList = new List<int>();
            foreach (string line in StringArray)
            {
                int SpaceCounter = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == ' ')
                        SpaceCounter++;
                }
                SpaceList.Add(SpaceCounter);
            }

            return SpaceList.IndexOf(SpaceList.Min()) + 1;
        }



        static void Main(string[] args)
        {
            string[] StringArray = new string[7];
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Введите {i + 1}-ю строку:");
                StringArray[i] = Console.ReadLine();
            }

            StringSolution(StringArray);
            ArraySolution(StringArray);
            Console.WriteLine($"№ строки, содержащей наименьшее число пробелов: {SpaceCounter(StringArray)}");
        }
    }
}

