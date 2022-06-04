using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class Path : GameObject
    {
        private Location _destination;
        private Direction _direction;
        private bool _isUnlocked;

        public Path(string[] ids, string name, string desc, Location destination, Direction direction) :
            this(ids, name, desc, destination, direction, true)
        { }

        public Path(string[] ids, string name, string desc, Location destination, Direction direction, bool unlocked):
            base(ids, name, desc)
        {
            _destination = destination;
            _direction = direction;
            _isUnlocked = unlocked;
        }

        public string MovePlayer(Player p)
        {
            p.Location = Destination;

            return p.Location.Description;
        }

        public Direction Direction
        {
            get
            {
                return _direction;
            }
        }

        public Location Destination
        {
            get
            {
                return _destination;
            }
        }

        public bool IsUnlocked
        {
            get
            {
                return _isUnlocked;
            }
        }
    }
}
