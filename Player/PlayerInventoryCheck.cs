class PlayerInventoryCheck : ICommand
{
    private Player _player;
    public PlayerInventoryCheck(Player player)
    {
        _player = player;
    }
    public void Execute()
    {
        _player.InventoryDisplay(_player);
    }
}