using Game.Interfaces;

namespace Game.GameFactory;

internal abstract class BaseCreator
{
    public abstract IGame CreateGame();
}