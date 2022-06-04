using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory = new Inventory();

        private List<Path> _paths = new List<Path>();

        public Location(string[] ids, string name, string desc) :
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

        public Path FindPath(Direction dir)
        {
            Path searchPath = null;

            foreach(Path p in Paths)
            {
                if (dir.Way == p.Direction.Way)
                    searchPath = p;
            }

            return searchPath;
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public List<Path> Paths
        {
            get
            {
                return _paths;
            }
        }

        public string Description
        {
            get
            {
                string description = "This is the " + Name + "\n" + FullDescription + "\nYou can see in this room: \n";
                description += Inventory.ItemList;

                foreach (Path p in Paths)
                {
                    description += "\t" + p.FullDescription + "\n";
                }

                return description;
            }
        }
    }
}
