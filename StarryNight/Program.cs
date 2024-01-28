using StarryNight.Commands;
using StarryNight.Factories;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;

namespace StarryNight
{
   internal class Program
    {
        static void Main(string[] args)
        {
            GameContainer container = new GameContainer("Starry Night", 800,400);
            IWorld world = container.GetWorld();

            

            CameraFollowStyle style = CameraFollowStyle.CenteredInsideMapPreferBottom;
            container.SetCameraFollowStyle(style);
            container.SetCameraZoom(1);

            ActorFactory factory = new ActorFactory();

            world.SetFactory(factory);
            Gravity gravity = new Gravity();
            world.SetPhysics(gravity);
            world.SetMap("resources/maps/tile5.tmx");

         
            
            

            Action<IWorld> setCamera = world =>
            {
                IActor player = world.GetActors().Find(a => a.GetName() == "player");
                world.CenterOn(player);

            };
            
            

            world.AddInitAction(setCamera);
            container.Run();
            
        }
    }
}
