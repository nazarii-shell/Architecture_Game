using Game.Interfaces;
using Game.Services;

string[] games = ["Monopoly", "Chess"];

string gameName = GameManager.SelectGame(games);
IGame game = GameManager.CreateGame(gameName);
game.gameOverHandler += GameManager.OnGameOver;

game.InitializeField();
game.AddPlayers();
game.WelcomeScreen();
game.Play();

game.gameOverHandler -= GameManager.OnGameOver; 




