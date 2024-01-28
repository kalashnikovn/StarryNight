using StarryNight.Commands;
using StarryNight.Enum;
using Merlin2d.Game;
using StarryNight.Actors;
using StarryNight.Strategies;
using Merlin2d.Game.Actions;

namespace StarryNight.Spell
{
    public class ProjectileSpellBuilder : ISpellBuilder
    {
        private Animation animation;
        private int cost;
        private List<ICommand> spellEffects;

        public ProjectileSpellBuilder()
        {
            this.spellEffects = new List<ICommand>();
        }

        public ISpellBuilder AddEffect(string effectName)
        {
            if(effectName.StartsWith("damage"))
            {
                this.spellEffects.Add(new Damage(int.Parse(effectName.Split('-')[1])));
            }
            return this;
        }

        public ISpell CreateSpell(IWizard caster)
        {
            AbstractCharacter character = (AbstractCharacter)caster;
            ProjectileSpell projectile = new ProjectileSpell(caster, animation, cost);

            projectile.SetSpeedStrategy(new NormalSpeedStrategy());

            if (character.Direction == ActorOrientation.FacingRight)
            {

                projectile.AddEffect(new ProjectileMove(projectile, 1, 0));
            }
            else
            {
                this.animation.FlipAnimation();
                projectile.AddEffect(new ProjectileMove(projectile, -1, 0));
            }
            foreach(ICommand spell in this.spellEffects)
            {
                if(spell is Damage)
                {
                    ((Damage)spell).SetActor(projectile);
                }
            }
            projectile.AddEffects(this.spellEffects);
            return projectile;
        }

        public ISpellBuilder SetAnimation(Animation animation)
        {
            this.animation = animation;
            return this;
        }

        public ISpellBuilder SetSpellCost(int cost)
        {
            this.cost = cost;
            return this;
        }
    }
}
