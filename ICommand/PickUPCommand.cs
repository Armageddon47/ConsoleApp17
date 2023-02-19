class PickUPCommand : ICommand
{

    public PickUPCommand(Player player, Room room)
    {
        int temp;
        bool guardian = true;
        IGameObject item;
        room.DisplayRoom(room);

        item = room.GetItems(room);

        if (item != null)
            player.AddITem(player, item);

    }

    public void Execute()
    {
        

    }
}