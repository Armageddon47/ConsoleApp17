class RedRoom : Room, IRoom
{
    // add any object

    public RedRoom(string _name) : base(_name)
    {
        _inventory.Add(new BlueBall());
    }
}