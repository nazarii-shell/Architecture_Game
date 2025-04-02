using Game.Interfaces;

namespace Game;

public class Player
{
    private string _username;
    private int _position;
    public Player(string username)
    {
        _position = 0;
        _username = username;
    }

    public string Username { get => _username; set => _username = value; }
    public int Position { get => _position; set {} }
}