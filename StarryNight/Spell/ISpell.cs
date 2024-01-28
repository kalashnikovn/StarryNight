using Merlin2d.Game.Actions;

namespace StarryNight.Spell
{
    public interface ISpell
    {
        ISpell AddEffect(ICommand effect);
        void AddEffects(IEnumerable<ICommand> effects);
        int GetCost();
        void Cast();
        
    }
}
