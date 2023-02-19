using System.Xml.Serialization;

[Serializable]
public class GameEngine
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

        _state = new HallState();//starting state
        _stateSaver.ChangeState(_state);
    }

    public void Run()//launching game
    {
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
    internal GameEngine saveEnginn() 
    //to return the current states of game in order to save
    {
        GameEngine savGameEngine = new GameEngine();
        savGameEngine.player = player;
        savGameEngine._state = _state;
        savGameEngine.hall = hall;
        savGameEngine.redRoom = redRoom;
        savGameEngine.blueRoom = blueRoom;
        savGameEngine._stateSaver = _stateSaver;
        return savGameEngine;
    }

    ICommand GetCommand(string input) 
    //execute command  based on input
    {

        switch (_input)
        {
            case "0":// moving
            {
                return new MoveCommand(_stateSaver);

            }
            case "1"://examining
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
            case "2"://pick up items
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
            case "3"://drop items
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

           
            case "4"://inventory display
            {

                return new PlayerInventoryCheck(player);

            }
            case "5":// save , needs fixing
            {
                
                GameEngine temp = saveEnginn();
                var xs = new XmlSerializer(typeof(GameEngine));
                using (TextWriter sw = new StreamWriter("FileName"))
                {
                    xs.Serialize(sw, temp);
                }

                List<string> saveStrings = new List<string>();
                saveStrings.Add(temp._state.ToString());

                return new SaveCommand(temp);

            }
            case "6":// load , needs fixing
                {
                GameEngine rslt;
                if (File.Exists("FileName"))
                {
                    var xs = new XmlSerializer(typeof(GameEngine));

                    using (var sr = new StreamReader("FileName"))
                    {
                        rslt = (GameEngine)xs.Deserialize(sr);
                    }

                    return new PlayerInventoryCheck(player);
                }

                return null;

            }
            default://if none of the above
                return new InvalidCommand();

        }

    }
    void GameOver()
    {
        if (redRoom._inventory.Count > 0 && blueRoom._inventory.Count > 0)
        {
            
        }
        

    }
}