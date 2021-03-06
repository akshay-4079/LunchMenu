﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace LunchMenu
{
    public class MenuInitialiser2 : Item2
    {
        public static List<Item2> order = new List<Item2>();
        public static List<Item2> VM = new List<Item2>();
        public static List<Item2> NVM = new List<Item2>();
        public static List<Item2> HM = new List<Item2>();
        public static List<Item2> IM = new List<Item2>();
        public static Item2[] VegMenu { get; set; }
        public static Item2[] NonVegMenu { get; set; }
        public static Item2[] HealthyMenu { get; set; }
        public void ReadItems()
        {
            XmlReader xmlReader = XmlReader.Create(@"./Menu.xml");
            while (xmlReader.Read())
            {

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "dish"))
                {
                    int type;
                    string menuname=null;
                    string name=null;
                    int price=0;
                    int count=0;

                    if (xmlReader.HasAttributes)
                    {
                        type =int.Parse(xmlReader.GetAttribute("menutype").Trim());
                        menuname = GetName(type);
                        name = xmlReader.GetAttribute("Name").Trim();
                        price = int.Parse(xmlReader.GetAttribute("Price").Trim());
                        count = 0;
                        UpdateEntry(menuname, name, price, count);

                    }
                }
            }
        }

        //    public void AddMenu()
        //{
        //    UpdateEntry(GetName(0), "Veg Meals", 60, 0);
        //    UpdateEntry(GetName(0), "Chapathi", 30, 0);
        //    UpdateEntry(GetName(0), "Mini Meals", 50, 0);
        //    UpdateEntry(GetName(0), "Paratha", 40, 0);
        //    UpdateEntry(GetName(0), "Veg Kurma", 20, 0);
        //    UpdateEntry(GetName(0), "Gobi Fry", 50, 0);
        //    UpdateEntry(GetName(0), "Kadai Vegetables", 40, 0);
        //    UpdateEntry(GetName(0), "Soup of The Day", 40, 0);
        //    UpdateEntry(GetName(0), "Fresh Juice", 40, 0);
        //    UpdateEntry(GetName(1), "Non Veg Meals", 90, 0);
        //    UpdateEntry(GetName(1), "Chapathi", 80, 0);
        //    UpdateEntry(GetName(1), "Mini Meals", 90, 0);
        //    UpdateEntry(GetName(1), "Paratha", 100, 0);
        //    UpdateEntry(GetName(1), "Chicken Masala", 90, 0);
        //    UpdateEntry(GetName(1), "Chicken 65", 90, 0);
        //    UpdateEntry(GetName(1), "Kadai Chicken", 100, 0);
        //    UpdateEntry(GetName(1), "Soup of the Day", 40, 0);
        //    UpdateEntry(GetName(1), "Fresh Juice", 40, 0);
        //    UpdateEntry(GetName(2), "Protien Shake", 140, 0);
        //    UpdateEntry(GetName(2), "Egg White Omlet", 40, 0);
        //    UpdateEntry(GetName(2), "Oatmel", 40, 0);
        //    UpdateEntry(GetName(2), "Sugar Free IceCream", 50, 0);
        //    UpdateEntry(GetName(2), "Fresh Juice", 40, 0);
        //    UpdateEntry(GetName(2), "Veg Sandwich", 60, 0);
        //    UpdateEntry(GetName(2), "Chicken Sandwich", 80, 0);
        //    UpdateEntry(GetName(2), "Veg Salad", 90, 0);
        //    UpdateEntry(GetName(2), "Chicken Salad", 140, 0);
        //}

        private static string GetName(int number)
        {
            if (number <= 2 && number >= 0)
            {
                return Enum.GetName(typeof(Name1), number);
            }
            else return "Invalid Menu";
        }

        public void CreateMenu()
        {
            int count = 0;
            while (menu1.Count > 0)
            {
                Item2 item = new Item2();
                item = menu1.Pop();
                if (item.menu == "Veg" && item.Count == 0)
                {
                    VM.Add(item);
                }
                else if (item.menu == "NonVeg" && item.Count == 0)
                {
                    NVM.Add(item);
                }
                else if (item.menu == "Healthy" && item.Count == 0)
                {
                    HM.Add(item);
                }
                else
                {
                    count++;
                    IM.Add(item);
                }
            }
            CheckForBogus(count);
            ConvertToArray();
            ClearMemory();
        }

        private static void CheckForBogus(int count)
        {
            if (count > 0)
            {
                Console.WriteLine($"There are {count} bogus entries");
                foreach (Item2 element in IM)
                {
                    Console.WriteLine(element.Name);
                }

            }
        }

        private static void ConvertToArray()
        {
            VegMenu = VM.ToArray();

            NonVegMenu = NVM.ToArray();

            HealthyMenu = HM.ToArray();
        }

        private static void ClearMemory()
        {
            HM.Clear();
            IM.Clear();
            VM.Clear();
            NVM.Clear();
        }
    }
}