using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();

        public Inventory()
        {}

        public bool HasItem(string id)
        { 
            foreach(Item i in _items)
            {
                if (i.AreYou(id))
                    return true;
            }

            return false;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            Item itm = Fetch(id);
            if (itm != null)
            {
                _items.Remove(itm);
                return itm;
            }
            else
                return null;
        }

        public Item Fetch(string id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                {
                    return i;
                }
            }

            return null;
        }

        public string ItemList
        {
            get
            {
                string itemlist = "";

                foreach(Item i in _items)
                {
                    itemlist += i.ShortDescription;
                }

                return itemlist;
            }
        }
    }
}
