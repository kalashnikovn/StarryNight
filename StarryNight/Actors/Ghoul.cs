using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace StarryNight.Actors
{
    public class Ghoul : AbstractEnemy
    {
        public Ghoul(IActor player): base(player)
        {
            this.animation = new Animation("Resources/sprites/ghoul.png", 34, 47);
            this.SetAnimation(animation);
            this.animation.Start();
            this.SetPhysics(true);
        }
        
    }
}
