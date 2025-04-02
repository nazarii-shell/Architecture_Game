using Game.Interfaces;
using Game.Services;

string[] games = ["Monopoly", "Chess"];

string gameName = GameManager.SelectGame(games);
IGame game = GameManager.CreateGame(gameName);

IGameObserver gameObserver = new GameObserver();
game.Attach(gameObserver);

game.InitializeField();
game.AddPlayers();
game.WelcomeScreen();
game.Play();

game.Detach(gameObserver);


