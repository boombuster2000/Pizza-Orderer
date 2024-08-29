using System.Collections.Generic;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;

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

        class Menu
        {
            private string m_name = "";
            private Dictionary<string,double> m_items = new Dictionary<string, double>();

            public Menu(string name){
                m_name  = name;
            }

            public void AddItem(string item, double price)
            {
                m_items.Add(item, price);
            }

            public void AddItems(Dictionary<string, double> items)
            {
                foreach (KeyValuePair<string,double> item in items) m_items.Add(item.Key, item.Value); 
            }

            public void RemoveItem(string item)
            {
                m_items.Remove(item);
            }

            public Dictionary<string,double> GetItems()
            {
                return m_items;
            }

            /// <summary>
            /// Prints the items of the menu with the menu name as the title.
            /// </summary>
            /// <remarks> Exit option is automatically appended to the end of the menu.</remarks>
            /// <param name="menu">The menu to be printed.</param>
            public void Print()
            {
                Console.Clear();
                Console.WriteLine(m_name);
                int iterations = 1;
                foreach (KeyValuePair<string, double> option in m_items)
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
            public string GetOption()
            {
                int numberOfOptions = m_items.ToArray().Length;

                while (true)
                {
                    Console.Write(">> ");
                    string? userOption = Console.ReadLine();
                    if (string.IsNullOrEmpty(userOption)) continue;
                    if (userOption.ToLower() == "x") return userOption;
                    
                    bool success = int.TryParse(userOption, out int userOptionNumber);
                    if (!success) continue;

                    if (userOptionNumber <= numberOfOptions) return userOption;
                }
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
                pizzaSizeMenu.AddItems(pizzaSizes);


                pizzaSizeMenu.Print();
                string userOption = pizzaSizeMenu.GetOption();
                if (userOption.Equals("x")) break;

            }
        }
    }
}