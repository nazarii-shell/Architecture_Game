using System.Diagnostics;

namespace Game;

using Game.Interfaces;

public class Monopoly : IGame
{
    private bool _rulesAreRead = false;
    private List<IGameObserver> _observers = new List<IGameObserver>();

    public bool RulesAreRead
    {
        get => _rulesAreRead;
        set { _rulesAreRead = value; }
    }

    public string Name
    {
        get => "Monopoly";
    }

    public List<IComponent> components { get; set; }

    private List<ICell> _board = [];
    private int _playerRequired;

    public int PlayserRequired
    {
        get => _playerRequired;
        set { }
    }

    private List<Player> _players;

    public Monopoly(IRules rules)
    {
        Players = new List<Player>(rules.RequiredPlayers);
        _playerRequired = rules.RequiredPlayers;
        this.components = rules.Components;
    }

    public event EventHandler<Player>? gameOverHandler;
    public event EventHandler<PlayerMoveEventArgs>? playerMoveHandler;

    public List<Player> Players
    {
        get => _players;
        set => _players = value;
    }

    public List<ICell> Board
    {
        get => _board;
        set => _board = value;
    }

    public bool ShowRules()
    {
        Console.WriteLine("Monopoly rules: ...");
        Console.WriteLine("Continue - y");
        string res = Console.ReadLine().ToLower();
        return res == "y";
    }

    public void WelcomeScreen()
    {
        Console.WriteLine("*Press R to read rutes, press N to go Next" +
                          "Press N to go to the Game");


        while (!_rulesAreRead)
        {
            string answer = Console.ReadLine().ToLower();

            switch (answer)
            {
                case "r":
                    ShowRules();
                    _rulesAreRead = true;
                    continue;
            }

            Console.WriteLine("You must read the rules first");
        }
    }

    public Player GetWinner()
    {
        Random rnd = new();
        int playerIndex = rnd.Next(0, _players.Count);
        return _players[playerIndex];
    }


    public void InitializeField()
    {
    }

    public void MovePlayers()
    {
        _players.ForEach(p =>
        {
            IComponent selectedComponent;
            Console.WriteLine($"{p.Username}'s move: ");
            Console.WriteLine("Choose action, type number");
            
            for (int i = 0; i < components.Count; i++)
            {
                var component = components[i];
                if (component.Fucntion != null)
                {
                    Console.WriteLine($"{i}) {component.Fucntion}");
                }
            }

            int index = int.Parse(Console.ReadLine());
            selectedComponent = components[index];
            Notify(p, selectedComponent);
        });
    }

    public void AddPlayers()
    {
        for (int i = 0; i < PlayserRequired; i++)
        {
            Console.WriteLine("Enter player name: ");
            string name = Console.ReadLine();
            _players.Add(new Player(name));
        }
    }

    public void Play()
    {
        MovePlayers();
        Player winner = GetWinner();
        Notify(winner);
    }

    // The subscription management methods.
    public void Attach(IGameObserver gameObserver)
    {
        gameOverHandler += gameObserver.OnGameOver;
        playerMoveHandler += gameObserver.OnPlayerMove;
    }

    public void Detach(IGameObserver gameObserver)
    {
        gameOverHandler -= gameObserver.OnGameOver;
        playerMoveHandler += gameObserver.OnPlayerMove;
    }
    

    // Trigger an update in each subscriber.
    public void Notify(Player winner)
    {
        gameOverHandler?.Invoke(this, winner);
    }

    public void Notify(Player player,  IComponent component)
    {
        playerMoveHandler?.Invoke(this, new PlayerMoveEventArgs(player, component));
    }
}