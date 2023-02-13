using System.Data.SqlTypes;
using System.IO;
using System.Runtime.InteropServices;

interface IState
{
    void Display();
    string GetCommand();
}
interface ICommand
{
    void Execute();
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
class RedBall : IGameObject
{

}
class BlueBall : IGameObject
{

}

class Player
{
    private List<IGameObject> _inventory = new List<IGameObject>();
    private string _name;
    public Player( string name)
    {
        _name = name;
    }
    void Display(Player player)
    {
        if (player._inventory.Count > 0)
        {
            for (int i = 0; i > player._inventory.Count; i++)
            {
                Console.WriteLine((i+0)+ " : " + player._inventory[i]);
            }
        }
    }
    IGameObject RemoveItem(Player player)
    {
        List<IGameObject> temp_inv = new List<IGameObject>();

        int selection;
            if (player._inventory.Count > 0)
            {
                Console.WriteLine("Enter number you want to remove");
                var input = Console.ReadLine();
                bool guardian = int.TryParse(input, out selection);
                selection -= 1;
                if (guardian&& player._inventory[selection] != null )
                {
                    temp_inv.Add(player._inventory[selection]);
                    player._inventory.RemoveAt(selection);

                }
            }

            return temp_inv[0];
    }
    Player AddITem(Player player, IGameObject gameObject)
    {
        player._inventory.Add(gameObject);
        return player;
        
    }
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
        Room1._inventory.Add(new RedBall());
        var Room2 = new Room("Room2");
        Room2._inventory.Add(new BlueBall());

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



class GameEngine
{
    private Player player = new Player("Player");
    private List<Room> rooms = new List<Room>();
    private Room room;
    private IState _state;
    private ICommand _command;
    private string _input;

    public GameEngine()
    {
        rooms = room.RoomsList();
        _state = new HallState();
    }
    void Run()
    {
        while (true)
        {
            _state.Display();
            _input = _state.GetCommand();
            State(_input);

        }
    }
    void State(string input)
    {
        switch (_input)
        {
            case "0":
            {
                break;
                
            }
            case "1":
            {
                break;
                ;
            }
            case "2":
            {
                break;
                ;
            }
            case "3":
            {
                break;
                ;
            }
        }
    }
    
}

class HallState : IState
{

    public void Display()
    {
        Console.WriteLine("you are in the hall!");
    }

    public string GetCommand()
    {
        Console.WriteLine("1 to examine, 2 to pick up, 3 to drop ,0 to move");

        var input = Console.ReadLine();
        return input;
    }

}

class Room1State : IState
{
    public void Display()
    {
        Console.WriteLine("you are in room 1!");

    }

    public string GetCommand()
    {
        Console.WriteLine("1 to examine, 2 to pick up, 3 to drop");

        var input = Console.ReadLine();
        return input;
    }

}
class Room2State : IState
{
    public void Display()
    {
        Console.WriteLine("you are in room 2!");

    }

    public string GetCommand()
    {
        Console.WriteLine("1 to examine, 2 to pick up, 3 to drop");
        var input =Console.ReadLine();
        return input;
    }

}
class Examine : ICommand
{
    public void Execute()
    {

    }
}