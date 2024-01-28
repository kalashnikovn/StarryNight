namespace StarryNight.Commands
{
    public interface IAction<T>
    {
        public void Execute(T t);
    }
}
