class PickUPCommand : ICommand
{
    private Player _player;
    private Room _room;

    public PickUPCommand(Player player, Room room)
    {
        int temp;
        bool guardian = true;
        IGameObject item;
        room.DisplayRoom(room);
        //Console.WriteLine("which item you wanna Pick up");
        //var input = Console.ReadLine();
        //guardian = int.TryParse(input, out temp);
        //if (guardian)
        //{
        item = room.GetItems(room);

        if (item != null)
            player.AddITem(player, item);


        //}
    }

    public void Execute()
    {
        

    }
}