namespace Game.Interfaces;

public interface ISubject
{
    // Attach an observer to the subject.
    void Attach(IGameObserver gameObserver);

    // Detach an observer from the subject.
    void Detach(IGameObserver gameObserver);

    // Notify all observers about an event.
    void Notify(Player player);
    void Notify(Player player, IComponent component);
}