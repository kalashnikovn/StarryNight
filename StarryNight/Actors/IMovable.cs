using StarryNight.Strategies;


namespace StarryNight.Actors
{
    public interface IMovable 
    {
        void SetSpeedStrategy(ISpeedStrategy strategy);
        double GetSpeed(double speed);

    }
}
