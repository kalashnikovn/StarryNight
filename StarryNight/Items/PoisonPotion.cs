using StarryNight.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Items;


namespace StarryNight.Items
{
    public class PoisonPotion : AbstractActor, IItem, IUsable
    {
        private int usesRemaining = 1;

        public PoisonPotion()
        {
            this.SetAnimation(new Animation("Resources/sprites/poison.png", 16, 16));
        }

        public void Use(ICharacter character)
        {
            Player player = (Player)character;
            if (this.usesRemaining-- > 0)
            {
                player.ChangeHealth(-100);
                this.SetAnimation(new Animation("Resources/sprites/empty_potion.png", 16, 16));
            }
        }
        
        
        public override void Update()
        {
        }
    }
}
