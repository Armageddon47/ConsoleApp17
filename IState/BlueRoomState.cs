class BlueRoomState : IState
{
    public void Display()
    {
        Console.WriteLine("you are in Blue Room!");

    }

    public string GetCommand()
    {
        Console.WriteLine("1 to examine, 2 to pick up, 3 to drop , 4 to check inventory, 0 to move");
        var input =Console.ReadLine();
        return input;
    }

}