using System.Collections.Generic;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PizzaOrderer
{
    class Program
    {
        class Pizza
        {
            private string m_size;
            private double m_price;

            private List<string> m_toppings = new List<string>();

            public Pizza(string size)
            { 
                m_size = size;  
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns>Returns the size of pizza (key) and price of size (value)</returns>
            public string? GetSize()
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
            public void AddTopping(string topping)
            {
                m_toppings.Add(topping);
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
            public List<string> GetToppings()
            {
                return m_toppings;
            }

            public void PrintPizzaDetails()
            {
                Console.WriteLine($"Pizza Size: {m_size}");
                Console.Write("Current Toppings: ");
                foreach (string topping in m_toppings) Console.Write($"{topping}, ");
            }
        }

        class Menu
        {
            private string m_name = "";
            private bool m_liveEditting = false;
            private Dictionary<string,double> m_items = new Dictionary<string, double>();

            private List<string> m_options = new List<string>();

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

            public void AddOptions(string[] options)
            {
                m_options.AddRange(options);
            }

            /// <summary>
            /// Prints the items of the menu with the menu name as the title.
            /// </summary>
            /// <remarks> Exit option is automatically appended to the end of the menu.</remarks>
            public void PrintMenu()
            {
                Console.Clear();
                Console.WriteLine(m_name);
                int iterations = 1;
                foreach (KeyValuePair<string, double> option in m_items)
                {
                    Console.WriteLine($"{iterations}) {option.Key}\t\t{option.Value.ToString("C", System.Globalization.CultureInfo.CurrentCulture)}");
                    iterations++;
                }

                if (m_liveEditting) Console.WriteLine("c) Confirm");
                Console.WriteLine("x) Exit");

                if (m_liveEditting) return;
            }

            /// <summary>
            /// Validates user's input and returns one of the given options.
            /// </summary>
            /// <returns>Returns the option name selected by user NOT NUMBER.</returns>
            /// <remarks>Option "x" is use to exit menu.</remarks>
            public string GetOption()
            {
                int numberOfOptions = m_items.ToArray().Length;

                while (true)
                {
                    Console.Write("\n>> ");
                    string? userOption = Console.ReadLine();
                    if (string.IsNullOrEmpty(userOption)) continue;
                    if (userOption.ToLower().Equals("x")) return userOption;
                    else if (m_liveEditting && userOption.ToLower().Equals("c")) return userOption;
                    
                    bool success = int.TryParse(userOption, out int userOptionNumber);
                    if (!success) continue;

                    if (userOptionNumber <= numberOfOptions) return m_items.ToArray()[userOptionNumber-1].Key;
                }
            }

            public void ToggleLiveEditting()
            {
                if (m_liveEditting) m_liveEditting = false;
                else m_liveEditting = true;
            }
            static public void PromptUser(string message)
            {
                Console.WriteLine(message);
                Thread.Sleep(1500);
            }
        }

        
        static void Main()
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

            string[] mainMenuOptions = ["Add Pizza", "Remove Pizza", "View Order", "Purchase"];

            // Menu Declarations
            Menu mainMenu = new Menu("Menu");
            mainMenu.AddOptions(mainMenuOptions);

            Menu pizzaSizeMenu = new Menu("Pizza Size");
            pizzaSizeMenu.AddItems(pizzaSizes);

            Menu toppingsMenu = new Menu("Toppings");
            toppingsMenu.AddItems(toppings);

            List<Pizza> pizzas = new List<Pizza>();

            while (true)
            {

                pizzaSizeMenu.PrintMenu();
                string selectedPizzaSize = pizzaSizeMenu.GetOption();
                if (selectedPizzaSize.Equals("x")) break;

                Pizza currentPizza = new Pizza(selectedPizzaSize);

                toppingsMenu.ToggleLiveEditting();
                while (true)
                {
                    toppingsMenu.PrintMenu();
                    Console.Write("\n");
                    currentPizza.PrintPizzaDetails();

                    string selectedTopping = toppingsMenu.GetOption();
                    if (selectedTopping.Equals("x")) break;
                    else if (selectedTopping.Equals("c")) 
                    {
                        pizzas.Add(currentPizza);
                        break;
                    }
                    currentPizza.AddTopping(selectedTopping);
                }
            }
        }
    }
}