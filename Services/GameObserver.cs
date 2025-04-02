using Game.Interfaces;

namespace Game.Services;

public class GameObserver : IGameObserver
{
    public void Update(ISubject subject)
    {
        Console.WriteLine("GameObserver Reacted to the event.");
    }

    public void OnGameOver(object? sender, Player winner)
    {
        Console.WriteLine($"Game Over.\nWinner: {winner.Username}");
    }

    public void OnPlayerMove(object? sender, PlayerMoveEventArgs args)
    {
        Console.WriteLine($"{args.player.Username} did the action '{args.component.Fucntion}'\n");
    }
}