using System;

namespace SwinAdventure
{
    class Program
    {
        static void Main(string[] args)
        {

            Player player;
            string playerName;
            string playerDesc;
            Item sword = new Item(new string[] {"sword", "longsword" }, "sword", "a shiny sword, used for pointing and stabbing");
            Item phone = new Item(new string[] { "phone", "smartphone", "cellphone", "iphone" }, "phone", "a brand new phone for making calls, too bad the programmer was too lazy to program it");
            Bag bag = new Bag(new string[] { "bag", "backpack" }, "backpack", "will carry anything you can't hold in your two semi-capable hands");
            Item gem = new Item(new string[] {"gem", "ruby" }, "gem", "a shiny stone that looks like it may be of some value");
            CommandProcessor commandProcessor = new CommandProcessor();
            Location hallway = new Location(new string[] { "room", "hallway" }, "hallway", "a long narrow hallway with paintings on the wall");
            Location bedroom = new Location(new string[] { "room", "bedroom" }, "bedroom", "a place of comfort, sleeping and mild panic");
            Location study = new Location(new string[] { "room", "study" }, "study", "a room used for studying and occasional procrastination");
            Item book = new Item(new string[] { "book", "textbook" }, "book", "a book containing valuable information about a subject you've given up on");
            Path bedroomToHall = new Path(new string[] { "door", "wooden door" }, "door", "a plain wooden door to the east", hallway, new Direction("east"));
            Path hallToBedroom = new Path(new string[] { "door", "wooden door" }, "door", "a plain wooden door to the west", bedroom, new Direction("west"));
            Path hallToStudy = new Path(new string[] { "door", "oak door", "brown door" }, "door", "a brown oak door to the north", study, new Direction("north"));
            Path studyToHall = new Path(new string[] { "door", "oak door", "brown door" }, "door", "a brown oak door to the south", hallway, new Direction("south"));
            hallway.Paths.Add(hallToStudy);
            hallway.Paths.Add(hallToBedroom);
            bedroom.Paths.Add(bedroomToHall);
            study.Paths.Add(studyToHall);
            
            string command;
            bool quit = false;

            Console.WriteLine("Welcome to Swin-Adventure");
            Console.Write("Please enter your name: ");
            playerName = Console.ReadLine();
            Console.Write("Please enter your description: ");
            playerDesc = Console.ReadLine();

            player = new Player(playerName, playerDesc);
            player.Inventory.Put(sword);
            player.Inventory.Put(phone);
            player.Inventory.Put(bag);
            bag.Inventory.Put(gem);
            player.Location = bedroom;
            study.Inventory.Put(book);

            do
            {
                Console.WriteLine("Please enter command:");
                command = Console.ReadLine().ToLower();

                if(command.Contains("quit"))
                {
                    quit = true;
                }
                else
                {
                    string[] words = command.Split(" ");
                    Console.WriteLine(commandProcessor.Execute(player, words));
                }
            } while (quit == false);

        }
    }
}
