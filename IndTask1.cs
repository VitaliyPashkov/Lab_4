using System;
using System.Text;

namespace Lab4
{
    class IndTask1
    {

        //**********************���� ������*******************************
        static void CaesarCipher(string message, int key)
        {
            string alfabet = "�����Ũ��������������������������";
            alfabet += alfabet.ToLower();
            string cipher = "";
            string deCipher = "";
            for (int i = 0; i < message.Length; i++)
            {
                char symbol = message[i];
                int index = alfabet.IndexOf(symbol);
                if (index < 0)
                {
                    //���� ������ �� ������, �� ��������� ��� � ���������� ����
                    cipher += symbol.ToString();
                    deCipher += symbol.ToString();
                }
                else
                {
                    int codeIndex = (alfabet.Length + index + key) % alfabet.Length;
                    int deCodeIndex = codeIndex - key;

                    cipher += alfabet[codeIndex];
                    deCipher += alfabet[deCodeIndex];

                }
            }

            Console.WriteLine($"������������� ���������:\n{cipher}");
            Console.WriteLine($"�������������� ���������:\n{deCipher}");
        }       


        //**********************���� ����������*******************************
        static void TritemiusCipher(string message, int A, int B)
        {
            Console.WriteLine($"����� ����� ���������� � ������� ������� k = {A}p + {B}, ��� p - ������� ����� � ���������");
            string alfabet = "�����Ũ��������������������������";
            alfabet += alfabet.ToLower();
            string cipher = "";
            string deCipher = "";

            for (int i = 0; i < message.Length; i++)
            {
                char symbol = message[i];
                int m = alfabet.IndexOf(symbol);
                int p = message.IndexOf(symbol);
                int k = A * p + B;
                if (m < 0)
                {
                    //���� ������ �� ������, �� ��������� ��� � ���������� ����
                    cipher += symbol.ToString();
                    deCipher += symbol.ToString();

                }
                else
                {
                    int L = (m + k) % alfabet.Length;
                    cipher += alfabet[L];
                    while (L - k < 0)
                        L += alfabet.Length;
                    m = (L - k) % alfabet.Length;
                    deCipher += alfabet[m];
                }
            }

            Console.WriteLine($"������������� ���������:\n{cipher}");
            Console.WriteLine($"�������������� ���������:\n{deCipher}");

        }

        //**********************���� �������*******************************       
        static char[] RandKey(string str)
        {
            char[] key = new char[str.Length];
            Random rand = new Random();
            for (int i = 0; i < str.Length; i++)
            {
                key[i] = (char)(rand.Next() % 255);
            }
            return key;
        }
        static string VernamCipher(char[] str, char[] key)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                builder.Append((char)(str[i] ^ key[i]));
            }

            return builder.ToString();
        }

        static string VernamDeCipher(char[] str, char[] key)
        {
            return VernamCipher(VernamCipher(str, key).ToCharArray(), key);
        }



        static void Main(string[] args)
        {
            Random rnd = new Random();
            int A = rnd.Next(1, 10);
            int B = rnd.Next(1, 10);

            Console.WriteLine("������� ���������:");
            string msg = Console.ReadLine();

            Console.WriteLine("����� ���� ������������?:\n" +
                              "1 - ���� �������\n" +
                              "2 - ���� ������\n" +
                              "3 - ���� ����������");

            int choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    Console.WriteLine("������� ���� � ���� ������:");
                    string LenKey = Console.ReadLine();
                    char[] key = RandKey(LenKey);
                    Console.WriteLine($"������������� ���������:\n{VernamCipher(msg.ToCharArray(), key)}");
                    Console.WriteLine($"�������������� ���������:\n{VernamDeCipher(msg.ToCharArray(), key)}");

                    
                    break;
                case 2:
                    Console.WriteLine("������� �������� �����:");
                    CaesarCipher(msg, int.Parse(Console.ReadLine()));
                    break;
                case 3:
                    TritemiusCipher(msg, A, B);
                    break;
                default:
                    Console.WriteLine("�������� �� ����������.");
                    break;
            }


            // ���� 

        }
    }
}
