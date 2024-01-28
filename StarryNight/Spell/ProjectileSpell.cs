using StarryNight.Commands;
using StarryNight.Actors;
using StarryNight.Strategies;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Actions;

namespace StarryNight.Spell
{
    public class ProjectileSpell : AbstractActor, ISpell, IMovable
    {
        private IActor caster;
        private List<ICommand> effects;
        private Animation animation;
        private ISpeedStrategy sStrat;
        private int cost;
        bool isCasted;

        public ProjectileSpell(IActor actor, Animation anim, int cost)
        {
            this.effects = new List<ICommand>();
            this.caster = actor;
            this.animation = anim;
            this.cost = cost;
            this.isCasted = false;
        }

        public ISpell AddEffect(ICommand effect)
        {
            this.effects.Add(effect);
            return this;
        }

        public void AddEffects(IEnumerable<ICommand> effects)
        {
            this.effects.AddRange(effects);
        }

        public void Cast()
        {
            this.SetPosition(caster.GetX(), caster.GetY());
            this.SetAnimation(animation);
            this.caster.GetWorld().AddActor(this);
            this.isCasted = true;
        }

        public int GetCost()
        {
            return this.cost;
        }

        public double GetSpeed(double speed)
        {
            return this.sStrat.GetSpeed(speed);
        }

        public void SetSpeedStrategy(ISpeedStrategy strat)
        {
            this.sStrat = strat;
        }
        public override void Update()
        {
            if (this.isCasted)
            {
                IActor enemy = GetWorld().GetActors().Find(a => a.GetName() == "enemy");
                this.animation.Start();
                if (this.GetWorld().IntersectWithWall(this))
                {
                    this.GetWorld().RemoveActor(this);
                }
                
                foreach (ICommand eff in effects)
                {
                    if (eff is Damage && enemy != null)
                    {
                        if (this.IntersectsWithActor(enemy))
                        {
                            eff.Execute();
                        }
                    }
                    else
                    {
                        eff.Execute();
                    }
                    
                }
            }
        }
    }
}
