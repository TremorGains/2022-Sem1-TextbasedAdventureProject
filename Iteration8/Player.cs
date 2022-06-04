using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        private Location _location = new Location(new string[] {"room"}, "Room", "Starting Room");

        public Player(string name, string desc) :
            base( new string[] { "me", "inventory"} , name, desc)
        {}

        public GameObject Locate(string id)
        {
            GameObject searchObject;

            if(AreYou(id))
            {
                return this;
            }
            else
            {
                searchObject = Inventory.Fetch(id);

                if(searchObject == null)
                {
                    searchObject = Location.Locate(id);
                }

                return searchObject;
            }
        }

        public override string FullDescription
        { 
            get
            {
                string fulldesc = "You are carrying:\n";

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

        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }
    }
}
