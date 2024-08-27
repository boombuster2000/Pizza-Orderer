using System.Security.Cryptography.X509Certificates;

namespace PizzaOrderer
{
    class Program
    {

        static void PrintMenu()
        {
            System.Console.WriteLine("Menu");
            System.Console.WriteLine("1) Medium Pizza \t £2");
            System.Console.WriteLine("2) Large Pizza \t\t £3");
            System.Console.WriteLine("x) Exit");
        }

        static string getOption(string[] validOptions)
        {
            while (true)
            {
                System.Console.Write(">> ");
                string? userOption = System.Console.ReadLine();
                if (String.IsNullOrEmpty(userOption)) continue;
                userOption = userOption.ToLower();

                bool isValidOption = false;
                foreach (string option in validOptions) if (option.Equals(userOption)) isValidOption = true;
                if (!isValidOption) continue;
                return userOption;
            }
        }

        static void Main()
        {
            PrintMenu();
            string userOption = getOption(["1", "2", "x"]);
        }
    }
}