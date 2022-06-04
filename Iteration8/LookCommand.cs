using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand():
            base(new string[] {"look", "lookcommand"})
        { }

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory container;
            string thingID;
            
            if (text.Length == 3 || text.Length == 5 || text.Length == 1)
            {
                
                if (text[0] == "look")
                {
                    if (text.Length == 1)
                        return p.Location.Description;

                    if (text[1] == "at")
                    {
                        if (text.Length == 5 && text[3] == "in")
                        {
                            container = FetchContainer(p, text[4]);
                            if (container == null)
                                return "I can't find the " + text[4];
                        }
                        else if (text.Length == 3)
                        {
                            container = p;
                        }
                        else
                            return "What do you want to look in?";
                    }
                    else
                        return "What do you want to look at?";
                }
                else
                    return "Error in look input";
            }
            else
                return "I don't know how to look like that";
            
            thingID = text[2];

            return LookAtIn(thingID, container);
        }

        private IHaveInventory FetchContainer(Player p, string containerID)
        {
            IHaveInventory container;
            GameObject obj = p.Locate(containerID);

            if (obj == null && p.Location.AreYou(containerID))
            {
                obj = p.Location;
            }

            container = obj as IHaveInventory;

            return container;
        }

        private string LookAtIn(string thingID, IHaveInventory container)
        {
            GameObject searchObject = container.Locate(thingID);

            if (searchObject == null)
                return "I can't find the " + thingID;
            else
                return searchObject.FullDescription;
        }
    }
}
