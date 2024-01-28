using StarryNight.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Items;


namespace StarryNight.Items
{
    public class ManaPotion : AbstractActor, IItem, IUsable
    {
        private int usesRemaining = 1;

        public ManaPotion()
        {
            this.SetAnimation(new Animation("Resources/sprites/mana.png", 16, 16));
        }
        
        public void Use(ICharacter character)
        {
            Player player = (Player)character;
            if (this.usesRemaining-- > 0)
            {
                player.ChangeMana(100);
                SetAnimation(new Animation("Resources/sprites/empty_potion.png", 16, 16));
            }
        }
        
        public override void Update()
        {

        }
    }
}
