using Merlin2d.Game;
using StarryNight.Actors;

namespace StarryNight.Spell
{
    public class SpellDirector : ISpellDirector
    {
        private ISpellDataProvider Spellinfos;
        private Dictionary<string, SpellInfo> spells;
        private Dictionary<string, int> effects;
        private IWizard wizard;
        public SpellDirector(IWizard wizard)
        {
            this.Spellinfos = SpellDataProvider.GetInstance();
            this.spells = Spellinfos.GetSpellInfo();
            this.effects = Spellinfos.GetSpellEffects();
            this.wizard = wizard;
        }


        public ISpell Build(string spellName)
        {

            SpellInfo spell = this.spells[spellName];

            int spellCost = 0;

            foreach(string eff in spell.EffectNames)
            {
                spellCost += this.effects[eff];
            }
            
           

            ISpellBuilder spellBuilder;

            spellBuilder = new ProjectileSpellBuilder();

            foreach (string eff in spell.EffectNames)
            {
                spellBuilder.AddEffect(eff);
            }

            ProjectileSpell speller = (ProjectileSpell)spellBuilder
                .SetAnimation(new Animation(spell.AnimationPath, spell.AnimationWidth, spell.AnimationHeight))
                .SetSpellCost(spellCost)
                .CreateSpell(this.wizard);

            return speller;
            
        }
    }
}
