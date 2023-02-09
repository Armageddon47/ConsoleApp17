using System.IO;

enum RoomStates
    {
    Hall1,
    Room1,
    Room2
}
interface IRoom
{
    public string Name { get; set; }
    public string Description { get; set; }
    public void Render();

}
interface IState
{
    void Render();
    ICommand GetCommand();
}
interface ICommand
{
    void Execute();
}

//class Room
//{
//    public string Name { get; set; }
//    public string Description { get; set; }
//    public Room(string name, string description)
//    {
//        Name = name;
//        Description = description;
//    }
//}
class Hall : IRoom
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Hall()
    {

        Name = "hall";
        Description = "halldesx";
    }
    public void Render()
    {
        Console.WriteLine("you are now in {0} - {1}",Name,Description);
    }
}
    class Room1 : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Room1()
        {

            Name = "Room1";
            Description = "room1desc";
        }
    public void Render()
    {
        Console.WriteLine("you are now in {0} - {1}", Name, Description);
    }
}

class Room2 : IRoom
{
        public string Name { get; set; }
        public string Description { get; set; }

        public Room2()
        {

            Name = "Room2";
            Description = "room2desc";
        }
    public void Render()
    {
        Console.WriteLine("you are now in {0} - {1}", Name, Description);
    }
}
class Player
{
    public string Name { get; private set; }
    public RoomStates State { get; set; }
    = RoomStates.Hall1;
    public Player()
    {
        Player player = new Player();
        while (true)
        {
            Console.WriteLine("Enter Player Name");
            string name = Console.ReadLine();
            if (name != "")
            {
                Name = name; 
                PlayerStats playerstats = new(player);
                break;
            }
            
        }
        
    }
    public RoomStates GetState()
    {
        return State;
    }
    public void SetState(RoomStates st)
    {
        
    }
}
//class SaveGame
//{
//    public SaveGame(RoomState roomstate)
//    {

//    }
//}
class LoadGame
{
   public void Render()
    {

    }
    public ICommand GetCommand()
    {
        return null;
    }
}
class NewGameCommand : ICommand
{
    public void Execute()
    {
        Player player = new Player();
        GameStatsEngine gameStatsEngine = new GameStatsEngine();
        
        Game game = new Game();
        game.Run(player,gameStatsEngine);
        
    }
}
class LoadCommand : ICommand
{
    public void Execute()
    {
        LoadGame load = new LoadGame();
    }
}
class InvalidCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Invalid Command");
    }
}
class GameStatsEngine
{
    private RoomStates _states;
    Player player = new Player(); 
    public GameStatsEngine()
    {
        RoomStates states = new RoomStates();
        states = RoomStates.Hall1;
        _states = states;
    }
    public IRoom GetRoomState()
    {
        player.GetState();
        RoomStates states = player.State;
        
        if (states == RoomStates.Hall1)
        {
            Hall hall1 = new Hall();
            hall1.Render();
           
            return hall1;
        }
        else if (states == RoomStates.Room1)
        {
            Room1 room1 = new Room1();
            room1.Render();
            return room1;
        }
        else if (states == RoomStates.Room2)
        {
            Room2 room2 = new Room2();
            room2.Render();
            return room2;
        }
        Hall noselection = new Hall();
        noselection.Render();
        return noselection;
    }

}
//class PlayerStats
//{
    
//    public Player Player { get; set; }
//    public  PlayerStats(Player player)
//    {
//        Player = player;
//    }
//    public Player GetPlayerStats()
//    {
//        return Player;
//    }
//    public void SetPlayerStats(RoomStates stats)
//    {
//        Player.State = stats;
//    }

//}
class MainManuState : IState
{
    public void Render()
    {
        Console.WriteLine("Main Manu");
        Console.WriteLine("[new] For New Game");
        Console.WriteLine("[load] For Game Load");

    }
    public ICommand GetCommand()
    {
        var command = Console.ReadLine();
        if (command == "new")
        {
            return new NewGameCommand();
        }
        else if (command == "load")
        {
            return new LoadCommand();
        }
        else
        {
            return new InvalidCommand();
        }
    }
}
class Game
{
    public Player Player { get; set; }
    public IRoom Room { get; set; }
    public GameStatsEngine GameStateEngine { get; set; }
    public void Run(Player player,  GameStatsEngine gamestateengine)
    {

        Player = player;
        
        GameStateEngine = gamestateengine;

        
    }

}
class Program
{
    static void Main()
    {
        GameStatsEngine gamestats = new GameStatsEngine();
        MainManuState mainManuState = new MainManuState();
        while (true)
        {
            mainManuState.Render();
            var command = mainManuState.GetCommand();
            command.Execute();

        }

    }
}