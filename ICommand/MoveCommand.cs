class MoveCommand : ICommand
{
    private StateSaver _currentState;

    private IState state;
    public MoveCommand(StateSaver currentState)
    {
        _currentState = currentState;
    }
    public void Execute()
    {
        var input = "";

        Console.WriteLine("where to move?");
        var state = _currentState.GetState();
        Console.WriteLine("You are in "+ state);
        if (state is HallState)
        {
            Console.WriteLine("1 for red room. 2 for blue room");
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _currentState.ChangeState(new RedroomState());
                    break;
                case "2":
                    _currentState.ChangeState(new BlueRoomState());
                    break;

            }
        }
        else if (state is RedroomState)
        {
            Console.WriteLine("1 for hall. 2 for blue room");
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _currentState.ChangeState(new HallState());
                    break;
                case "2":
                    _currentState.ChangeState(new BlueRoomState());
                    break;
            }

        }
        else if (state is BlueRoomState)
        {
            Console.WriteLine("1 hall. 2 for red room");
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _currentState.ChangeState(new HallState());
                    break;
                case "2":
                    _currentState.ChangeState(new RedroomState());
                    break;
            }
        }

    }

}