using System.IO;
using System.Runtime.InteropServices;

interface IState
{

}
interface ICommand
{
    void GetCommand();
}

interface IGameObject
{
    
}



class Program
{
    static void Main()
    {
        //GameStatsEngine gamestats = new GameStatsEngine();
        //MainManuState mainManuState = new MainManuState();
        //while (true)
        //{
        //    mainManuState.Render();
        //    var command = mainManuState.GetCommand();
        //    command.Execute();

        //}

    }

}

class Player
{

}
class Room
{
    private List<IGameObject> _inventory = new List<IGameObject>();
    private string _name;
    public Room( string name)
    {
        
        _name = name;
    }
    public List<Room> RoomsList()
    {
        List<Room> rooms = new List<Room>();
        var Hall = new Room("Hall");
        var Room1 = new Room("Room 1");
        var Room2 = new Room("Room2");
        rooms.Add(Hall);
        rooms.Add(Room1);
        rooms.Add(Room2);
        return rooms;

    }
    IGameObject GetItems(Room room)
    {
        List<IGameObject> item = new List<IGameObject>();
        if (room._inventory.Count > 0)
        {
            for (int i = 0; i < room._inventory.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " +room._inventory[i]);
            }
        }
        else
        {
            Console.WriteLine("Empty");
        }
        if (room._inventory.Count > 0)
        {
            int temp = 0;
            bool guardian = true;
            Console.WriteLine("Enter the number you want to take.");
            var input = Console.ReadLine();
            guardian = int.TryParse(input, out temp);
            temp -= temp;
            if (!guardian && room._inventory[temp]!= null)
            {
                item.Add(room._inventory[temp]);
                room._inventory.RemoveAt(temp);
            }
            else
            {
                Console.WriteLine("INVALID");
            }
        }

        return item[0];
    }
    Room DropItems(Room room ,IGameObject temp)
    {
        room._inventory.Add(temp);
        return room;
    }

}

class GameObjects : IGameObject
{

}

class GameEngine
{
    private Player player = new Player();
    public GameEngine()
    {

    }
}