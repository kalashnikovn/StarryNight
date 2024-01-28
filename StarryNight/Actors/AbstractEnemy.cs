using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using StarryNight.Commands;

namespace StarryNight.Actors;

public abstract class AbstractEnemy: AbstractCharacter
{
    private ICommand moveLeft;
    private ICommand moveRight;
    private ICommand boostMoveLeft;
    private ICommand boostMoveRight;
    private ICommand jump;
        
    protected Animation animation;
    private IActor player;

    private int counter;
    Random random = new Random();
    private int randomDirection;
    private int isChanged;
        
    private int boost = 15;
    private int height;  
    private bool isLeft;
    private bool isJumped;

    public AbstractEnemy(IActor player)
    {
        this.SetPhysics(true); 
        this.moveLeft = new Move(this, 1, -1, 0);
        this.moveRight = new Move(this, 1, 1, 0);
        this.boostMoveLeft = new Move(this, 2, -1, 0);
        this.boostMoveRight = new Move(this, 2, 1, 0);
        this.jump = new Jump(this, 180, 10, boost);
        this.player = player;
    }
    
    public override void Update()
        {
            if (this.GetHealth() == 0)
            {
                this.Die();
                this.animation.Stop();
                this.RemoveFromWorld();
            }
           
            
            if (this.IntersectsWithActor(player)) 
            {
                ((AbstractCharacter)player).ChangeHealth(-1);
                
                if (((AbstractCharacter)player).GetHealth() <= 0) 
                {
                    ((AbstractCharacter)player).Die();
                }
            }
            
            
            if (this.GetX() - player.GetX() < 100 || player.GetX() - this.GetX() > 100)
            {
                if (this.GetX() > player.GetX() && this.GetX() - player.GetX() != 1)
                {
                    if (this.isLeft == false)
                    {
                        this.animation.FlipAnimation();
                    }
                    this.randomDirection = 0;
                    this.isLeft = true;
                    this.boostMoveLeft.Execute();
                }
                else if (this.GetX() < player.GetX() && player.GetX() - this.GetX() != 1)
                {
                    if (isLeft == true)
                    {
                        animation.FlipAnimation();
                    }
                    randomDirection = 1;
                    isLeft = false;

                    boostMoveRight.Execute();
                }

                if (this.GetY() > player.GetY() && this.GetX() != player.GetX()) 
                { 
                    if (this.GetWorld().IsWall(this.GetX() / 16 , (this.GetY()) / 16  + 3) && this.GetY() - player.GetY() < 30)
                    {
                        this.height = this.GetY();
                        this.isJumped = true;
                    }
                }
            }   
            else if((this.GetX() - player.GetX() > 100 || player.GetX() - this.GetX() < 100) && this.GetX() != player.GetX())
            {
                 if(this.counter >= 120)
                 {
                     this.isChanged = randomDirection;
                     this.randomDirection = this.random.Next(0, 2);
                   
                     if(this.isChanged != this.randomDirection)
                     { 
                         this.animation.FlipAnimation();
                         this.isLeft = !this.isLeft;
                     }
                     this.counter = 0;
                 }

                 if (this.randomDirection % 2 == 0)
                 {
                     this.moveLeft.Execute();
                 }
                 else
                 {
                     this.moveRight.Execute();
                 }
            }
            
            
            if (this.GetX() == player.GetX())
            {
                this.animation.Stop();
            }
            else
            {
                this.animation.Start();
            }

            if (this.isJumped)
            {
                if ((height - 180) < this.GetY())
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


            this.counter++;
        }
}