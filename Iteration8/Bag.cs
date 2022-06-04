using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory = new Inventory();

        public Bag(string[] ids, string name, string desc):
            base(ids, name, desc)
        { }

        public GameObject Locate(string id)
        {
            GameObject searchObject;

            if (AreYou(id))
            {
                return this;
            }
            else
            {
                searchObject = Inventory.Fetch(id);

                return searchObject;
            }
        }

        public override string FullDescription
        {
            get
            {
                string fulldesc =  "In the " + Name + " you can see:\n";

                fulldesc += Inventory.ItemList;

                return fulldesc;
            }
        }

        public Inventory Inventory
        { 
            get
            {
                return _inventory;
            }
        }
    }
}
