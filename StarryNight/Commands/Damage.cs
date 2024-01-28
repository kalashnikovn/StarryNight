using StarryNight.Actors;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Actions;

namespace StarryNight.Commands
{
    public class Damage : ICommand
    {
        private int amount;
        private IActor actor;
        
        public Damage(int amount)
        {
            this.amount = amount;
        }

        public void SetActor(IActor actor)
        {
            this.actor = actor;
        }

        public void Execute()
        {
            AbstractCharacter enemy = (AbstractCharacter)actor.GetWorld().GetActors().Find(a => a.GetName() == "enemy");
            
            if (enemy != null){
                if (this.actor.IntersectsWithActor(enemy))
                {
                    enemy.ChangeHealth(-this.amount);
                }
            }
        }
    }
}
