using System;
using System.Collections.Generic;

namespace LunchMenu
{
    public class MenuInitialiser2 : Item2
    {
        public static List<Item2> order = new List<Item2>();
        public static List<Item2> VM = new List<Item2>();
        public static List<Item2> NVM = new List<Item2>();
        public static List<Item2> HM = new List<Item2>();
        public static Item2[] VegMenu { get; set; }
        public static Item2[] NonVegMenu { get; set; }
        public static Item2[] HealthyMenu { get; set; }
        public void AddMenu()
        {
            UpdateEntry("Veg", "Veg Meals", 60, 0);
            UpdateEntry("Veg", "Chapathi", 30, 0);
            UpdateEntry("Veg", "Mini Meals", 50, 0);
            UpdateEntry("Veg", "Paratha", 40, 0);
            UpdateEntry("Veg", "Veg Kurma", 20, 0);
            UpdateEntry("Veg", "Gobi Fry", 50, 0);
            UpdateEntry("Veg", "Kadai Vegetables", 40, 0);
            UpdateEntry("Veg", "Soup of The Day", 40, 0);
            UpdateEntry("Veg", "Fresh Juice", 40, 0);
            UpdateEntry("NonVeg", "Non Veg Meals", 90, 0);
            UpdateEntry("NonVeg", "Chapathi", 80, 0);
            UpdateEntry("NonVeg", "Mini Meals", 90, 0);
            UpdateEntry("NonVeg", "Paratha", 100, 0);
            UpdateEntry("NonVeg", "Chicken Masala", 90, 0);
            UpdateEntry("NonVeg", "Chicken 65", 90, 0);
            UpdateEntry("NonVeg", "Kadai Chicken", 100, 0);
            UpdateEntry("NonVeg", "Soup of the Day", 40, 0);
            UpdateEntry("NonVeg", "Fresh Juice", 40, 0);
            UpdateEntry("Healthy", "Protien Shake", 140, 0);
            UpdateEntry("Healthy", "Egg White Omlet", 40, 0);
            UpdateEntry("Healthy", "Oatmel", 40, 0);
            UpdateEntry("Healthy", "Sugar Free IceCream", 50, 0);
            UpdateEntry("Healthy", "Fresh Juice", 40, 0);
            UpdateEntry("Healthy", "Veg Sandwich", 60, 0);
            UpdateEntry("Healthy", "Chicken Sandwich", 80, 0);
            UpdateEntry("Healthy", "Veg Salad", 90, 0);
            UpdateEntry("Healthy", "Chicken Salad", 140, 0);
        }
        public void CreateMenu()
        {
            int count=0;
            while (menu1.Count > 0)
            {
                Item2 item = new Item2();
                item = menu1.Pop();
                if (item.menu == "Veg")
                {
                    VM.Add(item);
                }
                else if (item.menu == "NonVeg")
                {
                    NVM.Add(item);
                }
                else if(item.menu=="Healthy")
                {
                    HM.Add(item);
                }
                else
                {
                    count++;
                }
            }
            Console.WriteLine($"There are {count} bogus entries");
            VegMenu = VM.ToArray();
            VM.Clear();
            NonVegMenu = NVM.ToArray();
            NVM.Clear();
            HealthyMenu = HM.ToArray();
            HM.Clear();

           
        }

    }
}