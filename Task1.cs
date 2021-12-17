using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab4
{
    class Task1
    {
        // Решение с помощью массива
        static string ArraySolution(string InputText)
        {
            char[] TextArray = InputText.ToCharArray();
            string NewString = "";

            int RepeatCounter = 0;
            for (int i = 0; i < TextArray.Length; i++)
            {
                for (int j = 0; j < TextArray.Length; j++)
                {

                    if (TextArray[i] == TextArray[j] && i != j)
                    {
                        RepeatCounter++;
                    }
                }
                if (RepeatCounter == 0)
                {
                    NewString += TextArray[i];
                }
                RepeatCounter = 0;
            }
            NewString += '.';
            return NewString;
        }
        // Решение с помощью методов строк
        static string StringSolution(string InputText)
        {
            string NewString = "";

            for (int i = 0; i < InputText.Length; i++)
            {
                if (InputText.IndexOf(InputText[i]) == InputText.LastIndexOf(InputText[i]))
                    NewString += InputText[i];
            }

            NewString += '.';
            return NewString;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ArraySolution("Hello World"));
            Console.WriteLine(StringSolution("Hello World"));

        }
    }
}
