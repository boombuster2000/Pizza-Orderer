using System.Collections.Generic;
using System;

namespace PizzaOrderer
{
    class Program
    {

        struct Menu
        {
            public string name = "";
            public Dictionary<string,double> items = new Dictionary<string, double>();

            public Menu(string menuName){
                name  = menuName;
            }

        }

        struct Pizza
        {
            public string name;
            public double price;

            
        }
        /// <summary>
        /// Prints the items of the menu with the menu name as the title.
        /// </summary>
        /// <remarks> Exit option is automatically appended to the end of the menu.</remarks>
        /// <param name="menu">The menu to be printed.</param>
        static void PrintMenu(Menu menu)
        {
            Console.Clear();
            Console.WriteLine(menu.name);
            int iterations = 1;
            foreach (KeyValuePair<string, double> option in menu.items)
            {
                Console.WriteLine($"{iterations}) {option.Key}\t\t{option.Value.ToString("C", System.Globalization.CultureInfo.CurrentCulture)}");
                iterations++;
            }

            Console.WriteLine("x) Exit");
        }

        /// <summary>
        /// Validates user's input and returns one of the given options.
        /// </summary>
        /// <param name="validOptions">Array of strings that are valid options that can be selected.</param>
        /// <returns></returns>
        static string getOption(string[] validOptions)
        {
            while (true)
            {
                Console.Write(">> ");
                string? userOption = Console.ReadLine();
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
            while (true)
            {


                // Menu Declarations
                Menu pizzaSizes = new Menu("Pizza Size");
                pizzaSizes.items.Add("Medium", 2);
                pizzaSizes.items.Add("Large", 3);



                PrintMenu(pizzaSizes);

                string userOption = getOption(["1", "2", "x"]);
                if (userOption.Equals("x")) break;

            }
        }
    }
}