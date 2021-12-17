using System;
using System.Linq;

namespace Lab4
{
    class Task3
    {
        // ������� � ������� �������
            static string ArraySolution(string InputText)
            {
                string[] words = InputText.Split(' ');

                string NewString = "";
                Array.Reverse(words);

                for (int i = 0; i < words.Length; i++)
                {
                    NewString += words[i] + " ";
                }
            return NewString.Trim();
            }

        // ������� � ������� ������� �����
        static string StringSolution(string InputText)
        {
            string NewString = string.Join(" ", InputText.Split(' ').Reverse());

            return NewString;
        }
        static void Main(string[] args)
        {

            Console.WriteLine(ArraySolution("��� ��� ��� ������"));
            Console.WriteLine(StringSolution("��� ��� ��� ������"));


        }
    }
}
