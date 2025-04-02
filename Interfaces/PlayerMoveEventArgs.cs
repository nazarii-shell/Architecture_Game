namespace Game.Interfaces;

public class PlayerMoveEventArgs : EventArgs
{
    public PlayerMoveEventArgs(Player _player, IComponent _component)
    {
        player = _player;
        component = _component;
    }

    public Player player { get; set; }
    public IComponent component { get; set; }
}
