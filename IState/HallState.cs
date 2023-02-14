class HallState : IState
{

    public void Display()
    {
        Console.WriteLine("you are in the hall!");
    }

    public string GetCommand()
    {
        Console.WriteLine("1 to examine, 2 to pick up, 3 to drop , 4 to check inventory ,0 to move");

        var input = Console.ReadLine();
        return input;
    }

}