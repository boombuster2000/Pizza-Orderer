using System.Collections.Generic;
using System;
using System.Drawing;

namespace PizzaOrderer
{
    class Program
    {
        class Pizza
        {
            private KeyValuePair<string,double> m_size;
            private double m_price;

            private Dictionary<string,double> m_toppings = new Dictionary<string, double>();

            Pizza(KeyValuePair<string,double> size)
            { 
                m_size = size;
            }

            public KeyValuePair<string,double> GetSize()
            {
                return m_size;
            }

            public double GetPrice()
            {
                return m_price;
            }

            public void AddTopping(KeyValuePair<string,double> topping)
            {
                m_toppings.Add(topping.Key, topping.Value);
            }

            public void RemoveTopping(string toppingName)
            {
                m_toppings.Remove(toppingName);
            }

            public Dictionary<string,double> GetToppings()
            {
                return m_toppings;
            }

        }

        struct Menu
        {
            public string name = "";
            public Dictionary<string,double> items = new Dictionary<string, double>();

            public Menu(string menuName){
                name  = menuName;
            }

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

            
                Dictionary<string, double> pizzaSizes = new Dictionary<string, double>
                {
                    { "Medium", 2.00D },
                    { "Large", 3.00D }
                };

                Dictionary<string,double> toppings = new Dictionary<string, double>
                {
                    {"Cheese", 0.30},
                    {"Pepperoni", 0.30},
                    {"Meatball", 0.30},
                    {"Pepper", 0.30},
                };

                // Menu Declarations
                Menu pizzaSizeMenu = new Menu("Pizza Size");
                pizzaSizeMenu.items.Add("Medium", 2);
                pizzaSizeMenu.items.Add("Large", 3);

                PrintMenu(pizzaSizeMenu);

                string userOption = getOption(["1", "2", "x"]);
                if (userOption.Equals("x")) break;

            }
        }
    }
}