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
        //DRY kunde vara bättre om man tittar på de två nedanstående metoderna. 
        //Alt. om jag i LibraryApp ändrar så att jag alltid använder en av datatyperna, exv strängar istf uints,
        //så kunde jag ta bort en av de två metoderna nedan som tar en array med giltiga val som parameter. 

        //options innehåller de strängar som accepteras som svarsalternativ
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
                { //skriver ut giltiga strängar, exv "Ogiltigt val. Ange j eller n:"
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

        //uints innehåller de värden som accepteras som svarsalternativ
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
                {  //skriver ut giltiga uints, exv "Ogiltigt val. Ange 0, 1 eller 2:"
                    Console.Write($"Ogiltigt val. Ange ");
                    for (int i = 0; i < uints.Length; i++)
                    {
                        Console.Write($"{uints[i]}");
                        if (i < uints.Length - 2)
                            Console.Write(", ");
                        else if (i == uints.Length - 2)
                            Console.Write(" eller ");
                    }
                    Console.Write(": ");                   
                }

            } while (true);
        }  
        //private static void ListValidOptions(object[] options)
        //{
        //    {  //skriver ut giltiga uints, exv "Ogiltigt val. Ange 0, 1 eller 2:"
        //        Console.Write($"Ogiltigt val. Ange ");
        //        for (int i = 0; i < options.Length; i++)
        //        {
        //            Console.Write($"{options[i]}");
        //            if (i < options.Length - 2)
        //                Console.Write(", ");
        //            else if (i == options.Length - 2)
        //                Console.Write(" eller ");
        //        }
        //        Console.Write(": ");
        //    }
        //}
    }
}
