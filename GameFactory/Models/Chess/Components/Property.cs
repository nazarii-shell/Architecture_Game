using System.ComponentModel;
using IComponent = Game.Interfaces.IComponent;

namespace Game.Components;


public class Property : IComponent
{
    public string Name { get=> "Property"; }
    public string Fucntion
    {
        get => "Byu property";
    }
}