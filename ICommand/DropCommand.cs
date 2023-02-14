class DropCommand : ICommand
{
    private Player _player;
    private Room _room;
    public DropCommand(Player player, Room room)
    {
        int temp;
        bool guardian = true;
        IGameObject item;
        player.InventoryDisplay(player);
        //Console.WriteLine("which item you wanna drop");
        //var input = Console.ReadLine();
        //guardian = int.TryParse(input, out temp);
        //if (guardian)
        //{
        item = player.RemoveItem(player);
        room.DropItems(room,item);

        //}

    }
    public void Execute()
    {
        
    }

}