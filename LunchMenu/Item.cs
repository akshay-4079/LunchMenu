using System;
using System.Collections.Generic;

namespace LunchMenu
{
    public class Item

    {

        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public void UpdateEntry(Item item,string Name, int Price,int count)
        {
            item.Name = Name;
            item.Price = Price;
            item.Count = count;
        }
        public string MenuName { get; set; }
        public Item()
        {
            Name = null;
            Price = 0;
            Count = 0;
        }

     
    }
  
}
