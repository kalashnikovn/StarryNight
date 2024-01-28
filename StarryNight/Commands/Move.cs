using StarryNight.Actors;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;

namespace StarryNight.Commands
{
    public class Move : ICommand
    {
        private IActor movable;
        private int dx;
        private double step;
        private int dy;

        public Move(IActor movable, double step, int dx, int dy)
        {
            if (movable != null)
            {
                this.dx = dx;
                this.dy = dy;
                this.step = step;
                this.movable = movable;

            }
            else 
            {
                throw new ArgumentException("error message goes here");
            }
        }

        public void Execute()
        {
            this.movable.SetPosition((int)(this.movable.GetX() + this.dx * this.step), (int)(this.movable.GetY() + this.dy * this.step));

            while (this.movable.GetWorld().IntersectWithWall(this.movable))
            {
                this.movable.SetPosition(this.movable.GetX() + dx * -1, this.movable.GetY() + this.dy * -1  );
            }
          
        }
    }
}
