using System;
using System.Collections.Generic;

namespace LunchMenu
{
    public class MenuInitialiser : Item
    {
        public static List<Item> order = new List<Item>();
        public static Dictionary<string, Item[]> Menu = new Dictionary<string, Item[]>();
        public static Item[] VegMenu { get; private set; }
        public static Item[] NonVegMenu { get; private set; }
        public static Item[] HealthyMenu { get; private set; }
        public void MenuStart()
        {
            Item item1 = new Item();
            Item item2 = new Item();
            Item item3 = new Item();
            Item item4 = new Item();
            Item item5 = new Item();
            Item item6 = new Item();
            Item item7 = new Item();
            Item item8 = new Item();
            Item item9 = new Item();
            UpdateEntry(item1, "Veg Meals", 60, 0);
            UpdateEntry(item2, "Chapathi", 30, 0);
            UpdateEntry(item3, "Mini Meals", 50, 0);
            UpdateEntry(item4, "Paratha", 40, 0);
            UpdateEntry(item5, "Veg Kurma", 20, 0);
            UpdateEntry(item6, "Gobi Fry", 50, 0);
            UpdateEntry(item7, "Kadai Vegetables", 40, 0);
            UpdateEntry(item8, "Soup of The Day", 40, 0);
            UpdateEntry(item9, "Fresh Juice", 40, 0);
            Item[] VegMenu1 = { item1, item2, item3, item4, item5, item6, item7, item8, item9 };
            Menu.Add("Veg", VegMenu1);
            Item item10 = new Item();
            Item item11 = new Item();
            Item item12 = new Item();
            Item item13 = new Item();
            Item item14 = new Item();
            Item item15 = new Item();
            Item item16 = new Item();
            Item item17 = new Item();
            Item item18 = new Item();
            UpdateEntry(item10, "Non Veg Meals", 90, 0);
            UpdateEntry(item11, "Chapathi", 80, 0);
            UpdateEntry(item12, "Mini Meals", 90, 0);
            UpdateEntry(item13, "Paratha", 100, 0);
            UpdateEntry(item14, "Chicken Masala", 90, 0);
            UpdateEntry(item15, "Chicken 65", 90, 0);
            UpdateEntry(item16, "Kadai Chicken", 100, 0);
            UpdateEntry(item17, "Soup of the Day", 40, 0);
            UpdateEntry(item18, "Fresh Juice", 40, 0);
            Item[] NonVegMenu1 = { item10, item11, item12, item13, item14, item15, item16, item17, item18 };
            Menu.Add("NonVeg", NonVegMenu1);
            Item item19 = new Item();
            Item item20 = new Item();
            Item item21 = new Item();
            Item item22 = new Item();
            Item item23 = new Item();
            Item item24 = new Item();
            Item item25 = new Item();
            Item item26 = new Item();
            Item item27 = new Item();
            UpdateEntry(item19, "Protien Shake", 140, 0);
            UpdateEntry(item20, "Egg White Omlet", 40, 0);
            UpdateEntry(item21, "Oatmel", 40, 0);
            UpdateEntry(item22, "Sugar Free IceCream", 50, 0);
            UpdateEntry(item23, "Fresh Juice", 40, 0);
            UpdateEntry(item24, "Veg Sandwich", 60, 0);
            UpdateEntry(item25, "Chicken Sandwich", 80, 0);
            UpdateEntry(item26, "Veg Salad", 90, 0);
            UpdateEntry(item27, "Chicken Salad", 140, 0);
            Item[] HealthyMenu1 = { item19, item20, item21, item22, item23, item24, item25, item26, item27 };
            Menu.Add("HealthyMenu", HealthyMenu1);
            VegMenu = Menu["Veg"];
            NonVegMenu = Menu["NonVeg"];
            HealthyMenu = Menu["HealthyMenu"];
        }
    }
}