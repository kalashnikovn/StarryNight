using Merlin2d.Game;

namespace StarryNight.Actors;

public class Water: AbstractActor
{
    public Water()
    {
        Animation animation = new Animation("Resources/sprites/water.png", 16, 16);
        this.SetAnimation(animation);
        animation.Start();
    }
    
    public override void Update()
    {
    }
}