namespace StarryNight.Spell
{
    public interface ISpellDataProvider
    {
        public Dictionary<string, SpellInfo> GetSpellInfo();
        public Dictionary<string, int> GetSpellEffects();

    }
}
