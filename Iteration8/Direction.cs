using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Direction
    {
        private string _way;

        public Direction(string way)
        {
            _way = way;
        }

        public string Way
        {
            get
            {
                return _way;
            }
        }
    }
}
