using StarryNight.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actors;


namespace StarryNight.Factories
{
    public class ActorFactory : IFactory
    {
        IActor actor;
        public IActor Create(string actorType, string actorName, int x, int y)
        {
            if (actorType ==  "player") 
            {
                actor = new Player();

                actor.SetName(actorName);
                actor.SetPosition(x, y);
                return actor;

            }
            if (actorType == "skeleton") 
            {
                Ghoul ghoul = new Ghoul(actor);

                ghoul.SetName(actorName);
                ghoul.SetPosition(x, y);
                return ghoul;
            }
            
            if (actorType == "wizard") 
            {
                Wizard wizard = new Wizard(actor);

                wizard.SetName(actorName);
                wizard.SetPosition(x, y);
                return wizard;
            }

            if (actorType == "spike")
            {
                Spike spike = new Spike(actor);
                spike.SetName(actorName);
                spike.SetPosition(x, y);
                return spike;
            }
            
            if (actorType == "water")
            {
                Water water = new Water();
                water.SetName(actorName);
                water.SetPosition(x, y);
                return water;
            }
            
            return null;
        }
    }
}
