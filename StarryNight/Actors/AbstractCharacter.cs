using StarryNight.Enum;
using StarryNight.Strategies;
using Merlin2d.Game.Actions;


namespace StarryNight.Actors
{
    public abstract class AbstractCharacter : AbstractActor, ICharacter
    {
        private int health = 100;
        private List<ICommand> effects = new List<ICommand>();
        private ISpeedStrategy speedStrategy;
        private bool die;

        public ActorOrientation Direction { get; set;}
        
        public void AddEffect(ICommand effect)
        {
            this.effects.Add(effect);
            this.Direction = ActorOrientation.FacingRight;
        }
        
        public int GetHealth()
        {
            return this.health;
        }

        public double GetSpeed(double speed)
        {
            return speed;
        }

        public void RemoveEffect(ICommand effect)
        {
            this.effects.Remove(effect);
        }
        
        public void ChangeHealth(int delta)
        {
            this.health += delta;
        }

        public bool GetDie()
        {
            return this.die;
        }
        
        public void Die()
        {
            if (this.GetHealth() <= 0) 
            {
                this.die = true;
                this.RemoveFromWorld();
            }
        }

        public void SetSpeedStrategy(ISpeedStrategy strategy)
        {
            this.speedStrategy = strategy;
        }
        
        public override void Update()
        {
            this.effects.ForEach(e => e.Execute());
        }
    }
}
