namespace StarryNight.Strategies
{
    public class ModifiedSpeedStrategy : ISpeedStrategy
    {
        private double speedMultiprier;
        public ModifiedSpeedStrategy(double speedMultiprier)
        {
            this.speedMultiprier = speedMultiprier;
        }
        public double GetSpeed(double speed)
        {
            return speedMultiprier * speed;
        }
    }
}
