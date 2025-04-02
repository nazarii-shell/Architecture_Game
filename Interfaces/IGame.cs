namespace Game.Interfaces;

public interface IGame
{
    public bool RulesAreRead { get; set; }
    public string Name { get; }
    public List<IComponent> components { get; set; }
    public int PlayserRequired {get; set;}
    public event EventHandler<IPlayer>? gameOverHandler;
    public List<IPlayer> Players { get; set; }
    public List<ICell> Board { get; set; }

    public void InitializeField();
    public bool ShowRules();
    public void MovePlayers();

    public void AddPlayers();
    public void Play();
    public void WelcomeScreen();
    
    public void GameOver(IPlayer winner);
}