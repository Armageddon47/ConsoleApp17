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
interface IRoom
{
}

class Program
{
    static void Main()
    {
        var start = new GameEngine();
        start.Run();
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
    public Player(string name)
    {
        _name = name;
    }
    public void InventoryDisplay(Player player)
    {
        if (player._inventory.Count > 0)
        {
            Console.WriteLine("Inventory Contains:");
            for (int i = 0; i < player._inventory.Count; i++)
            {
                Console.WriteLine((i+1)+ " : " + player._inventory[i]);
            }
        }
        else
        {
            Console.WriteLine("inventory is empty!");
        }
    }
    public IGameObject RemoveItem(Player player)
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
    public void AddITem(Player player, IGameObject gameObject)
    {
        player._inventory.Add(gameObject);
    }
}

class RedRoom : Room, IRoom
{
    public RedRoom(string _name) : base(_name)
    {
        _inventory.Add(new BlueBall());
    }
}

class BlueRoom : Room, IRoom
{
    public BlueRoom(string _name) : base(_name)
    {
        _inventory.Add(new RedBall());
    }
}

class Hall : Room, IRoom
{
    public Hall(string _name) : base(_name)
    {
    }
}

class Room
{
    internal List<IGameObject> _inventory = new List<IGameObject>();
    private string _name;
    public Room( string name)
    {
        
        _name = name;
    }
    public void DisplayRoom(Room room)
    {
        
        for (int i = 0; i < room._inventory.Count; i++)
        {
            Console.WriteLine("There is a : "+room._inventory[i]);
        }
        if (room._inventory.Count < 1)
        {
            Console.WriteLine("Nothing here");
        }
    }
    public IGameObject GetItems(Room room)
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
            if (guardian && room._inventory[temp]!= null)
            {
                item.Add(room._inventory[temp]);
                room._inventory.RemoveAt(temp);
            }
            else
            {
                Console.WriteLine("INVALID");
            }
        }

        if (item.Count>0)
            return item[0];
        return null;
    }
    public void DropItems(Room room ,IGameObject temp)
    {
        room._inventory.Add(temp);
    }

}

class StateSaver : IState
{
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

class GameEngine
{

    private Player player = new Player("Player");
    private IState _state;
    private ICommand _command;
    private string _input;
    private RedRoom redRoom = new RedRoom("room1");
    private BlueRoom blueRoom = new BlueRoom("room2");
    private Hall hall = new Hall("room0");

    private StateSaver _stateSaver = new StateSaver();

    public GameEngine()
    {

        _state = new HallState();
        _stateSaver.ChangeState(_state);
    }

    public void Run()
    {
        RedRoom r = new RedRoom("ss");

        while (true)
        {
            _state = _stateSaver.GetState();
            _stateSaver.ChangeState(_state);
            _state.Display();
            _input = _state.GetCommand();
            _command = GetCommand(_input);
            _command.Execute();
        }
    }

    ICommand GetCommand(string input)
    {

        switch (_input)
        {
            case "0":
            {
                return new MoveCommand(_stateSaver);

            }
            case "1":
            {
                if (_state is RedroomState)
                {
                    return new ExamineCommand(redRoom);
                }

                if (_state is BlueRoomState)
                {
                    return new ExamineCommand(blueRoom);

                }

                if (_state is HallState)
                {
                    return new ExamineCommand(hall);
                }

                return new InvalidCommand();
            }
            case "2":
            {
                {
                    if (_state is RedroomState)
                    {
                        return new PickUPCommand(player, redRoom);
                    }

                    if (_state is BlueRoomState)
                    {
                        return new PickUPCommand(player, blueRoom);

                    }

                    if (_state is HallState)
                    {
                        return new PickUPCommand(player, hall);
                    }

                    return new InvalidCommand();
                }

            }
            case "3":
            {

                if (_state is RedroomState)
                {
                    return new DropCommand(player, redRoom);

                }

                if (_state is BlueRoomState)
                {
                    return new DropCommand(player, blueRoom);

                }

                if (_state is HallState)
                {
                    return new DropCommand(player, hall);

                }

                return new InvalidCommand();
            }

            case "4":
            {
                
                return new PlayerInventoryCheck(player);

            }

            default:
                return new InvalidCommand();












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
        Console.WriteLine("1 to examine, 2 to pick up, 3 to drop , 4 to check inventory ,0 to move");

        var input = Console.ReadLine();
        return input;
    }

}

class RedroomState : IState
{
    public void Display()
    {
        Console.WriteLine("you are in Red Room!");

    }

    public string GetCommand()
    {
        Console.WriteLine("1 to examine, 2 to pick up, 3 to drop , 4 to check inventory 0 to move");

        var input = Console.ReadLine();
        return input;
    }

}
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
class PickUPCommand : ICommand
{
    private Player _player;
    private Room _room;

    public PickUPCommand(Player player, Room room)
    {
        int temp;
        bool guardian = true;
        IGameObject item;
        room.DisplayRoom(room);
        //Console.WriteLine("which item you wanna Pick up");
        //var input = Console.ReadLine();
        //guardian = int.TryParse(input, out temp);
        //if (guardian)
        //{
            item = room.GetItems(room);

        if (item != null)
            player.AddITem(player, item);


        //}
    }

    public void Execute()
    {
        

    }
}
class DropCommand : ICommand
{
    private Player _player;
    private Room _room;
    public DropCommand(Player player, Room room)
    {
        int temp;
        bool guardian = true;
        IGameObject item;
        player.InventoryDisplay(player);
        //Console.WriteLine("which item you wanna drop");
        //var input = Console.ReadLine();
        //guardian = int.TryParse(input, out temp);
        //if (guardian)
        //{
           item = player.RemoveItem(player);
           room.DropItems(room,item);

        //}

    }
    public void Execute()
    {
        
    }

}
class PlayerInventoryCheck : ICommand
{
    private Player _player;
    public PlayerInventoryCheck(Player player)
    {
        _player = player;
    }
    public void Execute()
    {
        _player.InventoryDisplay(_player);
    }
}

class InvalidCommand : ICommand
{
    public void Execute()
    {

    }
}