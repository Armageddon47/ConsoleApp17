class SaveCommand : ICommand
{
    private GameEngine _game = new GameEngine();

    public SaveCommand(GameEngine temp)
    {
        _game = temp;

    }
    public void Execute()
    {
        _game.saveEnginn();
        using (StreamWriter sw = new StreamWriter("GameSave.txt"))
        {
            sw.WriteLine(_game.saveEnginn());
        }
    }
}