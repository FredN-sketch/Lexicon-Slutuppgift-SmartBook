using Lexicon_Ovn5_SmartBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexicon_Slutuppgift_SmartBook
{
    public static class Validation
    {
        public static string AskForString(string prompt)
        {
            bool success = false;
            string answer;

            do
            {
                Console.Write($"{prompt}: ");
                answer = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(answer))
                {
                    Console.WriteLine($"Du måste ange en giltig {prompt}");
                }
                else
                {
                    success = true;
                }

            } while (!success);

            return answer;
        }
        public static string AskForString(string prompt, string[] options)
        {
            bool success = false;
            string answer;

            do
            {
                if (prompt != "")
                    Console.Write($"{prompt}: ");
                answer = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(answer) || !options.Contains(answer))
                {
                    Console.Write($"Ogiltigt val. Ange ");
                    for (int i = 0; i < options.Length; i++)
                    {
                        Console.Write($"{options[i]}");
                        if (i < options.Length-2)                          
                            Console.Write(", ");
                        else if (i == options.Length-2)
                            Console.Write(" eller ");
                    }
                    Console.Write(": ");
                }
                else
                {
                    success = true;
                }

            } while (!success);

            return answer;
        }

        public static uint AskForUInt(string prompt, uint[] uints)
        {
            do
            {
                string input = AskForString(prompt);

                if (uint.TryParse(input, out uint result) && uints.Contains(result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"Ange en giltig {prompt}");
                }

            } while (true);
        }
        public static uint AskForUInt(string prompt)
        {

            do
            {
                string input = AskForString(prompt);

                if (uint.TryParse(input, out uint result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"Ange en giltig {prompt}");
                }

            } while (true);
        }
    }
}
