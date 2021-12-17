using System;
using System.Text.RegularExpressions;
using System.Linq;
namespace Lab4
{
    class Task2
    {

        // –ешение с помощью массива
        static string ArraySolution(string InputText)
        {

            char[] TextArray = InputText.ToCharArray();
            char[] BannedSymbols = { '-', ' ', ',', 'Ц', '!', '.'};

            string NewString = "";
            int counter = 1;
            bool isNotBanned = false;

            for (int i = 0; i < TextArray.Length; i++)
            {
                foreach (char element in BannedSymbols)
                {
                    if (element == TextArray[i])
                        isNotBanned = true;
                }
                if (isNotBanned)
                {
                    if (i >= 1)
                    {
                        foreach (char element in BannedSymbols)
                        {
                            if (element == TextArray[i - 1])
                            {
                                isNotBanned = false;
                            }
                        }
                        if (isNotBanned)
                        {
                            NewString += $"({counter}){TextArray[i]}";
                            counter++;
                        }
                        else
                            NewString += TextArray[i];
                    }
                    else
                        NewString += TextArray[i];
                }
                else
                    NewString += TextArray[i];

                if (i == TextArray.Length - 1)
                {
                    if (i >= 1)
                    {
                        foreach (char element in BannedSymbols)
                        {
                            if (element == TextArray[i - 1])
                            {
                                isNotBanned = false;
                            }
                        }
                        if (!isNotBanned)
                        {
                            NewString += $"({counter})";
                            counter++;
                        }
                    }
                }

            }
            if (!BannedSymbols.Contains(NewString[NewString.Length - 1]))
                NewString += '.';
            return NewString;
        }

        // –ешение с помощью методов строк
        static string StringSolution(string InputText)
        {
            int counter = 1;
            char[] BannedSymbols = { '-', ' ', ',', 'Ц','!', '.'};
            string NewString = "";
            for (int i = 0; i < InputText.Length; i++)
            {

                if (BannedSymbols.Contains(InputText[i])
                    && !BannedSymbols.Contains(InputText[i - 1]) )
                {
                        NewString += $"({counter}){InputText[i]}";
                   /* else if (!BannedSymbols.Contains(InputText[i]))
                        NewString += $"{InputText[i]}({counter})";*/
                    counter++;
                }
                else
                    NewString += InputText[i];

            }
            if(!BannedSymbols.Contains(NewString[NewString.Length - 1]) && NewString[NewString.Length - 1] != ')')
                NewString += $"({counter}).";
            return NewString;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(ArraySolution("ƒонецк Ц прекрасный город!"));
            Console.WriteLine(StringSolution("ƒонецк Ц прекрасный город!"));

        } 
    }
}


