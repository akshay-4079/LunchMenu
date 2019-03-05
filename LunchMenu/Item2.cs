using System;
using System.Collections.Generic;
namespace LunchMenu
{
    public class Item2
    {


        public static Stack<Item2> menu1 = new Stack<Item2>();
    
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public string menu { get; set; }
        public void UpdateEntry( string menu,string Name, int price,int count)
        {
            Item2 item=new Item2();
            item.Name = Name;
            item.Price = price;
            item.Count = count;
            item.menu = menu;
            menu1.Push(item);
        }
    }
}
