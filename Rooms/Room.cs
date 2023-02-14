class Room
{
    //every room has inventory to hold the game objects

    internal List<IGameObject> _inventory = new List<IGameObject>();
    private string _name;
    public Room( string name)
    {
        
        _name = name;
    }

    //displaying room inventory
    public void DisplayRoom(Room room)
    {
        
        for (int i = 0; i < room._inventory.Count; i++)
        {
            Console.WriteLine("There is a : "+room._inventory[i]);
        }
        if (room._inventory.Count < 1)
        {
            Console.WriteLine("Nothing here");
        }
    }

    //removes item from room and returns object to add to player inv
    public IGameObject GetItems(Room room)
    {
        List<IGameObject> item = new List<IGameObject>();
        if (room._inventory.Count > 0)
        {
            for (int i = 0; i < room._inventory.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " +room._inventory[i]);
            }
        }
        else
        {
            Console.WriteLine("Empty");
        }
        if (room._inventory.Count > 0)
        {
            int temp = 0;
            bool guardian = true;
            Console.WriteLine("Enter the number you want to take.");
            var input = Console.ReadLine();
            guardian = int.TryParse(input, out temp);
            temp -= temp;
            if (guardian && room._inventory[temp]!= null)
            {
                item.Add(room._inventory[temp]);
                room._inventory.RemoveAt(temp);
            }
            else
            {
                Console.WriteLine("INVALID");
            }
        }

        if (item.Count>0)
            return item[0];
        return null;
    }
    public void DropItems(Room room ,IGameObject temp)
    {
        room._inventory.Add(temp);
    }

}