using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace StarryNight.Actors;

public class Spike: AbstractActor
{
    private IActor player;
    public Spike(IActor player)
    {
        Animation animation = new Animation("Resources/sprites/spikes.png", 16, 16);
        this.SetAnimation(animation);
        animation.Start();
        this.SetPhysics(true); 
        this.player = player;
    }
    
    public override void Update()
    {
        if (this.IntersectsWithActor(player)) 
        {
            ((AbstractCharacter)player).ChangeHealth(-1);
            if (((AbstractCharacter)player).GetHealth() <= 0) 
            {
                ((AbstractCharacter)player).Die();
            }
        }
    }
}