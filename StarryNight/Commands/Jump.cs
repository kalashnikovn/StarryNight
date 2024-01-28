using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;

namespace StarryNight.Commands
{
    public class Jump : ICommand
    { 
        private IActor actor;
        private int height;
        private int speed;
        private int actualHeight;
        private int boost;
        
        public Jump(IActor actor,int height, int speed, int boost)
        {
            this.speed = speed;
            this.height = height;
            this.boost = boost;
            
            if(actor != null)
            {
                this.actor = actor;
            }
            else
            {
                throw new ArgumentException("error message goes here");
            }

        }
        
        public void Execute()
        {
            if(this.actualHeight >= this.height)
            {
                this.actualHeight = 0;
                this.boost = 15;
                return;
            }
            
            for (int i = 0; i < this.boost + this.speed; i++)
            {
                this.actor.SetPosition(this.actor.GetX(), this.actor.GetY() - 1);
                if (this.actor.GetWorld().IntersectWithWall(this.actor))
                { 
                    this.actualHeight = 0;
                    this.boost = 15;
                    return;
                }

            }
            this.actualHeight += (this.speed + this.boost) - 7;

            if(this.boost > 0)
            {
                this.boost--;
            }
        }
    }
}
