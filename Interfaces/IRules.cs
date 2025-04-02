using System.Windows.Input;

namespace Game.Interfaces;

public interface IRules
{
    public int RequiredPlayers { get; set; }
    public List<IComponent> Components { get; set; }
}