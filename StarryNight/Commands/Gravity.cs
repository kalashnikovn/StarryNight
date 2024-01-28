using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace StarryNight.Commands
{
    class Gravity : IPhysics
    {
        private IWorld world;
        private IAction<IActor> fall = new Fall<IActor>(7);
        public void Execute()
        {
            world.GetActors().Where(x => x.IsAffectedByPhysics()).ToList().ForEach(x => fall.Execute(x));
        }
   
        public void SetWorld(IWorld world)
        {
            this.world = world;
        }
    }
}
