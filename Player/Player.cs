class Player
{
    private List<IGameObject> _inventory = new List<IGameObject>();
    private string _name;
    public Player(string name)
    {
        _name = name;
    }
    //reading player inventory
    public void InventoryDisplay(Player player)
    {
        if (player._inventory.Count > 0)
        {
            Console.WriteLine("Inventory Contains:");
            for (int i = 0; i < player._inventory.Count; i++)
            {
                Console.WriteLine((i+1)+ " : " + player._inventory[i]);
            }
        }
        else
        {
            Console.WriteLine("inventory is empty!");
        }
    }
    //remove item from inventory to add to a room
    public IGameObject RemoveItem(Player player)
    {
        List<IGameObject> temp_inv = new List<IGameObject>();

        int selection;
        if (player._inventory.Count > 0)
        {
            Console.WriteLine("Enter number you want to remove");
            var input = Console.ReadLine();
            bool guardian = int.TryParse(input, out selection);
            selection -= 1;
            if (guardian&& player._inventory[selection] != null )
            {
                temp_inv.Add(player._inventory[selection]);
                player._inventory.RemoveAt(selection);

            }
        }
        return temp_inv[0];//removing item and returning in order to add to desired location
    }

    public void AddITem(Player player, IGameObject gameObject)
    {
        player._inventory.Add(gameObject);
    }
}