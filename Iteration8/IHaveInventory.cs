using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    interface IHaveInventory
    {
        public GameObject Locate(string id);

        public string Name
        {
            get
            {
                return Name;
            }
        }
    }
}
