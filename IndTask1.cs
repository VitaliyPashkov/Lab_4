using System;
using System.Text;

namespace Lab4
{
    class IndTask1
    {

        //**********************Шифр Цезаря*******************************
        static void CaesarCipher(string message, int key)
        {
            string alfabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            alfabet += alfabet.ToLower();
            string cipher = "";
            string deCipher = "";
            for (int i = 0; i < message.Length; i++)
            {
                char symbol = message[i];
                int index = alfabet.IndexOf(symbol);
                if (index < 0)
                {
                    //если символ не найден, то добавляем его в неизменном виде
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

            Console.WriteLine($"Зашифрованное сообщение:\n{cipher}");
            Console.WriteLine($"Расшифрованное сообщение:\n{deCipher}");
        }       


        //**********************Шифр Тритемиуса*******************************
        static void TritemiusCipher(string message, int A, int B)
        {
            Console.WriteLine($"Текст будет зашифрован с помощью функции k = {A}p + {B}, где p - позиция буквы в сообщении");
            string alfabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
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
                    //если символ не найден, то добавляем его в неизменном виде
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

            Console.WriteLine($"Зашифрованное сообщение:\n{cipher}");
            Console.WriteLine($"Расшифрованное сообщение:\n{deCipher}");

        }

        //**********************Шифр Вернама*******************************       
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

            Console.WriteLine("Введите сообщение:");
            string msg = Console.ReadLine();

            Console.WriteLine("Какой шифр использовать?:\n" +
                              "1 - шифр Вернама\n" +
                              "2 - шифр Цезаря\n" +
                              "3 - шифр Тритемиуса");

            int choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    Console.WriteLine("Введите ключ в виде строки:");
                    string LenKey = Console.ReadLine();
                    char[] key = RandKey(LenKey);
                    Console.WriteLine($"Зашифрованное сообщение:\n{VernamCipher(msg.ToCharArray(), key)}");
                    Console.WriteLine($"Расшифрованное сообщение:\n{VernamDeCipher(msg.ToCharArray(), key)}");

                    
                    break;
                case 2:
                    Console.WriteLine("Введите значение ключа:");
                    CaesarCipher(msg, int.Parse(Console.ReadLine()));
                    break;
                case 3:
                    TritemiusCipher(msg, A, B);
                    break;
                default:
                    Console.WriteLine("Операция не распознана.");
                    break;
            }


            // Шифр 

        }
    }
}
