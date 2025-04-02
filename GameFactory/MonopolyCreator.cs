using Game.Components;
using Game.Interfaces;

namespace Game.GameFactory;

internal class MonopolyCreator : BaseCreator
{
    
    public override IGame CreateGame()
    {
        return new Monopoly(new MonopolyRules());
    }
}