using Game.Components;
using Game.Interfaces;

namespace Game.GameFactory;

internal class ChessCreator : BaseCreator
{
    public override IGame CreateGame()
    {
        return new Chess(new ChessRules());
    }
}