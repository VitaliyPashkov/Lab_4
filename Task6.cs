using System;
using System.Text.RegularExpressions;

namespace Lab4
{
    class Task6
    {
        static void Main(string[] args)
        {
            string Text = " 15.5 + 36 = 51 ";

            string[] operands = Regex.Split(Text.Trim(), @"\s+");
            
            int num1 = int.Parse(operands[0]);
            char operation = char.Parse(operands[1]);
            int num2 = int.Parse(operands[2]);
            int result = int.Parse(operands[4]);

            Console.WriteLine($"{num1} {operation} {num2} = {result}");

        }
    }
}
