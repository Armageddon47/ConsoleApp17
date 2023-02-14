class ExamineCommand : ICommand
{
    private Room _room;
    public ExamineCommand(Room room)
    {
        _room = room;
    }
    public void Execute()
    {
        _room.DisplayRoom(_room);
    }
}