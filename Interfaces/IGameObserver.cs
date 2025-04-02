namespace Game.Interfaces;

public interface IGameObserver
{
    // Receive update from subject
    void OnGameOver(object? sender, Player winner);
    void OnPlayerMove(object? sender, PlayerMoveEventArgs args);
}