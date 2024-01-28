using Merlin2d.Game.Actors;

namespace StarryNight.Commands
{
    public class Fall<T> : IAction<T> where T : IActor
    {
        private int speed;
        
        public Fall(int speed)
        {
            this.speed = speed;
        }

        public void Execute(T type)
        {
            for (int i = 0; i < speed; i++)
            {
                type.SetPosition(type.GetX(), type.GetY() + 1);

                if (type.GetWorld().IntersectWithWall(type))
                {
                    break;
                }
            }
            
            while (type.GetWorld().IntersectWithWall(type))
            {
                type.SetPosition(type.GetX() , type.GetY() - 1);
            }
        }
    }
}
