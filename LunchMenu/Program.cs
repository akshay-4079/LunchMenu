using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace LunchMenu
{
    class MainClass:Item
    {
        public static void Main(string[] args)
        {
            MenuInitialiser2 menu = new MenuInitialiser2();
            menu.ReadItems();
            menu.CreateMenu();
            ShowMenu();
        }

        private static void ShowMenu()
        {
            WriteLine("Non Veg Menu");
            DisplayAll(MenuInitialiser2.NonVegMenu);
            WriteLine("Veg Menu");
            DisplayAll(MenuInitialiser2.VegMenu);
            WriteLine("Healthy Menu");
            DisplayAll(MenuInitialiser2.HealthyMenu);
            DisplayMenu();
        }

        private static void DisplayMenu()
        {
            string option;
            WriteLine("Choose N for Non Veg; V for Vegetarian; H for Healthy");
            option = ReadLine();
            SelectOption(option);
        }


        private static void SelectOption(string option)
        {
      
            if (option == "n" || option == "N")
            {
                DisplayAll(MenuInitialiser2.NonVegMenu);
                DishSelect(MenuInitialiser2.NonVegMenu);

            }
            if (option == "v" || option == "V")
            {
                DisplayAll(MenuInitialiser2.VegMenu);
                DishSelect(MenuInitialiser2.NonVegMenu);
            }
            if (option == "h" || option == "H")
            {
                DisplayAll(MenuInitialiser2.HealthyMenu);
                DishSelect(MenuInitialiser2.NonVegMenu);
            }
            else
             {
                WriteLine("Entered Other Func");
                WriteLine("Enter Valid Response");
                DisplayMenu();

            }
        }

        private static void DishSelect(Item2[] items)
        {
            WriteLine("Enter Blank at any time to end Order");
            string id;
            string count;
            WriteLine("Enter The Id of the order");
            id = ReadLine();
            WriteLine("How Many Portions Do you require");
            count = ReadLine();
            bool result = id.Any(x => !char.IsLetter(x));
            bool result1 = count.Any(x => !char.IsLetter(x));
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(count))
            {
                EndOrder(MenuInitialiser2.order);

            }

            else if(result == true && result1==true)
            {

                int id1 = int.Parse(id);
                int count1 = int.Parse(count);

                int count2 = 0;
                for (int i = 0; i < items.Length; i++)
                        {
                            if (id1 == i)
                            {
                        count2 = 1;
                        Item2 item = new Item2();
                        item.Name = items[i].Name;
                        item.Count = count1;
                        item.menu = items[i].menu;
                        item.Price = items[i].Price;
                        MenuInitialiser2.order.Add(item);
                        DishSelect(items);
                    }
            
                }
                if (count2 == 0)
                {
                    Console.WriteLine("No Match");
                    DishSelect(items);
                }

            }
            else
            {
                WriteLine("Enter Proper Id Please");
                DishSelect(items);
            }
        }



        private static void EndOrder(List<Item2> items)
        {
            Item2[] order = items.ToArray();
            using (StreamWriter outputfile = File.CreateText("Bill.txt"))
            {
                var t = new TablePrinter("Name","Count" ,"Price");
                int total = 0;
                int temp;
                for (int i = 0; i < order.Length; i++)
                {

                    t.AddRow( order[i].Name,order[i].Count, order[i].Price);
                    temp = order[i].Count * order[i].Price;
                    WriteLine(temp);
                    total = total+temp;
                    WriteLine(total);
                }
                t.Print1(outputfile);
                outputfile.WriteLine($"Total Bill Amount is {total}");
                outputfile.Close();
                Environment.Exit(-1);
            }
        }

        private static void DisplayAll( Item2[] items)
        {
            var t = new TablePrinter("id", "Name", "Price");
          
           
            for (int i = 0; i < items.Length; i++)
            {

                t.AddRow(i, items[i].Name, items[i].Price);

            }
            t.Print();
       
        }
    }
}
