
namespace Lexicon_Ovn5_SmartBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //   SeedData();
            bool showMenu = true;
            while (showMenu)
            {
                MenuHelper.PrintMenu();
                showMenu = MainMenu();
            }           
        }

        private static bool MainMenu()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    return true;
                default:
                    return false;
            }
        }
    }
}
