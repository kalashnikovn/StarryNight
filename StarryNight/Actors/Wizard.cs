using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace StarryNight.Actors
{
    public class Wizard : AbstractEnemy
    {
        public Wizard(IActor player): base(player)
        {
            this.animation = new Animation("Resources/sprites/wizard.png", 38, 46);
            this.SetAnimation(animation);
            this.animation.Start();
            this.SetPhysics(true);
        }
    }
}