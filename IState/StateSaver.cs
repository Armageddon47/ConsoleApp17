class StateSaver : IState
{
    //this class is meant to help change the states to one another
    // and get the current state

    private static IState _state;
    public StateSaver()
    {
        _state = new HallState();
    }
    public void ChangeState(IState currentState)
    {
        _state = currentState;
    }
    public IState GetState()
    {
        return _state;
    }
    public void Display()
    {

    }
    public string GetCommand()
    {
        return "";
    }

}