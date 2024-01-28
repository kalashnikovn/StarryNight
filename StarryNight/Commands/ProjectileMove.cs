using StarryNight.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Actions;

namespace StarryNight.Commands
{
    public class ProjectileMove : ICommand
    {
        IActor actor;
        private double steps;
        private int DirX;
        private int DirY;
        private IMovable move;
        private double changinspeed;

        public ProjectileMove(IMovable movable, int dx, int dy)
        {
            this.move = movable;
            this.steps = move.GetSpeed(4);
            this.DirX = dx;
            this.DirY = dy;
            this.actor = (IActor)movable;
        }

        public void Execute()
        {
            this.steps = this.move.GetSpeed(this.steps);
            if (this.steps % 1 != 0)
            {
                this.changinspeed += (this.steps % 1);

                if (this.changinspeed >= 1)
                {
                    this.changinspeed--;
                    Math.Ceiling(this.steps);
                }
                else
                {
                    this.steps -= this.steps;
                }
            }
            
            IWorld world = this.actor.GetWorld();
            this.actor.SetPosition((int)(this.actor.GetX() + this.DirX * this.steps), (int)(this.actor.GetY() + this.DirY * this.steps));
            
            if (world.IntersectWithWall(this.actor))
            {
                world.RemoveActor(this.actor);
            }
            
            if (this.actor.IntersectsWithActor(this.actor.GetWorld().GetActors().Where(a => a.GetName() == "enemy").FirstOrDefault()))
            {
               world.RemoveActor(this.actor);
            }
        }
    }
}
