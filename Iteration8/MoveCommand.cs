using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand():
            base(new string[] { "move", "go", "head", "leave" })
        { }

        public override string Execute(Player p, string[] text)
        {
            Direction dir;
            Path path;

            if (AreYou(text[0]))
            {
                if (text[0] == "leave")
                {
                    p.Location.Paths[0].MovePlayer(p);

                    return p.Location.Description;
                }
                else if(text.Length == 1)
                {
                    return "Which direction do you want to go?";
                }
                else
                {
                    dir = FetchDirection(text[1]);
                    if (dir == null)
                        return "Invalid directional input";
                    path = p.Location.FindPath(dir);
                    if (path == null)
                        return "There is no path in that direction";
                    path.MovePlayer(p);

                    return p.Location.Description;
                }
            }
            else
                return "Error in move input";
        }

        private Direction FetchDirection(string dir)
        {
            string[] directions = new string[] { "north", "south", "east", "west", "up", "down" };
            
            foreach (string d in directions)
            {
                if (dir == d)
                    return new Direction(dir);
            }
            return null;
        }
    }
}
