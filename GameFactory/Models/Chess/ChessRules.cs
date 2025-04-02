using Game.Components;
using Game.Interfaces;

namespace Game;

public class ChessRules : IRules
{
    public int RequiredPlayers { get => 2; set{} }
    public List<IComponent> Components { get => [new Piece(), new ChessFIeld()]; set{} }
}