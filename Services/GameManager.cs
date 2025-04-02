using Game.GameFactory;
using Game.Interfaces;

namespace Game.Services;

public static class GameManager
{
    public static string SelectGame(string[] games)
    {
        for (int i = 0; i < games.Length; i++)
        {
            Console.WriteLine($"{i}) {games[i]}");
        }

        Console.WriteLine("Type game to play ");
        string name = Console.ReadLine();
        return name;
    }

    public static void OnGameOver(object? sender, IPlayer winner)
    {
        Console.WriteLine($"Game Over.\nWinner: {winner.Username}");
    }

    public static IGame CreateGame(string game)
    {
        switch (game.ToLower())
        {
            case "chess":
                return new ChessCreator().CreateGame();

            case "monopoly":
                return new MonopolyCreator().CreateGame();

            default:
                throw new Exception("this game is not supported!");
        }
    }
}