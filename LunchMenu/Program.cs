using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LunchMenu
{
    class MainClass:Item
    {
        public static void Main(string[] args)
        {
            MenuInitialiser menu = new MenuInitialiser();
            menu.VegMenuStart();
            menu.NonVegMenuStart();
            menu.HealthyMenuStart();
           
            ShowMenu();

      
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Non Veg Menu");
            DisplayAll(MenuInitialiser.NonVegMenu);
            Console.WriteLine("Veg Menu");
            DisplayAll(MenuInitialiser.VegMenu);
            Console.WriteLine("Healthy Menu");
            DisplayAll(MenuInitialiser.HealthyMenu);
            DisplayMenu();
        }

        private static void DisplayMenu()
        {
            string option;
            Console.WriteLine("Choose N for Non Veg; V for Vegetarian; H for Healthy");
            option = Console.ReadLine();
            SelectOption(option);
        }


        private static void SelectOption(string option)
        {
            Console.WriteLine("Jump1");
            if (option == "n" || option == "N")
            {
                DisplayAll(MenuInitialiser.NonVegMenu);
                DishSelect(MenuInitialiser.NonVegMenu);

            }
            if (option == "v" || option == "V")
            {
                DisplayAll(MenuInitialiser.VegMenu);
                DishSelect(MenuInitialiser.NonVegMenu);
            }
            if (option == "h" || option == "H")
            {
                DisplayAll(MenuInitialiser.HealthyMenu);
                DishSelect(MenuInitialiser.NonVegMenu);
            }
            else
             {
                Console.WriteLine("Enter Valid Response");
                DisplayMenu();

            }
        }

        private static void DishSelect(Item[] items)
        {
            Console.WriteLine("Enter Blank at any time to end Order");
            string id;
            string count;
            Console.WriteLine("Enter The Id of the order");
            id = Console.ReadLine();
            Console.WriteLine("How Many Portions Do you require");
            count = Console.ReadLine();
            bool result = id.Any(x => !char.IsLetter(x));
            bool result1 = count.Any(x => !char.IsLetter(x));
            if (string.IsNullOrWhiteSpace(id))
            {
                EndOrder(MenuInitialiser.order);
            }

            else if (result == true && result1==true)
            {

                int id1 = int.Parse(id);
                if (id1 >= 0 && id1 < 9)
                {

                    int count1 = int.Parse(count);
                    if (count1 >= 0 && count1 < 9)
                    {
                        Item item = new Item();
                        for (int i = 0; i < items.Length; i++)
                        {
                            if (id1 == i)
                            {
                                item.UpdateEntry(item, items[i].Name, items[i].Price, count1);
                                MenuInitialiser.order.Add(item);
                            }
                        }


                    }
                    if (string.IsNullOrWhiteSpace(count))
                    {
                        EndOrder(MenuInitialiser.order);
                    }
                    else
                    {
                        DishSelect(items);
                    }


                }
                else
                {
                    DishSelect(items);
                }
            }
            else
            {
                Console.WriteLine("Enter Proper Id Please");
                DishSelect(items);
            }
        }



        private static void EndOrder(List<LunchMenu.Item> items)
        {
            Item[] order = items.ToArray();
            using (StreamWriter outputfile = File.CreateText("Bill.txt"))
            {
                var t = new TablePrinter("Name","Count" ,"Price");
                int total = 0;
                int temp;
                for (int i = 0; i < order.Length; i++)
                {

                    t.AddRow( order[i].Name,order[i].Count, order[i].Price);
                    temp = order[i].Count * order[i].Price;
                    Console.WriteLine(temp);
                    total = total+temp;
                    Console.WriteLine(total);
                }
                t.Print1(outputfile);
                outputfile.WriteLine($"Total Bill Amount is {total}");
                outputfile.Close();
                Environment.Exit(-1);
            }
        }

        private static void DisplayAll( Item[] items)
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
