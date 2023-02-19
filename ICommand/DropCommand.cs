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
        item = player.RemoveItem(player);
        room.DropItems(room,item);


    }
    public void Execute()
    {
        
    }

}