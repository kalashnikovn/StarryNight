namespace StarryNight.Spell
{
    public interface ISpellDirector
    {
        ISpell Build(string spellName);
    }
}
