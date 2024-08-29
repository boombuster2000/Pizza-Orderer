using System.Collections.Generic;
using System;

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

            /// <summary>
            /// 
            /// </summary>
            /// <returns>Returns the size of pizza (key) and price of size (value)</returns>
            public KeyValuePair<string,double> GetSize()
            {
                return m_size;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns>Returns total price of the pizza.</returns>
            public double GetPrice()
            {
                return m_price;
            }

            /// <summary>
            /// Adds a topping to the pizza.
            /// </summary>
            /// <param name="topping">Key is name of topping, value is price of topping.</param>
            public void AddTopping(KeyValuePair<string,double> topping)
            {
                m_toppings.Add(topping.Key, topping.Value);
            }

            /// <summary>
            /// Removes a topping from pizza.
            /// </summary>
            /// <param name="toppingName">The key to remove (name of topping).</param>
            public void RemoveTopping(string toppingName)
            {
                m_toppings.Remove(toppingName);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns>Returns dictionary of toppings. Key is name of topping, value is price of topping.</returns>
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

            /// <summary>
            /// Add items in bulk to menu using a dictionary. 
            /// </summary>
            /// <param name="items">Key is name of item, value is price of item.</param>
            public void AddItems(Dictionary<string, double> items)
            {
                foreach (KeyValuePair<string,double> item in items) m_items.Add(item.Key, item.Value); 
            }

            /// <summary>
            /// Removes individual items from menu.
            /// </summary>
            /// <param name="item">The key to be removed (name of item).</param>
            public void RemoveItem(string item)
            {
                m_items.Remove(item);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns>Dictionary of all items in menu. Key is name of item, value is price.</returns>
            public Dictionary<string,double> GetItems()
            {
                return m_items;
            }

            /// <summary>
            /// Prints the items of the menu with the menu name as the title.
            /// </summary>
            /// <remarks> Exit option is automatically appended to the end of the menu.</remarks>
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
            /// <returns>Returns option selected by user.</returns>
            /// <remarks>All options are numbers except "x" which is used to exit</remarks>
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