using StarryNight.Spell;
using Merlin2d.Game.Actors;

namespace StarryNight.Actors
{
    public interface IWizard : IActor
    {
        void ChangeMana(int delta);
        int GetMana();
        void Cast(ISpell spell);
    }
}
