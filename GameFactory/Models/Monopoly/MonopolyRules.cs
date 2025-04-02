using Game.Components;
using Game.Interfaces;

namespace Game;

public class MonopolyRules : IRules
{
    public int RequiredPlayers { get => 3; set {} }
    public List<IComponent> Components { get => [new Card(), new Dice(), new MonopolyFiled()] ; set {} }
}