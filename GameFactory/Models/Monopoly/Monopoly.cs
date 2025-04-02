using System.Diagnostics;

namespace Game;

using Game.Interfaces;

public class Monopoly : IGame
{
    private bool _rulesAreRead = false;

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

    private List<IPlayer> _players;

    public Monopoly(IRules rules)
    {
        Players = new List<IPlayer>(rules.RequiredPlayers);
        _playerRequired = rules.RequiredPlayers;
        this.components = rules.Components;
    }

    public event EventHandler<IPlayer>? gameOverHandler;

    public List<IPlayer> Players
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

    public IPlayer GetWinner()
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
            Console.WriteLine($"{p.Username}'s move: ");
            Console.WriteLine("Choose action, type number");
            for (int i = 0; i < components.Count; i++)
            {
                var component = components[i];
                if (component.Fucntion != null)
                {
                    Console.WriteLine($"{i + 1}) {component.Fucntion}");
                }
            }

            Console.ReadLine();
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
        IPlayer winner = GetWinner();
        GameOver(winner);
    }


    public void GameOver(IPlayer winner)
    {
        gameOverHandler?.Invoke(this, winner);
    }
}