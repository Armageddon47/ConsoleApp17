class BlueRoom : Room, IRoom
{
    // add any object
    public BlueRoom(string _name) : base(_name)
    {
        _inventory.Add(new RedBall());
    }
}