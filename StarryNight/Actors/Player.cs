using StarryNight.Enum;
using StarryNight.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using StarryNight.Spell;
using StarryNight.Items;
using StarryNight.Strategies;
using Merlin2d.Game.Enums;
using Merlin2d.Game.Items;

namespace StarryNight.Actors
{
    public class Player : AbstractCharacter, IWizard
    {
        private ICommand moveLeft;
        private ICommand moveRight;
        private ICommand jump;
        
        private Animation animation;
        
        private bool isLeft;
        private bool isKeyPressed;
        private bool isJumped;
        private int boost = 15;
        private int height;
        
        private ISpellDirector director;
        private int mana = 200;
        private int maxMana = 200;
        
        private IWorld world;
        private int manaCount;
        
        private IInventory backpack;
        
        private HealingPotion healingPotion;
        private ManaPotion manaPotion;
        private PoisonPotion poisonPotion;
        private IItem potion;
        private int position = 1;
        
        public Player() 
        {
           this.SetPhysics(true);

           this.animation = new Animation("Resources/sprites/shq1.png", 28,48 );
           NormalSpeedStrategy strategy = new NormalSpeedStrategy();
           this.SetSpeedStrategy(strategy);
           this.SetAnimation(this.animation);
           

           this.ChangeHealth(100); 
           this.moveLeft = new Move(this, this.GetSpeed(3.7) , -1 , 0);
           this.moveRight = new Move(this, this.GetSpeed(3.7), 1, 0);
           
           this.jump = new Jump(this, 100, 7, boost);
           this.animation.Start();
           
           this.director = new SpellDirector(this);
           this.Direction = ActorOrientation.FacingRight;
           
           this.backpack = new Backpack(3);
           this.backpack.AddItem(new ManaPotion());
           this.backpack.AddItem(new HealingPotion());
           this.backpack.AddItem(new PoisonPotion());
        }

        public void Cast(ISpell spell)
        {
            if (this.manaCount >= spell.GetCost())
            {
                spell.Cast();
                this.ChangeMana(-spell.GetCost());
            }
        }
        
        public void ChangeMana(int delta)
        {
            this.mana += delta;
            if (this.mana > this.maxMana)
            {
                this.mana = this.maxMana;
            }
            if (this.mana < 0)
            {
                this.mana = 0;
            }
        }

        public int GetMana()
        {
            return this.mana;       
        }
        
        private void ShowInfo()
        {
            Message message = new Message("hp" + GetHealth(), 10, 350, 15, Color.Green, (MessageDuration)2);
            Message messages = new Message("mn" + GetMana(), 60, 350, 15, Color.Blue, (MessageDuration)2);
            this.GetWorld().AddMessage(message);
            this.GetWorld().AddMessage(messages);
            
            this.GetWorld().ShowInventory(backpack);
        }

        public override void Update()
        {
            
            this.manaCount = GetMana();
            this.ShowInfo();
            
            if (Input.GetInstance().IsKeyPressed(Input.Key.Q))
            {
                ISpell spell = director.Build("Fireball");
                this.Cast(spell);
            }
            
            if (Input.GetInstance().IsKeyPressed(Input.Key.W))
            {
                ISpell spell = director.Build("Frostball");
                this.Cast(spell);
            }

            if (Input.GetInstance().IsKeyDown(Input.Key.LEFT))
            {
                if (this.Direction == ActorOrientation.FacingRight)
                {
                    this.animation.FlipAnimation();
                }
                this.Direction = ActorOrientation.FacingLeft;
                this.animation.Start();
                
                this.isKeyPressed = true;
                this.isLeft = true;
                this.moveLeft.Execute();
              
    
            }

            if (Input.GetInstance().IsKeyDown(Input.Key.RIGHT))
            {
             
                if (this.Direction == ActorOrientation.FacingLeft)
                {
                    this.animation.FlipAnimation();

                }
                this.Direction = ActorOrientation.FacingRight;
                this.animation.Start();
                
                this.isLeft = false;
                this.isKeyPressed = true;
                this.moveRight.Execute();
            }

            if (Input.GetInstance().IsKeyPressed(Input.Key.SPACE))
            {
                if (this.GetWorld().IsWall(this.GetX() / 16, (this.GetY() ) / 16 + 3))
                {
                    this.height = this.GetY();
                    this.isJumped = true;  
                }
            }
            
            
            
            if (Input.GetInstance().IsKeyPressed(Input.Key.E))
            {
                backpack.ShiftRight();
            }
            
            if (Input.GetInstance().IsKeyPressed(Input.Key.R))
            {
                backpack.ShiftLeft();
            }
            
            if (Input.GetInstance().IsKeyDown(Input.Key.T))
            {
                this.potion = backpack.GetItem();
                if (this.potion is HealingPotion)
                {
                    this.healingPotion = (HealingPotion)potion;
                    this.healingPotion.Use(this);
                }
                else if (this.potion is ManaPotion)
                {
                    this.manaPotion = (ManaPotion)potion;
                    this.manaPotion.Use(this);
                }
                else if (this.potion is PoisonPotion)
                {
                    this.poisonPotion = (PoisonPotion)potion;
                    this.poisonPotion.Use(this);
                }
                
            }
            else if (Input.GetInstance().IsKeyPressed(Input.Key.S))
            {
                this.backpack.RemoveItem(this.backpack.GetCapacity() - this.position);
                this.position++;
            }
            
            
            
            if (this.isJumped)
            {
                if (this.height - 100 < this.GetY())
                {
                    this.jump.Execute();
                    if (this.GetWorld().IntersectWithWall(this)) 
                    { 
                        this.SetPosition(this.GetX(), this.GetY() + 1);
                        this.isJumped = false;
                    }
                }
                else
                {
                    this.isJumped = false;
                }
                  

            }
            
            if (this.isKeyPressed)
            {
                this.animation.Start();
            }
            else
            {
                this.animation.Stop();
            }
            this.isKeyPressed = false;
        }
    }
}
